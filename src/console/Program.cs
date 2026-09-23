using dandan;


var deck = Dandan.Deck;
foreach (var (card, count) in deck.Cards)
{
    Console.WriteLine("{0,-3} {1,-24} {2,-24} {3,-12} {4}", count, card.Name, card.TypeLine, string.Join(",", card.ColorIdentity), card.ManaCost);
}

var rand = new Random(1);
var library = Dandan.CreateLibrary(rand);

Console.WriteLine();

var drawResult = library.Draw(7);
foreach (var card in drawResult.Cards)
{
    Console.WriteLine("{0}", card.Name);
}


