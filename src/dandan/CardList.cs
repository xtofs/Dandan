namespace dandan;

using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// A list of cards, typically deserialized from a Scryfall card-list JSON.
/// </summary>
public sealed class CardList(IReadOnlyList<Card> cards)
{
    public IReadOnlyList<Card> Cards { get; } = cards;

    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = { new ManaCostJsonConverter(), new ManaColorJsonConverter() }
    };

    public static CardList Deserialize(Stream json)
    {
        ArgumentNullException.ThrowIfNull(json);

        var cards = JsonSerializer.Deserialize<ScryfallCardList>(json, SerializerOptions)?.Data
            ?? throw new JsonException("The Scryfall card list did not contain a data array.");
        return new CardList(cards);
    }

    public static CardList LoadDandanCardList()
    {
        var assembly = typeof(CardList).Assembly;
        var resourceName = assembly.GetManifestResourceNames()
            .SingleOrDefault(name => name.EndsWith(".Resources.dandan_card_list.json", StringComparison.Ordinal));
        using var json = (resourceName is not null ? assembly.GetManifestResourceStream(resourceName) : null)
            ?? throw new InvalidOperationException("The embedded Dandan card list resource was not found.");

        return Deserialize(json);
    }

    private sealed class ScryfallCardList
    {
        public List<Card> Data { get; set; } = [];
    }
}

/// <summary>
/// Represents the quantities of cards in a deck.
/// </summary>
public sealed class Deck(Dictionary<Card, int> cards)
{
    public Dictionary<Card, int> Cards { get; } = cards;
}

internal sealed class ManaCostJsonConverter : JsonConverter<ManaCost?>
{
    public override ManaCost? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var manaCostText = reader.GetString();
        return string.IsNullOrEmpty(manaCostText) ? null : ManaCost.Parse(manaCostText, null);
    }

    public override void Write(Utf8JsonWriter writer, ManaCost? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString() ?? string.Empty);
    }
}

internal sealed class ManaColorJsonConverter : JsonConverter<ManaColor>
{
    public override ManaColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var symbol = reader.GetString();
        return symbol is not null && ManaColor.TryCreateFromSymbol(symbol, out var color)
            ? color
            : throw new JsonException($"'{symbol}' is not a valid mana color symbol.");
    }

    public override void Write(Utf8JsonWriter writer, ManaColor value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToSymbol());
    }
}
