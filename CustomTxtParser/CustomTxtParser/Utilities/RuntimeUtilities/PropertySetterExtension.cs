using System.Reflection;

namespace CustomTxtParser.Utilities.RuntimeUtilities
{
    public static class PropertySetterExtension
    {
        public static void SetPropertyValue<T>
            (this PropertyInfo propertyInfo,T item,object value)
        {
            if (propertyInfo.IsInNamespace(nameof(Nullable)))
            {
                value = propertyInfo.ChangeTypeToNullableType(value);
            }
            else if(propertyInfo.PropertyType.IsEnum)
            {
                value = propertyInfo.ChangeTypeToEnumType(value);
            }
            else 
            {
                value = propertyInfo.ChangeTypeToValueType(value);
            }
            propertyInfo.SetValue(item, value);
        }
    }
}
