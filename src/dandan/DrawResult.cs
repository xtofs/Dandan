namespace dandan;

public class DrawResult(IReadOnlyList<Card> drawn)
{
    private readonly IReadOnlyList<Card> _drawn = drawn;


    public IReadOnlyList<Card> Cards => _drawn;
}
