using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Poi
{
    public class PDebug
    {
        [Conditional("LogMsg")]
        public static void Log(object message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}
