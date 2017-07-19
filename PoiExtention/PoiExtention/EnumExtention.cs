using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 对枚举类的扩展
    /// </summary>
    public static class EnumExtention
    {
        #region 对含有Flags属性的枚举提供位域（即一组标志）处理扩展

        /// <summary>
        /// 检查是否有FlagsAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static bool CheckFlags<T>() where T : struct
        {
            bool result = Attribute.GetCustomAttribute(typeof(T), typeof(FlagsAttribute)) != null;
            if (!result)
            {
                throw new ArgumentException("类型不含有FlagsAttribute");
            }
            return result;
        }

        /// <summary>
        /// 检查枚举值中是否包含另一个枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original">通常我们所使用的组标志</param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Contain<T>(this T original,T target)
            where T:struct
        {
            if (typeof(T).IsEnum && CheckFlags<T>())
            {
                dynamic tempori = original;
                bool res = (tempori & target) == target;
                return res;
            }
            else
            {
                ///如果不是枚举类直接返回false
                return false;
            }
        }

        /// <summary>
        /// 在枚举值中添加一个另一个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <param name="target"></param>
        /// <returns>返回组合枚举值</returns>
        public static T AddEnum<T>(this T original,T target) where T:struct
        {
            if (typeof(T).IsEnum && CheckFlags<T>())
            {
                dynamic tempori = original;
                tempori |= target;
                return (T)tempori;
            }
            throw new ArgumentException("参数不是枚举类型");
        }

        /// <summary>
        /// 在枚举值中移除一个另一个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <param name="target"></param>
        /// <returns>返回组合枚举值</returns>
        public static T RemoveEnum<T>(this T original, T target) where T : struct
        {
            if (typeof(T).IsEnum && CheckFlags<T>())
            {
                dynamic tempori = original;
                dynamic temptar = target;
                tempori &= ~temptar;
                return (T)tempori;
            }
            throw new ArgumentException("参数不是枚举类型");
        }

        /// <summary>
        /// 在枚举值中添加一个另一个值,会改变original自身的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original">通常我们所使用的组标志</param>
        /// <param name="target"></param>
        public static void Add<T>(ref T original, T target)
            where T : struct
        {
            if (typeof(T).IsEnum && CheckFlags<T>())
            {
                long ori = Convert.ToInt64(original);
                long tar = Convert.ToInt64(target);
                ori |= tar;
                original = (T)Enum.ToObject(typeof(T),ori);
            }
        }

        /// <summary>
        /// 在枚举值中移除一个另一个值,会改变original自身的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original">通常我们所使用的组标志</param>
        /// <param name="target"></param>
        public static void Remove<T>(ref T original, T target)
            where T : struct
        {
            if (typeof(T).IsEnum && CheckFlags<T>())
            {
                long ori = Convert.ToInt64(original);
                long tar = Convert.ToInt64(target);
                ori &= ~tar;
                original = (T)Enum.ToObject(typeof(T), ori);
            }
        }

        #endregion
    }
}
