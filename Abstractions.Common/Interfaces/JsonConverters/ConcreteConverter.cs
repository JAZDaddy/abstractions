using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Common.JsonConverters
{
    /// <summary>
    /// A type converter which is used to decorate interface properties on JSON serializable classes
    /// which allows the class author to map the interface to a concrete instance at deserialization.
    /// </summary>
    /// <typeparam name="T">The type to instantiate when the interface property is deserialized from JSON.</typeparam>
    public class ConcreteConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader,
         Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
