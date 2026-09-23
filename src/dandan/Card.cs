namespace dandan;

/// <summary>
/// A Magic card. Instances are immutable/>.
/// </summary>
/// <remarks>
/// Deliberately a class and not a record: cards are used as keys in <see cref="Deck"/>, and
/// generated record equality would compare <see cref="Colors"/> and <see cref="ColorIdentity"/>
/// (arrays) and <see cref="ManaCost"/> (a struct holding a dictionary) by reference anyway,
/// so it would look like value equality while behaving like reference equality.
/// A card's identity is its <see cref="Id"/>, not the conjunction of all its members.
/// </remarks>
public class Card
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public ManaCost? ManaCost { get; init; }
    public double Cmc { get; init; }
    public string TypeLine { get; init; } = string.Empty;
    public string? OracleText { get; init; }
    public string? Power { get; init; }
    public string? Toughness { get; init; }

    public ManaColor[] Colors { get; init; } = [];

    public ManaColor[] ColorIdentity { get; init; } = [];

    public string? FlavorText { get; init; }
}
