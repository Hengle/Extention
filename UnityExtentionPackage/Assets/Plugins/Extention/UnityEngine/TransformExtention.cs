using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
    public static class TransformExtention
    {
        /// <summary>
        /// 递归查找一个子transform
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Transform FindFisrtChildInAll(this Transform trans,string name)
        {
            return Recursive(trans,name);
        }

        /// <summary>
        /// 递归查找
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        static Transform Recursive(Transform trans,string name)
        {
            for (int i = 0; i < trans.childCount; i++)
            {
                var tempchild = trans.GetChild(i);
                if (tempchild.name == name)
                {
                    return tempchild;
                }
                else
                {
                    var res =  Recursive(tempchild,name);
                    if (res)
                    {
                        return res;
                    }
                }
            }
            return null;
        }
    }
}
