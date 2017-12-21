using System;
using System.Diagnostics;

namespace UnityEngine
{
    public class PoiLog
    {
        [Conditional("UNITY_EDITOR"), Conditional("DEBUG"), Conditional("DEVELOPMENT_BUILD")]
        public static void Log(object message)
        {
            Debug.Log(message);
        }
    }
}