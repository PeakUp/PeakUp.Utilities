using System;
using System.ComponentModel;
using System.Reflection;

namespace PeakUp.Utilities
{
    public static class EnumExtensions
    {

        /// <summary>
        /// Gets value of enum description attribute
        /// </summary>
        /// <param name="value">Enum</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return value.ToString();
        }

    }
}
