namespace dandan;

/// <summary>
/// 701. Keyword Actions
public enum KeywordActionKind
{
    Counter,
    Create, // 701.7. Create 
    Discard,
    Exile,
    Mill,
    Reveal,
    Sacrifice, // 701.21
    Scry,   // 701.22. Scry ; “scry N”
    Search,
    Shuffle,
    Tap,
    Untap,
    Recover,
    Flashback,
}
