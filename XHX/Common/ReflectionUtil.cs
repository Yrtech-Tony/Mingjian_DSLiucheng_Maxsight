using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XHX.Common
{
    public static class ReflectionUtil
    {
        public static object GetPropertyValue(object source, string propertyName)
        {
            if (propertyName == string.Empty) return source;
            if (propertyName == null) return null;

            string[] split = propertyName.Split('.');
            if (split.Length <= 0) return null;

            PropertyInfo property = null;

            string tempname = string.Empty;
            foreach (string s in split)
            {
                tempname += s;
                property = source.GetType().GetProperty(s);
                if (property != null)
                    break;
                tempname += ".";
            }

            if (property == null) return null;
            if (tempname == propertyName) return property.GetValue(source, null);

            return GetPropertyValue(property.GetValue(source, null), propertyName.Substring(tempname.Length + 1));
        }

        public static object SetPropertyValue(object source, object value, string propertyName)
        {
            if (propertyName == string.Empty) return source;
            if (propertyName == null) return null;

            string[] split = propertyName.Split('.');
            if (split.Length <= 0) return null;

            PropertyInfo property = null;

            string tempname = string.Empty;
            foreach (string s in split)
            {
                tempname += s;
                property = source.GetType().GetProperty(s);
                if (property != null)
                    break;
                tempname += ".";
            }

            if (property == null) return null;
            if (tempname == propertyName)
            {
                property.SetValue(source, value, null);
                return source;
            }

            return GetPropertyValue(property.GetValue(source, null), propertyName.Substring(tempname.Length + 1));
        }

        public static EndPropertyInfo GetPropertyInfo(object source, string propertyName)
        {

            string[] split = propertyName.Split('.');
            if (split.Length <= 0) return null;

            PropertyInfo propInfo = null;
            object currentObject = source;
            string currentName = String.Empty;
            int lastIndex = split.Length - 1;

            for (int i = 0; i < split.Length; i++)
            {
                currentName = split[i];
                propInfo = currentObject.GetType().GetProperty(currentName);
                if (propInfo == null) return null;
                if (i < lastIndex)
                {
                    currentObject = propInfo.GetValue(currentObject, null);
                    if (currentObject == null) return null;
                }
            }

            EndPropertyInfo endPropInfo = new EndPropertyInfo();
            endPropInfo.Source = currentObject;
            endPropInfo.PropertyInfo = propInfo;

            return endPropInfo;
        }

    }

    public class EndPropertyInfo
    {
        object _source = null;
        PropertyInfo _propertyInfo = null;

        public object Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
            set { _propertyInfo = value; }
        }
    }
}
