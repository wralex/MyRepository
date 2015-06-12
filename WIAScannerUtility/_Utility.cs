using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WIAUtility
{
    internal static class _Utility
    {
        public static TCustomAttr ExtractAttribute<TCustomAttr, TEnum>(this TEnum instance)
        {
            if (instance != null)
            {
                try 
                {
                    FieldInfo fieldInfo = instance.GetType().GetField(instance.ToString());
                    var attributes = fieldInfo.GetCustomAttributes(typeof(TCustomAttr), false).ToList();
                    if (attributes.Any())
                        return (TCustomAttr)attributes[0];
                }
                catch { }
            }
            return default(TCustomAttr);
        }

        public static string GetDescriptionAttributeValue<T>(T value)
        {
            return ExtractAttribute<DescriptionAttribute, T>(value).Description;
        }
    }
}
