namespace dandan.Text;

/// <summary>What a table looks like: its columns, output format and (plain format) column separator.</summary>
public sealed record TableSpec(IReadOnlyList<Column> Columns, TableFormat Format = TableFormat.Plain)
{
    // public TableFormat Format { get; init; } = TableFormat.Plain;
    public string Separator { get; init; } = " ";

    /// <summary>Convenience for unformatted, left-aligned columns.</summary>
    public static TableSpec FromHeaders(params string[] headers) =>
        new(headers.Select(h => (Column)h).ToArray());
}
