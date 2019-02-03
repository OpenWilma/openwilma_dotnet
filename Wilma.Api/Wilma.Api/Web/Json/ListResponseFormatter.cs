using System;
using System.Reflection;
using System.Collections.Generic;

using Utf8Json;

namespace Wilma.Api.Web.Json
{
    public class WilmaListFormatter<T> : IJsonFormatter<IList<T>> 
        where T : class
    {
        public void Serialize(ref JsonWriter writer, IList<T> value, IJsonFormatterResolver formatterResolver)
        {
            throw new NotImplementedException();
        }

        public IList<T> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull()) return null;

            if (!reader.ReadIsBeginArray())
            {
                reader.ReadIsBeginObjectWithVerify();
                string key = reader.ReadPropertyName();
                
                reader.ReadIsBeginArrayWithVerify();
            }

            IList<T> list = new List<T>(); //TODO: Allocate som here already?
            var formatter = formatterResolver.GetFormatterWithVerify<T>();
            
            int count = 0;
            while (!reader.ReadIsEndArrayWithSkipValueSeparator(ref count))
            {
                list.Add(formatter.Deserialize(ref reader, formatterResolver));
            }
            return list;
        }
    }

    public sealed class WilmaListResolver : IJsonFormatterResolver
    {
        public static readonly IJsonFormatterResolver Instance = new WilmaListResolver();
        
        WilmaListResolver()
        { }

        public IJsonFormatter<T> GetFormatter<T>() 
            => FormatterCache<T>.formatter;

        static class FormatterCache<T>
        {
            public static readonly IJsonFormatter<T> formatter;

            static FormatterCache()
            {
                Type type = typeof(T);
                TypeInfo info = type.GetTypeInfo();
                
                if (type.IsGenericType && 
                    info.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    Type formatterType = typeof(WilmaListFormatter<>).MakeGenericType(info.GenericTypeArguments);
                    formatter = (IJsonFormatter<T>)Activator.CreateInstance(formatterType);
                }
            }
        }
    }
}
