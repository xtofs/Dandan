using dandan;
using dandan.Text;


var deck = Dandan.Deck;


// var table = FormatAsTable(
//     ["Count", "Name", "Type", "Color", "Mana Cost", "Actions", "Target", "Gatherer URL"],
//     deck.Cards.Select(c => new[]
//     {
//         c.Count.ToString(),
//         c.Card.Name,
//         c.Card.Type.Name,
//         string.Join(",", c.Card.Colors),
//         c.Card.ManaCost?.ToString() ?? "",
//         string.Join(", ", c.Card.Actions),
//         c.Card.Target ?? "",
//         c.Card.GathererUrl.ToString()
//     })
// );

var spec = new TableSpec(
[
    new Column("Name"),
    new Column("Text", MaxWidth: 60),
    new Column("Actions", MaxWidth: 40),
])
{
    // Format = args.Contains("--plain") ? TableFormat.Plain : TableFormat.Markdown,
    Format = args.Contains("--markdown") ? TableFormat.Markdown : TableFormat.Plain,
};

new TableWriter(Console.Out, spec).Write(
    deck.Cards
        // .Where(c => c.Card.OracleText.StartsWith("Return"))
        .Select(c => new[]
        {
            c.Card.Name,
            c.Card.OracleText?.ToString() ?? "",
            string.Join(", ", c.Card.Actions),
        })
);

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


