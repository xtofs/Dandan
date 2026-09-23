namespace dandan.SerDe;

using System.Text.Json;
using System.Text.Json.Serialization;

internal static class CardListDeserializer
{
    /// <summary>
    /// Reads a Scryfall card-list JSON and returns the cards keyed by their name.
    /// </summary>
    internal static IReadOnlyDictionary<string, Card> Deserialize(Stream json)
    {
        ArgumentNullException.ThrowIfNull(json);

        var cards = JsonSerializer.Deserialize<ScryfallCardListEnvelop>(json, SerializerOptions)?.Data
            ?? throw new JsonException("The Scryfall card list did not contain a data array.");

        return cards.ToDictionary(card => card.Name, card => card.ToCard(), StringComparer.Ordinal);
    }


    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new ManaCostJsonConverter(), new ManaColorJsonConverter() }
    };

    private sealed class ScryfallCardListEnvelop
    {
        [JsonPropertyName("data")]
        public List<ScryfallCard> Data { get; set; } = [];
    }
}
