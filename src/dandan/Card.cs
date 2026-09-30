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
    public string OracleText { get; init; } = string.Empty;
    public string? Power { get; init; }
    public string? Toughness { get; init; }

    public ManaColor[] Colors { get; init; } = [];

    // public ManaColor[] ColorIdentity { get; init; } = [];

    public string? FlavorText { get; init; }

    public string Set { get; init; } = "";

    public int CollectorNumber { get; init; }

    // set in post processing based on the card's type line and the action map

    public IAction[] Actions { get; internal set; } = [];

    public CardType Type { get; internal set; }




    // https://gatherer.wizards.com/EOC/en-us/166/lonely-sandbar
    // https://gatherer.wizards.com/SOC/en-us/388/mystic-sanctuary
    // https://gatherer.wizards.com/SOC/en-us/412/temple-of-epiphany
    public Uri GathererUrl => new Uri($"https://gatherer.wizards.com/{Set.ToUpper()}/en-us/{CollectorNumber}/{Name.Replace(" ", "-").ToLower()}");

    public string? Target { get; internal set; }
}
