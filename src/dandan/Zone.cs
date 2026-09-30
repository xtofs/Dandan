namespace dandan;

/// <summary>
/// A zone is a place where objects can be during a game. 
/// <see href="https://magic.wizards.com/en/rules">400. General </see>
/// </summary>
public readonly struct Zone
{
    public string Name { get; }

    private Zone(string name)
    {
        Name = name;
    }

    override public string ToString() => Name;

    public static readonly Zone Library = new("Library");
    public static readonly Zone Hand = new("Hand");
    public static readonly Zone Battlefield = new("Battlefield");
    public static readonly Zone Graveyard = new("Graveyard");
    public static readonly Zone Stack = new("Stack");
    public static readonly Zone Exile = new("Exile");
    public static readonly Zone Command = new("Command");


}
