using System.Reflection;

namespace CustomTxtParser.Utilities.RuntimeUtilities
{
    public static class PropertyNamespaceChecker
    {
        public static bool IsInNamespace(this PropertyInfo prop,string namespaceName)
        {
            if(prop.PropertyType.FullName == null)
            {
                throw new Exception("Invalid Property");
            }

            if (prop.PropertyType.FullName.Contains(namespaceName))
            {
                return true;
            }
            return false;
        }
    }
}
