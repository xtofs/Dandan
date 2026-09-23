namespace dandan;

public enum ManaColor { Red, Blue, Green, White, Black }

public static class ManaColorExtensions
{
    public static string ToSymbol(this ManaColor color) => color switch
    {
        ManaColor.Red => "R",
        ManaColor.Blue => "U",
        ManaColor.Green => "G",
        ManaColor.White => "W",
        ManaColor.Black => "B",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    extension(ManaColor)
    {
        public static bool TryCreateFromSymbol(string symbol, out ManaColor color)
        {
            switch (symbol)
            {
                case "R": color = ManaColor.Red; return true;
                case "U": color = ManaColor.Blue; return true;
                case "G": color = ManaColor.Green; return true;
                case "W": color = ManaColor.White; return true;
                case "B": color = ManaColor.Black; return true;
                default: color = default; return false;
            }
        }
    }
}
