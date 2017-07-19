using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 值扩展
    /// </summary>
    public static class StructExtention
    {
        /// <summary>
        /// 返回不出界的一个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cur"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T ClampIn<T>(this T cur,T min,T max) where T:struct
        {
            dynamic tempcur = cur;
            dynamic tempmin = min;
            dynamic tempmax = max;
            if (tempmin == tempmax) return min;
            if (tempmin > tempmax)
            {
                var temp = tempmin;
                tempmin = tempmax;
                tempmax = temp;
            }

            if (tempcur < min) return min;
            if (tempcur > max) return max;
            return cur;
        }
    }
}
