# EnumValueJsonConverter for System.Text.Json

Simple generic enum converter for serializing custom enum values using System.Text.Json.

Requires .NET Core 5.

```
dotnet --version
5.0.103
```

## Examples

By default, values are serialized with camel case naming policy:

```
var serializationOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};
```

Define an enum and specify a `JsonConverter` of type `EnumValueJsonConverter` which uses the enum. Add `EnumValue` attribute to set the enum string:

```
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
```
Object should have its enum properties serialized:

```
dotnet run
{
  "example1": "camelCase",
  "example2": "PascalCase",
  "example3": "snake_case",
  "customEnum": "customized-enum-string"
}
```