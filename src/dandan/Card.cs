namespace dandan;

/// <summary>
/// Represents a card from the Scryfall API.
/// </summary>
public class Card
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ManaCost? ManaCost { get; set; }
    public double Cmc { get; set; }
    public string TypeLine { get; set; } = string.Empty;
    public string? OracleText { get; set; }
    public string? Power { get; set; }
    public string? Toughness { get; set; }

    public ManaColor[] Colors { get; set; } = [];

    public ManaColor[] ColorIdentity { get; set; } = [];

    public string? FlavorText { get; set; }
}
