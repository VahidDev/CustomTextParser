using CustomTxtParser.Services.Abstraction;
using CustomTxtParser.Utilities.RuntimeUtilities;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CustomTxtParser.Services.Implementation
{
    public class RuntimeServices : IRuntimeServices
    {
        public T CreateCustomObject<T>(IDictionary<string, string> propNameAndValueDict)
        {
            T obj = Activator.CreateInstance<T>();
            IReadOnlyCollection<PropertyInfo> allProprs = typeof(T)
                .GetProperties()
                .ToList();

            foreach (PropertyInfo prop in allProprs)
            {
                // Ignore if prop doesn't have DisplayAttribute
                if (prop.GetCustomAttribute<DisplayAttribute>() == null)
                    continue;
                
                if (prop.IsInNamespace(nameof(DomainModels)) && !prop.PropertyType.IsEnum)
                {
                    if (obj != null)
                    {
                        prop.CreateCustomObjectAndSetToProperty
                            (propNameAndValueDict, obj);
                    }
                }
                else
                {
                    prop.SetPropertyValue<T>(obj,
                        propNameAndValueDict.FirstOrDefault(p => p.Key
                        == prop.GetCustomAttribute<DisplayAttribute>()?.Name).Value);
                }
            }
            return obj;
        }
    }
}
