﻿using System.Reflection;

namespace CustomTxtParser.Utilities.RuntimeUtilities
{
    public static class CustomObjectCreatorAndSetter
    {
        public static void CreateCustomObjectAndSetToProperty
          (this PropertyInfo propertyInfo, 
            IDictionary<string, string> propNameAndValueDict,object parentObj)
        {
            object newObj = Activator.CreateInstance(propertyInfo.PropertyType);

            if (newObj != null)
            {
                object customObj = propertyInfo
                                   .CreateCustomObject(propNameAndValueDict, newObj);

                propertyInfo?.SetValue(parentObj,
                    Convert.ChangeType
                    (customObj, propertyInfo.PropertyType), null);
            }
        }
    }
}
