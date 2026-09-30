namespace dandan;

[Flags]
public enum Target
{
    Creature = 1 << 0,
    Artifact = 1 << 1,
    Enchantment = 1 << 2,
    Land = 1 << 3,
    Planeswalker = 1 << 4,
    Instant = 1 << 5,
    Sorcery = 1 << 6,

    Any = Creature | Artifact | Enchantment | Land | Planeswalker | Instant | Sorcery
}

