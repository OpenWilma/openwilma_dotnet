using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Wilma.Api.Json
{
    public class NestedArrayConverter<T> : JsonConverter<IEnumerable<T>> 
        where T : new()
    {
        public override IEnumerable<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //Consume tokens until start of an array, this hack is to skip annoying nested array objects
            while (reader.Read() && reader.TokenType != JsonTokenType.StartArray) ;

            var list = new List<T>();
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                list.Add(JsonSerializer.Deserialize<T>(ref reader, options));
            }
            //Consume end array
            reader.Read();
            return list;
        }

        public override void Write(Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}
