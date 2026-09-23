namespace dandan;

using System.Runtime.InteropServices;

/// <summary>
/// Represents the quantities of cards in a deck to DrawFrom
/// </summary>
public sealed class Library(IReadOnlyList<Card> cards)
{
    private readonly List<Card> _cards = [.. cards];

    public int Count => _cards.Count;

    public static Library FromDeck(Deck deck, Random rand)
    {
        var cards = deck.Cards.SelectMany(c => Enumerable.Repeat(c.Card, c.Count)).ToList();

        rand.Shuffle(CollectionsMarshal.AsSpan(cards));

        return new Library(cards);
    }

    public void ReShuffle(Random rand)
    {
        rand.Shuffle(CollectionsMarshal.AsSpan(_cards));
    }

    /// <summary>
    /// Draws the specified number of cards from the top of the library.
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public DrawResult Draw(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

        var drawn = _cards[0..count];
        _cards.RemoveRange(0, count);
        return new DrawResult(drawn);
    }

    /// <summary>
    /// Scries the specified number of cards from the top of the library, allowing the caller to decide which cards to keep on top.
    /// Places the cards that are to be kept on top of the library at the beginning of the list in the order specified by the result
    /// and the cards that are to be put on the bottom of the library at the end of the list in the order specified by the result
    /// </summary>
    /// <param name="count"></param>
    /// <param name="order"></param>
    public void Scry(int count, Func<DrawResult, (DrawResult onTop, DrawResult onBottom)> order)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

        var scryCards = _cards[0..count];
        _cards.RemoveRange(0, count);

        var result = order(new DrawResult(scryCards));

        // Place the cards that are to be kept on top of the library at the beginning of the list in the order specified by the result
        _cards.InsertRange(0, result.onTop.Cards);
        // Place the cards that are to be put on the bottom of the library at the end of the list in the order specified by the result
        _cards.AddRange(result.onBottom.Cards);
    }
}
