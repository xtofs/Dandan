namespace dandan;

using System.Text.Json;
using System.Text.Json.Serialization;

internal sealed class ManaCostJsonConverter : JsonConverter<ManaCost?>
{
    public override ManaCost? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var manaCostText = reader.GetString();
        return string.IsNullOrEmpty(manaCostText) ? null : ManaCost.Parse(manaCostText, null);
    }

    public override void Write(Utf8JsonWriter writer, ManaCost? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString() ?? string.Empty);
    }
}
