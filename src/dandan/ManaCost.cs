namespace dandan;

using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text;


/// <summary>
/// Represents the mana cost of a card.
/// <see href="https://magic.wizards.com/en/rules"/> 202. Mana Cost and Color
/// </summary>
public readonly struct ManaCost(IReadOnlyDictionary<ManaColor, int> mana, int colorless) : IParsable<ManaCost>
{
    private readonly FrozenDictionary<ManaColor, int> _mana = mana.ToFrozenDictionary();

    private readonly int _colorless = colorless;

    public bool IsMulticolored => _mana.Count > 1;

    // An object with a mana cost of {2}{W} is white

    public bool IsColor(ManaColor color) => _mana.ContainsKey(color);

    public int CostForColor(ManaColor color) => _mana.TryGetValue(color, out var cost) ? cost : 0;

    //, an object with a mana cost of {2} is colorless
    public bool IsColorless => _mana.Count == 0;

    // one with a mana cost of {2}{W}{B} is both white and black
    public ISet<ManaColor> Colors => _mana.Keys.ToHashSet();

    public int TotalMana => _mana.Values.Sum() + _colorless;

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        if (_colorless > 0)
        {
            stringBuilder.Append($"{{{_colorless}}}");
        }

        foreach (var kvp in _mana)
        {
            for (var i = 0; i < kvp.Value; i++)
            {
                stringBuilder.Append($"{{{kvp.Key.ToSymbol()}}}");
            }
        }

        return stringBuilder.ToString();
    }


    public static ManaCost Parse(string s, IFormatProvider? provider)
    {
        return TryParse(s, provider, out var result) ? result : throw new FormatException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ManaCost result)
    {
        result = default;
        if (string.IsNullOrWhiteSpace(s))
        {
            return false;
        }

        var mana = new Dictionary<ManaColor, int>();
        var colorless = 0;
        var i = 0;
        while (i < s.Length)
        {
            if (s[i] != '{')
            {
                return false;
            }

            var j = s.IndexOf('}', i);
            if (j == -1)
            {
                return false;
            }

            var token = s.Substring(i + 1, j - i - 1);
            if (int.TryParse(token, out var c))
            {
                colorless += c;
            }
            else if (ManaColor.TryCreateFromSymbol(token, out var color))
            {
                if (!mana.ContainsKey(color))
                {
                    mana[color] = 0;
                }

                mana[color]++;
            }
            else
            {
                return false;
            }
            i = j + 1;
        }
        result = new ManaCost(mana, colorless);
        return true;
    }
}

