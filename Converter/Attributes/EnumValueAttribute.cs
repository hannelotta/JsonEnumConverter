using System;

namespace Converter.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public string EnumValue;

        public EnumValueAttribute(string enumValue)
        {
            EnumValue = enumValue;
        }
    }
}