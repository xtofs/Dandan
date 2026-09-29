using dandan;


var deck = Dandan.Deck;

foreach (var (card, count) in deck.Cards)
{
    Console.WriteLine("{0,-3} {1,-24} {2,-24} {3,-12} {4,-12} {5}",
        count, card.Name, card.Type.Name, string.Join(",", card.ColorIdentity), card.ManaCost, string.Join(",", card.Actions));
}

// // show all unique type lines in the deck
// var typeLines = deck.Cards.Select(c => c.Card.TypeLine).ToHashSet();
// foreach (var typeLine in typeLines)
// {
//     Console.WriteLine(typeLine);
// }

// // show all cards with their type line and type
// foreach (var (card, _) in deck.Cards)
// {
//     Console.WriteLine("{0} {1}", card.TypeLine, card.Type);
// }

// var rand = new Random(1);
// var library = Dandan.CreateLibrary(rand);

// Console.WriteLine();

// var drawResult = library.Draw(7);
// foreach (var card in drawResult.Cards)
// {
//     Console.WriteLine("{0,-24} {1,-24} {2,-12} {3}", card.Name, card.TypeLine, string.Join(",", card.ColorIdentity), card.ManaCost);

// }

// Console.WriteLine("number of cards in library: {0}", library.Count);


