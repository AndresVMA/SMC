using SM.Common.Enums;
using System;

namespace SM.Common
{
    public static class EnumUtils
    {
        public static T ToEnum<T>(this string value) where T : struct
        {
            T result;
            if (string.IsNullOrWhiteSpace(value))
            {
                result = default(T);
            }
            
            return Enum.TryParse<T>(value, true, out result)? result : default(T);
        }

        public static GenderType ToGender(this string gender)
        {
            return gender == "M"? GenderType.Male : GenderType.Female;
        } 
    }
}
