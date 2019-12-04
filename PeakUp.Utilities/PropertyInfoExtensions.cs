using System.ComponentModel;
using System.Reflection;

namespace PeakUp.Utilities
{
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Get description attribute value of property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetDescription(this PropertyInfo prop)
        {
            object[] attrs = prop.GetCustomAttributes(true);

            foreach (object attr in attrs)
            {
                var descriptionAttr = attr as DescriptionAttribute;
                if (descriptionAttr != null)
                    return descriptionAttr.Description;
            }

            return string.Empty;
        }
    }
}
