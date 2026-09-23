namespace dandan;

public class ManaCostTests
{
    [Theory]
    [InlineData("{R}", 1, 0, 0, 1, 0, 0)]
    [InlineData("{U}{U}", 2, 2, 0, 0, 0, 0)]
    [InlineData("{3}{W}{W}", 5, 0, 0, 0, 2, 0)]
    [InlineData("{1}{W}{B}", 3, 0, 0, 0, 1, 1)]
    [InlineData("{W}{W}{U}{U}{B}{B}{R}{R}{G}{G}", 10, 2, 2, 2, 2, 2)]
    [InlineData("{15}", 15, 0, 0, 0, 0, 0)]
    public void Parse_ParsesPublishedCardManaCosts(
        string manaCostText,
        int expectedTotalMana,
        int expectedBlue,
        int expectedGreen,
        int expectedRed,
        int expectedWhite,
        int expectedBlack)
    {
        var manaCost = ManaCost.Parse(manaCostText, null);

        Assert.Equal(expectedTotalMana, manaCost.TotalMana);
        Assert.Equal(expectedBlue, manaCost.CostForColor(ManaColor.Blue));
        Assert.Equal(expectedGreen, manaCost.CostForColor(ManaColor.Green));
        Assert.Equal(expectedRed, manaCost.CostForColor(ManaColor.Red));
        Assert.Equal(expectedWhite, manaCost.CostForColor(ManaColor.White));
        Assert.Equal(expectedBlack, manaCost.CostForColor(ManaColor.Black));
        Assert.Equal(expectedBlue == 0 && expectedGreen == 0 && expectedRed == 0 && expectedWhite == 0 && expectedBlack == 0, manaCost.IsColorless);
    }
}
