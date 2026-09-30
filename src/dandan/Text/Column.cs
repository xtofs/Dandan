namespace dandan.Text;

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
