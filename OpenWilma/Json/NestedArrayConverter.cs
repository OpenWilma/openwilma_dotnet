using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWilma.Json;

internal sealed class NestedArrayConverter<T> : JsonConverter<IEnumerable<T>>
{
    public override IEnumerable<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Consume tokens until start of an array, this hack is to skip annoying nested array objects
        while (reader.Read() && reader.TokenType != JsonTokenType.StartArray) ;

        var list = new List<T>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(JsonSerializer.Deserialize<T>(ref reader, options));
        }

        // Consume JsonTokenType.EndArray
        reader.Read();
        return list;
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
        => throw new NotSupportedException();
}
