namespace dandan;

using System.Text.RegularExpressions;

/// <summary>
/// Entry point for everything specific to the Dandân deck.
/// <see href="https://mtg.fandom.com/wiki/Forgetful_Fish#Typical_decklist">Forgetful Fish</see>
/// </summary>
public static class Dandan
{
    public static Deck Deck => LazyDeck.Value;

    public static Library CreateLibrary(Random rand) => Library.FromDeck(Deck, rand);


    private static readonly Lazy<Deck> LazyDeck = new(LoadDeck);

    private static Deck LoadDeck()
    {
        var assembly = typeof(Dandan).Assembly;
        var resourceName = assembly.GetManifestResourceNames()
            .SingleOrDefault(name => name.EndsWith(".Resources.dandan_card_list.json", StringComparison.Ordinal));
        using var json = (resourceName is not null ? assembly.GetManifestResourceStream(resourceName) : null)
            ?? throw new InvalidOperationException("The embedded Dandan card list resource was not found.");

        var cards = SerDe.CardListDeserializer.Deserialize(json);


        // Apply fixups to each card before constructing the deck.
        foreach (var card in cards.Values)
        {
            foreach (var fixup in Fixups)
            {
                fixup(card);
            }
        }

        var deck = CardQuantities.ToDictionary(entry => cards[entry.Name], entry => entry.Count);
        return new Deck(deck);
    }

    private static readonly Action<Card>[] Fixups = [FixUpActions, FixUpTypeFromTypeLine, FixUpTarget];

    // fix up actions for the card using the map
    private static void FixUpActions(Card card)
    {
        if (CardToActionMap.TryGetValue(card.Name, out var actions))
        {
            card.Actions = actions;
        }
    }

    private static void FixUpTarget(Card card)
    {

        // 115. Targets 
        // targets are object(s) and/or player(s) the spell or ability will affect.
        // 115.1a [...] by using the phrase “target [something],” 

        var match = Regexes.TargetRegex.Match(card.FlavorText ?? "");
        if (match.Success)
        {
            card.Target = match.Captures[1].Value;
        }
    }

    // fix up the Type based on the type line
    private static void FixUpTypeFromTypeLine(Card card)
    {
        var parts = card.TypeLine.Split('—', StringSplitOptions.TrimEntries);
        var first = parts.Length > 0 ? parts[0] : card.TypeLine;
        card.Type = TypeMap[first];
    }

    private static readonly Dictionary<string, CardType> TypeMap = new Dictionary<string, CardType>
    {
        { "Creature", CardType.Creature },
        { "Instant", CardType.Instant },
        { "Sorcery", CardType.Sorcery },
        { "Land", CardType.Land },
        { "Basic Land", CardType.Land }
    };

    private static readonly (string Name, int Count)[] CardQuantities = [
        // Creatures (10)
        ("Dandân", 10),

        // Instants (34)
        ("Accumulated Knowledge", 4),
        ("Brainstorm", 2),
        ("Crystal Spray", 2),
        ("Dance of the Skywise", 2),
        ("Memory Lapse", 8),
        ("Metamorphose", 2),
        ("Mind Bend", 2),
        ("Mystical Tutor", 2),
        ("Predict", 2),
        ("Ray of Command", 2),
        ("Supplant Form", 2),
        ("Unsubstantiate", 2),
        ("Vision Charm", 2),

        // Sorceries (4)
        ("Diminishing Returns", 2),
        ("Mystic Retrieval", 2),

        // Lands (32)
        ("Halimar Depths", 2),
        ("Island", 18),
        ("Izzet Boilerworks", 2),
        ("Lonely Sandbar", 2),
        ("Mystic Sanctuary", 2),
        ("Remote Isle", 2),
        ("Svyelunite Temple", 2),
        ("Temple of Epiphany", 2),
    ];


    private static readonly Dictionary<string, IAction[]> CardToActionMap = new Dictionary<string, IAction[]> {
        { "Dandân", [ new Sacrifice() ]},
        { "Svyelunite Temple", [ new Sacrifice() ]},
        { "Memory Lapse", [ new Counter() ]},
        { "Mystical Tutor", [ new Search(Zone.Library), new Reveal() ]},
        { "Mystic Retrieval", [
            new ReturnTarget(Target.Instant|Target.Sorcery, ManaCost.Parse("{2}{R}"), Zone.Graveyard, Zone.Hand),
            new Flashback(ManaCost.Parse("{2}{R}"))
        ]},
        { "Diminishing Returns", [ new Shuffle(), new Exile() ]},
        { "Supplant Form", [
            new Create(),
            new ReturnTarget(Target.Creature, ManaCost.None, Zone.Battlefield, Zone.Hand)
        ]},
        { "Predict", [ new Mill() ]},
        { "Vision Charm", [ new Mill() ]},
        { "Lonely Sandbar", [ new Discard() ]},
        { "Remote Isle", [ new Discard() ]},
        { "Temple of Epiphany", [ new Scry(1) ]},
        { "Ray of Command", [ new Untap() ]},
    };

}

internal static partial class Regexes
{
    [GeneratedRegex(@"target\s+(\b\w+\b)", RegexOptions.IgnoreCase)]
    public static partial Regex TargetRegex { get; }
}

