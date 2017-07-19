using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poi;

namespace Test
{
    public class Program
    {
        [Flags]
        public enum TTTTT
        {
            A = 1 << 0,
            B = 1 << 1,
            C = 1 << 2,
            D = 1 << 3,
        }

        static void Main(string[] args)
        {
            
            int a = (int)TTTTT.A;
            int B = (int)TTTTT.B;
            int C = (int)TTTTT.C;
            int D = (int)TTTTT.D;
            TTTTT ttttt = TTTTT.B;
            ttttt = ttttt.AddEnum(TTTTT.C);
            bool RES = ttttt.Contain(TTTTT.C);
            bool RES2 = ttttt.Contain(TTTTT.D);
            ttttt = ttttt.RemoveEnum(TTTTT.B);
            Console.ReadLine();
        }
    }
}
