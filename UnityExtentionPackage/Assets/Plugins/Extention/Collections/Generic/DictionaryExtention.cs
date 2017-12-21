using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// 字典扩展
    /// </summary>
    public static class DictionaryExtention
    {
        /// <summary>
        /// 通过线程池异步移除一个元素
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="idic"></param>
        /// <param name="key"></param>
        public static void RemoveInForeach<K,V>(this IDictionary<K,V> idic, K key)
        {
            Threading.ThreadPool.QueueUserWorkItem((obj) =>
            {
                lock (idic)
                {
                    idic.Remove(key);
                }
            });
        }

        /// <summary>
        /// 通过线程池异步添加一个元素
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="idic"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="overlay">如果含有Key，当overlay=true，覆盖当前值，当overlay=false，放弃当前add</param>
        public static void AddInForeach<K, V>(this IDictionary<K, V> idic, K key,V value,bool overlay = true)
        {
            Threading.ThreadPool.QueueUserWorkItem((obj) =>
            {
                lock (idic)
                {
                    if (overlay)
                    {
                        idic[key] = value;
                    }
                    else
                    {
                        if (idic.ContainsKey(key))
                        {
                            return;
                        }
                        idic[key] = value;
                    } 
                }
            });
        }

        /// <summary>
        /// 交换引用
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="idic"></param>
        /// <param name="idic2"></param>
        [Obsolete("不好使，不知道为什么",true)]
        public static void ExchangeTo<K, V>(this IDictionary<K, V> idic,
            IDictionary<K, V> idic2)
        {
            var temp = idic;
            idic = idic2;
            idic2 = temp;
        }

        /// <summary>
        /// 交换引用
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="idic"></param>
        /// <param name="idic2"></param>
        public static void Exchange<K, V> (ref Dictionary<K, V> idic,
           ref Dictionary<K, V> idic2)
        {
            var temp = idic;
            idic = idic2;
            idic2 = temp;
        }
    }
}
