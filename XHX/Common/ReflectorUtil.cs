using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XHX.Common
{
    public class ReflectorUtil<T>
    {
        public static bool SetValue(T resourceObject, string PropertyName, object value)
        {
            PropertyInfo property = GetPropertyInfo(resourceObject, PropertyName);
            if (property == null) return false;
            property.SetValue(resourceObject, value, null);
            return true;
        }

        public static object GetValue(T resourceObject, string PropertyName)
        {
            PropertyInfo property = GetPropertyInfo(resourceObject, PropertyName);
            if (property == null) return null;
            return property.GetValue(resourceObject, null);
        }

        private static PropertyInfo GetPropertyInfo(T resourceObject, string PropertyName)
        {
            if (resourceObject == null || PropertyName.Length == 0) return null;
            PropertyInfo result = resourceObject.GetType().GetProperty(PropertyName);
            if (result == null) return null;
            return result;
        }
    }
    public class ReflectorUtil
    {
        public static Assembly GetHttpAssembly(string assemblyName)
        {
            string assemblyPath = String.Empty;
#if DEBUG
            assemblyPath = System.Configuration.ConfigurationManager.AppSettings["DllPath"];
#else
            assemblyPath = System.Configuration.ConfigurationManager.AppSettings["HttpPath"];
#endif

            return Assembly.LoadFrom(string.Format(assemblyPath, assemblyName));
        }
        public static Type GetHttpType(string assemblyName, string className)
        {
            Assembly assembly = null;
            try
            {
                assembly = GetHttpAssembly(assemblyName);
            }
            catch (Exception e)
            {
                return null;
            }

            Type tResult = null;
            foreach (Type classType in assembly.GetTypes())
            {
                if (classType.Name != className) continue;
                tResult = classType;
                break;
            }
            return tResult;
        }
        public static string GetAppSettings(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
