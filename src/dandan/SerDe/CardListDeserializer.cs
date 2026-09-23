namespace dandan.SerDe;

using System.Text.Json;

public static class CardListDeserializer
{
    public static CardList Deserialize(Stream json)
    {
        ArgumentNullException.ThrowIfNull(json);

        var cards = JsonSerializer.Deserialize<ScryfallCardListEnvelop>(json, SerializerOptions)?.Data
            ?? throw new JsonException("The Scryfall card list did not contain a data array.");
        return new CardList(cards);
    }


    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = { new ManaCostJsonConverter(), new ManaColorJsonConverter() }
    };

    private sealed class ScryfallCardListEnvelop
    {
        public List<Card> Data { get; set; } = [];
    }
}
