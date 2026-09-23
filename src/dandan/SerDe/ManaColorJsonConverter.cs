namespace dandan.SerDe;

using System.Text.Json;
using System.Text.Json.Serialization;

internal sealed class ManaColorJsonConverter : JsonConverter<ManaColor>
{
    public override ManaColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var symbol = reader.GetString();
        return symbol is not null && ManaColor.TryCreateFromSymbol(symbol, out var color)
            ? color
            : throw new JsonException($"'{symbol}' is not a valid mana color symbol.");
    }

    public override void Write(Utf8JsonWriter writer, ManaColor value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToSymbol());
    }
}
