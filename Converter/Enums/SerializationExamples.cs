using System.Text.Json.Serialization;
using Converter.Converters;
using Converter.Attributes;

namespace Converter.Enums
{
    [JsonConverter(typeof(EnumValueJsonConverter<SerializationExamples>))]
    public enum SerializationExamples
    {
        CamelCase,
        [EnumValue("PascalCase")]
        PascalCase,
        [EnumValue("snake_case")]
        SnakeCase,
        [EnumValue("customized-enum-string")]
        Test
    }
}