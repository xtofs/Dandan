namespace dandan;

public readonly record struct CardType
{
    private CardType(string name) { Name = name; }

    public string Name { get; }

    public static readonly CardType Artifact = new("Artifact");
    public static readonly CardType Battle = new("Battle");
    public static readonly CardType Creature = new("Creature");
    public static readonly CardType Enchantment = new("Enchantment");
    public static readonly CardType Land = new("Land");
    public static readonly CardType Planeswalker = new("Planeswalker");
    public static readonly CardType Instant = new("Instant");
    public static readonly CardType Sorcery = new("Sorcery");


    // There are six permanent types: 
    // artifact, battle, creature, enchantment, land, and planeswalker. 
    // Instant and sorcery cards can’t enter the battlefield and thus can’t be permanents. 
    private static readonly HashSet<CardType> PermanentTypes = [
        Artifact,
        Battle,
        Creature,
        Enchantment,
        Land,
        Planeswalker
    ];

    public static bool IsPermanent(CardType type) => PermanentTypes.Contains(type);
}
