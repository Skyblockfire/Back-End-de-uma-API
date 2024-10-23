using System;
using System.ComponentModel;
using System.Reflection;

namespace BackEnd.Enums
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo descricao = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])descricao.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else if (attributes == null)
            {
                return value.ToString();
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
