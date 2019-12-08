using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsInDetails
{
    // class that contains extention method IsNull()
    public static class ExtentionMethods
    {
        /// <summary>
        /// Finds out whether source(nullable value type) is null or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this Nullable<T> source) where T : struct
        {
            return source == null;
        }
        /// <summary>
        /// Finds out whether source(ref type) is null or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T source) where T : class
        {
            return source == null;
        }

    }
}