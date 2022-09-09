using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

using OpenWilma.Json;

namespace OpenWilma.Tests.Json;

public sealed class HexColorConverterTests
{
    internal sealed class ColorContainer
    {
        [JsonConverter(typeof(HexColorConverter))]
        public Color Color { get; set; }
    }

    [Fact]
    public void Deserialize_IsCorrect()
    {
        const string json = "{\"Color\":\"#AABBCC\"}";
        var result = JsonSerializer.Deserialize<ColorContainer>(json);

        Assert.NotNull(result);
        Assert.Equal(Color.FromArgb(0xFF, 0xAA, 0xBB, 0xCC), result!.Color);
    }
}