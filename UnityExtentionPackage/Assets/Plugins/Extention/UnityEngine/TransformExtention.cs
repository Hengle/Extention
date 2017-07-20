using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
    public static class TransformExtention
    {
        /// <summary>
        /// 重置local Vector3.zero Quaternion.identity Vector3.one
        /// </summary>
        /// <param name="trans"></param>
        public static void ResetLocal(this Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }

        /// <summary>
        /// 重置位置和旋转
        /// </summary>
        /// <param name="trans"></param>
        public static void ResetPosAndRot(this Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
        }

        public static void ResetLocal(this Transform trans, Vector3 csale)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = csale;
        }

        /// <summary>
        /// 位置重合
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="tar"></param>
        public static void Apply(this Transform trans, Transform tar)
        {
            if (tar)
            {
                trans.position = tar.position;
                trans.eulerAngles = tar.eulerAngles;
                trans.localScale = tar.localScale;
            }
        }

        public static void ApplyRotationY(this Transform trans, Transform tar)
        {
            if (tar)
            {
                trans.eulerAngles = new Vector3(trans.eulerAngles.x,
                    tar.eulerAngles.y,
                    trans.eulerAngles.z);
            }
        }

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
