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

    public static ManaCostBuilder Builder() => new ManaCostBuilder();

    public class ManaCostBuilder
    {
        private readonly Dictionary<ManaColor, int> _mana = new();
        private int _colorless;

        public ManaCostBuilder With(ManaColor color, int amount = 1)
        {
            if (!_mana.ContainsKey(color))
            {
                _mana[color] = 0;
            }
            _mana[color] += amount;
            return this;
        }

        public ManaCostBuilder WithColorless(int amount = 1)
        {
            _colorless += amount;
            return this;
        }

        public ManaCost Build() => new ManaCost(_mana, _colorless);
    }

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

    public static ManaCost None { get; } = new ManaCost(new Dictionary<ManaColor, int>(), 0);

    public bool IsNone => _mana.Count == 0 && _colorless == 0;

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

        return stringBuilder.Length == 0 ? "None" : stringBuilder.ToString();
    }


    public static ManaCost Parse(string s, IFormatProvider? provider = null)
    {
        return TryParse(s, provider, out var result) ? result : throw new FormatException($"invalid Mana Cost {s}");
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
                if (!mana.TryGetValue(color, out var value))
                {
                    value = 0;
                    mana[color] = value;
                }

                mana[color] = ++value;
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

