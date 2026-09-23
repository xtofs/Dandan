namespace dandan;
/// <summary>
/// A list of cards, typically deserialized from a Scryfall card-list JSON.
/// </summary>
public sealed class CardList(IReadOnlyList<Card> cards)
{
    public IReadOnlyList<Card> Cards { get; } = cards;

}
