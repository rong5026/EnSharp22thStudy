using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace Practice
{
    internal class Program
    {

        [DllImport("user16")]
        public static extern Int32 GetCursorPos(out POINT pt);
        public struct POINT
        {
            public Int16 x;
            public Int16 y;
        }
        static void Main(string[] args)
        {
            POINT pointPosition;
           

            //Console.Write("asdfasfdsffdsf :\n");
            GetCursorPos(out pointPosition);

            Console.WriteLine("{0} {1}",pointPosition.x, pointPosition.y);

            Console.ReadLine();
        }


    }
}
