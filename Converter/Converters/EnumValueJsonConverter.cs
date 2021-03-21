using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Converter.Attributes;

namespace Converter.Converters
{
    public class EnumValueJsonConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        public override bool HandleNull => base.HandleNull;

        public override bool CanConvert(Type typeToConvert)
        {
            return base.CanConvert(typeToConvert);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            MemberInfo[] memberInfos = type.GetMember(value.ToString());
            MemberInfo enumValueMemberInfo = memberInfos.Single(memberInfos => memberInfos.DeclaringType == type);

            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumValueAttribute), false);

            foreach (var valueAttribute in valueAttributes)
            {
                if (valueAttribute is EnumValueAttribute enumValueAttribute)
                {
                    writer.WriteStringValue(enumValueAttribute.EnumValue.ToString());
                    return;
                }
            }

            writer.WriteStringValue(options.PropertyNamingPolicy?.ConvertName(value.ToString()) ?? value.ToString());
        }
    }
}