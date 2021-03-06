﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Xml.Linq
{
    /// <summary>
    /// 对xml.linq的扩展
    /// </summary>
    public static class XMLExtention
    {
        /// <summary>
        /// 自动填充属性。将xml元素的属性自动赋值给目标的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_cfg"></param>
        /// <param name="_instance">要填充的目标实例。静态字段参数可为null</param>
        public static void AutoFullPropertiesByAttribute<T>(this XElement _cfg, T _instance)
        {
            var collection = typeof(T).GetProperties();
            foreach (var item in collection)
            {
                XAttribute _temp = _cfg.Attribute(item.Name);

                try
                {
                    if (item.CanWrite)
                    {
                        if (_temp == null)
                        {
                            continue;
                        }
                        else
                        {
                            item.SetValue(_instance, Convert.ChangeType(_temp.Value, item.PropertyType), null);
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 自动填充属性。将xml元素的第一个同名子元素的值自动赋值给目标的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_cfg"></param>
        /// <param name="_instance">要填充的目标实例。静态字段参数可为null</param>
        public static void AutoFullPropertiesByElement<T>(this XElement _cfg, T _instance)
        {
            var collection = typeof(T).GetProperties();
            foreach (var item in collection)
            {
                XElement _temp = _cfg.Element(item.Name);

                try
                {
                    if (item.CanWrite)
                    {
                        if (_temp == null)
                        {
                            continue;
                        }
                        else
                        {
                            item.SetValue(_instance, Convert.ChangeType(_temp.Value, item.PropertyType), null);
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
