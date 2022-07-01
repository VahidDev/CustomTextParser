using System.Reflection;

namespace CustomTxtParser.Utilities.RuntimeUtilities
{
    public static class TypeSetterExtension
    {
        public static object ChangeTypeToValueType(this PropertyInfo prop, object value)
            => Convert.ChangeType(value, prop.PropertyType);

        public static object ChangeTypeToNullableType(this PropertyInfo prop, object value)
        {
            Type? t = Nullable.GetUnderlyingType(prop.PropertyType);

            if (t != null)
            {
                return Convert.ChangeType(value, t);
            }
            throw new Exception ("Invalid Type");
        }

        public static object ChangeTypeToEnumType(this PropertyInfo prop, object value)
        {
            return Enum.Parse(prop.PropertyType, value.ToString() ?? 
                throw new Exception ("Invalid value for Enum"));
        }
    }
}
