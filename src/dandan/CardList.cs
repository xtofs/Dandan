namespace dandan;

using System.Text.Json;

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


    private sealed class ScryfallCardList
    {
        public List<Card> Data { get; set; } = [];
    }
}
