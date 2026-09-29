using System.Text;

public enum Align { Left, Right, Center }

public enum TableFormat { Plain, Markdown }

/// <summary>
/// Describes one table column. <see cref="MaxWidth"/> caps the column; longer cell text is wrapped
/// onto additional lines. <see cref="MinWidth"/> keeps a column from shrinking below a size.
/// </summary>
public sealed record Column(
    string Header,
    Align Align = Align.Left,
    int? MinWidth = null,
    int? MaxWidth = null)
{
    public static implicit operator Column(string header) => new(header);
}

public static class TableWriter
{
    /// <summary>
    /// Writes rows as a plain-text table. Rows are enumerated once and buffered, since column
    /// widths depend on all of them. Cells wider than their column's MaxWidth are word-wrapped.
    /// </summary>
    public static void Write(
        TextWriter writer,
        IReadOnlyList<Column> columns,
        IEnumerable<IReadOnlyList<string>> rows,
        TableFormat format = TableFormat.Plain,
        string separator = " ")
    {
        var data = rows.ToList();
        if (format == TableFormat.Markdown)
        {
            WriteMarkdown(writer, columns, data);
            return;
        }

        var widths = new int[columns.Count];
        for (var i = 0; i < columns.Count; i++)
        {
            var col = columns[i];
            var width = Math.Max(col.Header.Length, col.MinWidth ?? 0);
            foreach (var row in data)
            {
                width = Math.Max(width, LongestLine(Cell(row, i)));
            }
            widths[i] = col.MaxWidth is int max ? Math.Min(width, Math.Max(max, 1)) : width;
        }

        WriteRow(writer, columns, widths, columns.Select(c => c.Header).ToArray(), separator);
        foreach (var row in data)
        {
            WriteRow(writer, columns, widths, row, separator);
        }
    }

    /// <summary>Convenience overload for the common case of unformatted, left-aligned columns.</summary>
    public static void Write(
        TextWriter writer, string[] headers, IEnumerable<string[]> rows, TableFormat format = TableFormat.Plain) =>
        Write(writer, headers.Select(h => (Column)h).ToArray(), rows, format);

    /// <summary>
    /// GitHub-flavoured markdown table. MaxWidth is ignored (wrapping would break the row);
    /// newlines become &lt;br&gt; and pipes are escaped.
    /// </summary>
    private static void WriteMarkdown(
        TextWriter writer, IReadOnlyList<Column> columns, List<IReadOnlyList<string>> data)
    {
        var body = data
            .Select(r => columns.Select((_, i) => MarkdownEscape(Cell(r, i))).ToArray())
            .ToList();
        var headers = columns.Select(c => MarkdownEscape(c.Header)).ToArray();

        var widths = new int[columns.Count];
        for (var i = 0; i < columns.Count; i++)
        {
            widths[i] = Math.Max(3, Math.Max(headers[i].Length, columns[i].MinWidth ?? 0));
            foreach (var row in body) widths[i] = Math.Max(widths[i], row[i].Length);
        }

        void Line(IReadOnlyList<string> cells) => writer.WriteLine(
            "| " + string.Join(" | ", cells.Select((c, i) => Pad(c, widths[i], columns[i].Align))) + " |");

        Line(headers);
        Line(columns.Select((c, i) => c.Align switch
        {
            Align.Right => new string('-', widths[i] - 1) + ":",
            Align.Center => ":" + new string('-', widths[i] - 2) + ":",
            _ => ":" + new string('-', widths[i] - 1),
        }).ToArray());
        foreach (var row in body) Line(row);
    }

    private static string MarkdownEscape(string text) =>
        text.Replace("|", "\\|").Replace("\r", "").Replace("\n", "<br>");

    private static void WriteRow(
        TextWriter writer,
        IReadOnlyList<Column> columns,
        int[] widths,
        IReadOnlyList<string> row,
        string separator)
    {
        var cells = new List<string>[columns.Count];
        var height = 1;
        for (var i = 0; i < columns.Count; i++)
        {
            cells[i] = Wrap(Cell(row, i), widths[i]);
            height = Math.Max(height, cells[i].Count);
        }

        for (var line = 0; line < height; line++)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < columns.Count; i++)
            {
                if (i > 0) sb.Append(separator);
                var text = line < cells[i].Count ? cells[i][line] : "";
                sb.Append(Pad(text, widths[i], columns[i].Align));
            }
            writer.WriteLine(sb.ToString().TrimEnd());
        }
    }

    private static string Cell(IReadOnlyList<string> row, int i) => i < row.Count ? row[i] ?? "" : "";

    private static int LongestLine(string text) =>
        text.Split('\n').Max(l => l.TrimEnd('\r').Length);

    private static string Pad(string text, int width, Align align) => align switch
    {
        Align.Right => text.PadLeft(width),
        Align.Center => text.PadLeft((width + text.Length) / 2).PadRight(width),
        _ => text.PadRight(width),
    };

    /// <summary>Word-wraps text to width; explicit newlines are kept and over-long words are split.</summary>
    private static List<string> Wrap(string text, int width)
    {
        var lines = new List<string>();
        foreach (var paragraph in text.Split('\n'))
        {
            var current = new StringBuilder();
            foreach (var word in paragraph.TrimEnd('\r').Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                var w = word;
                if (current.Length > 0 && current.Length + 1 + w.Length <= width)
                {
                    current.Append(' ').Append(w);
                    continue;
                }
                if (current.Length > 0)
                {
                    lines.Add(current.ToString());
                    current.Clear();
                }
                while (w.Length > width)
                {
                    lines.Add(w[..width]);
                    w = w[width..];
                }
                current.Append(w);
            }
            lines.Add(current.ToString());
        }
        return lines;
    }
}
