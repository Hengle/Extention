using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
    public static class MonoBehaviourExtention
    {
        /// <summary>
        /// 协同轮询predicate的结果，直到结果为true，执行callback；
        /// </summary>
        /// <param name="script"></param>
        /// <param name="predicate">断言方法</param>
        /// <param name="callback">回调</param>
        public static void StartCoroutine(this MonoBehaviour script, Func<bool> predicate, Action callback)
        {
            script.StartCoroutine(WaitUntil(predicate, callback));
        }

        /// <summary>
        /// 等待一定时间，然后执行回调
        /// </summary>
        /// <param name="script"></param>
        /// <param name="waittime"></param>
        /// <param name="callback">回调</param>
        public static void StartCoroutine(this MonoBehaviour script, float waittime, Action callback)
        {
            script.StartCoroutine(WaitTime(waittime, callback));
        }

        private static IEnumerator WaitTime(float waittime, Action callback)
        {
            yield return new WaitForSeconds(waittime);
            if (callback != null)
            {
                callback();
            }
        }

        private static IEnumerator WaitUntil(Func<bool> predicate, Action callback)
        {
            yield return new WaitUntil(predicate);
            if (callback != null)
            {
                callback();
            }
        }

        /// <summary>
        /// 取得一个组件，如果没有就添加这个组件
        /// </summary>
        /// <typeparam name="T">目标组件</typeparam>
        /// <param name="monoBehaviour"></param>
        /// <returns>目标组件</returns>
        public static T GetComponentIfNullAdd<T>(this Behaviour monoBehaviour)
            where T : Component
        {
            var com = monoBehaviour.GetComponent<T>();
            if (com == null)
            {
                com = monoBehaviour.gameObject.AddComponent<T>();
            }

            return com;
        }

        /// <summary>
        /// 取得一个组件，如果没有就添加这个组件
        /// </summary>
        /// <typeparam name="T">目标组件</typeparam>
        /// <param name="monoBehaviour"></param>
        /// <param name="isNewAdd">返回是不是新添加的</param>
        /// <returns>目标组件</returns>
        public static T GetComponentIfNullAdd<T>(this Behaviour monoBehaviour, out bool isNewAdd)
            where T : Component
        {
            isNewAdd = false;
            var com = monoBehaviour.GetComponent<T>();
            if (com == null)
            {
                com = monoBehaviour.gameObject.AddComponent<T>();
                isNewAdd = true;
            }

            return com;
        }

        /// <summary>
        /// MonoBehaviour自身和继承的属性名字列表
        /// </summary>
        public static List<string> PropertiesNames = new List<string>()
        {
            "gameObject","tag","name","hideFlags","transform",

            "useGUILayout","enabled","isActiveAndEnabled","runInEditMode",


            "animation","audio","camera","collider","collider2D","constantForce","guiElement",
            "guiText","guiTexture","hingeJoint","light","networkView","particleEmitter",
            "particleSystem","renderer","rigidbody","rigidbody2D",
        };

        public static void Wait(this MonoBehaviour monoscript, AsyncOperation asyncOperation, Action Callback)
        {
            monoscript.StartCoroutine(Func(asyncOperation, Callback));
        }

        static IEnumerator Func(AsyncOperation asyncOperation, Action callback, float waitTime = -1)
        {
            if (asyncOperation != null)
            {
                while (!asyncOperation.isDone)
                {
                    if (waitTime > 0)
                    {
                        yield return new WaitForSeconds(waitTime);
                    }
                    else
                    {
                        yield return new WaitForEndOfFrame();
                    }
                }
            }

            if (callback != null)
            {
                callback.Invoke();
            }

        }

        public static void Wait(this MonoBehaviour monoscript, float waitTime, Action Callback)
        {
            monoscript.StartCoroutine(Func(waitTime, Callback));
        }

        static IEnumerator Func(float waitTime, Action callback)
        {
            yield return new WaitForSeconds(waitTime);

            if (callback != null)
            {
                callback.Invoke();
            }
        }
    }
}
