using dandan;



var cardList = CardList.LoadDandanCardList();
foreach (var card in cardList.Cards)
{
    Console.WriteLine("{0,-24} {1,-24} {2}", card.Name, card.TypeLine, card.ManaCost);
}

