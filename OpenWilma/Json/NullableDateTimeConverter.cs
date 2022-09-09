using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWilma.Json;

internal sealed class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        DateTime.TryParse(reader.GetString(), out DateTime value);
        return value;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        => throw new NotImplementedException();
}
