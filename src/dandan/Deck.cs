namespace dandan;

public class Deck(Dictionary<Card, int> decklist)
{
    private readonly Dictionary<Card, int> _decklist = decklist;

    public int Quantity(Card card) => _decklist.TryGetValue(card, out var count) ? count : 0;

    public IEnumerable<(Card Card, int Count)> Cards => _decklist.Select(kvp => (kvp.Key, kvp.Value));
}
