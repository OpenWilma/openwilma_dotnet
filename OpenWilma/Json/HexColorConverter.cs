using System;
using System.Drawing;
using System.Text.Json;
using System.Globalization;
using System.Text.Json.Serialization;

namespace OpenWilma.Json
{
    public class HexColorConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ReadOnlySpan<char> hex = reader.GetString();

            return Color.FromArgb(
                int.Parse(hex[1..2], NumberStyles.HexNumber),
                int.Parse(hex[3..4], NumberStyles.HexNumber), 
                int.Parse(hex[5..6], NumberStyles.HexNumber));
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
