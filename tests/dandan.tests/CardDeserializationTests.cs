namespace dandan;

public class CardDeserializationTests
{
    [Fact]
    public void LoadDandanCardList_DeserializesEmbeddedScryfallCardList()
    {
        var cardList = Dandan.CardList;
        var cards = cardList.Cards;

        Assert.Equal(24, cards.Count);

        var dandanCard = Assert.Single(cards, card => card.Name == "Dandân");
        Assert.Equal(2, dandanCard.ManaCost?.CostForColor(ManaColor.Blue));
        Assert.Equal(2, dandanCard.Cmc);
        Assert.Equal([ManaColor.Blue], dandanCard.Colors);

        var halimarDepths = Assert.Single(cards, card => card.Name == "Halimar Depths");
        Assert.Null(halimarDepths.ManaCost);
        Assert.Equal(0, halimarDepths.Cmc);

        Assert.Single(cards, card => card.Name == "Island");
    }

    [Fact]
    public void Deck_StoresCardQuantities()
    {
        var dandanCard = new Card { Name = "Dandân" };
        var deck = new Deck(new Dictionary<Card, int> { [dandanCard] = 10 });

        Assert.Equal(10, deck.Quantity(dandanCard));
    }
}
