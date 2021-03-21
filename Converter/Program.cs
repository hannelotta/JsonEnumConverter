using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Converter.Attributes;
using Converter.Converters;
using Converter.Enums;

namespace Converter
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serializationOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var objectToSerialize = new MyObject
            {
                CustomEnum = SerializationExamples.Test,
                Example1 = SerializationExamples.CamelCase,
                Example2 = SerializationExamples.PascalCase,
                Example3 = SerializationExamples.SnakeCase
            };

            var serializedResult = JsonSerializer.Serialize(objectToSerialize, serializationOptions);

            Console.WriteLine(serializedResult.ToString());
        }
    }

    public class MyObject
    {
        public SerializationExamples Example1 { get; init; }
        public SerializationExamples Example2 { get; init; }
        public SerializationExamples Example3 { get; init; }
        public SerializationExamples CustomEnum { get; init; }
    }
}
