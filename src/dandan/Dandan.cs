namespace dandan;

/// <summary>
/// Entry point for everything specific to the Dandân deck.
/// <see href="https://mtg.fandom.com/wiki/Forgetful_Fish#Typical_decklist">Forgetful Fish</see>
/// </summary>
public static class Dandan
{
    private static readonly Lazy<CardList> LazyCardList = new(LoadCardList);

    private static readonly Lazy<Deck> LazyDeck = new(CreateDeck);

    public static CardList CardList => LazyCardList.Value;

    public static Deck Deck => LazyDeck.Value;

    public static Library CreateLibrary(Random rand) => Library.FromDeck(Deck, rand);

    private static CardList LoadCardList()
    {
        var assembly = typeof(Dandan).Assembly;
        var resourceName = assembly.GetManifestResourceNames()
            .SingleOrDefault(name => name.EndsWith(".Resources.dandan_card_list.json", StringComparison.Ordinal));
        using var json = (resourceName is not null ? assembly.GetManifestResourceStream(resourceName) : null)
            ?? throw new InvalidOperationException("The embedded Dandan card list resource was not found.");

        return SerDe.CardListDeserializer.Deserialize(json);
    }

    private static Deck CreateDeck()
    {
        var cards = CardList.Cards;
        var deck = CardsAndQuantities.ToDictionary(entry => cards.First(c => c.Name == entry.Name), entry => entry.Count);
        return new Deck(deck);
    }

    private static readonly (int Count, string Name)[] CardsAndQuantities = [
        // Creatures (10)
        (10, "Dandân"),

        // Instants (34)
        (4, "Accumulated Knowledge"),
        (2, "Brainstorm"),
        (2, "Crystal Spray"),
        (2, "Dance of the Skywise"),
        (8, "Memory Lapse"),
        (2, "Metamorphose"),
        (2, "Mind Bend"),
        (2, "Mystical Tutor"),
        (2, "Predict"),
        (2, "Ray of Command"),
        (2, "Supplant Form"),
        (2, "Unsubstantiate"),
        (2, "Vision Charm"),

        // Sorceries (4)
        (2, "Diminishing Returns"),
        (2, "Mystic Retrieval"),

        // Lands (32)
        (2, "Halimar Depths"),
        (18, "Island"),
        (2, "Izzet Boilerworks"),
        (2, "Lonely Sandbar"),
        (2, "Mystic Sanctuary"),
        (2, "Remote Isle"),
        (2, "Svyelunite Temple"),
        (2, "Temple of Epiphany"),
    ];
}
