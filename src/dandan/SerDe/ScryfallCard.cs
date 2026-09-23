namespace dandan.SerDe;

using System.Text.Json.Serialization;

/// <summary>
/// The wire format of a single card as returned by the Scryfall API.
/// </summary>
internal sealed class ScryfallCard
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("mana_cost")]
    public ManaCost? ManaCost { get; set; }

    [JsonPropertyName("cmc")]
    public double Cmc { get; set; }

    [JsonPropertyName("type_line")]
    public string TypeLine { get; set; } = string.Empty;

    [JsonPropertyName("oracle_text")]
    public string? OracleText { get; set; }

    [JsonPropertyName("power")]
    public string? Power { get; set; }

    [JsonPropertyName("toughness")]
    public string? Toughness { get; set; }

    [JsonPropertyName("colors")]
    public ManaColor[] Colors { get; set; } = [];

    [JsonPropertyName("color_identity")]
    public ManaColor[] ColorIdentity { get; set; } = [];

    [JsonPropertyName("flavor_text")]
    public string? FlavorText { get; set; }

    public Card ToCard() => new()
    {
        Id = Id,
        Name = Name,
        ManaCost = ManaCost,
        Cmc = Cmc,
        TypeLine = TypeLine,
        OracleText = OracleText,
        Power = Power,
        Toughness = Toughness,
        Colors = Colors,
        ColorIdentity = ColorIdentity,
        FlavorText = FlavorText,
    };
}
