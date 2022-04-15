using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        List<int> list;
        Class1 a = new Class1();
        Class1(){
            list = new List<int>();
        }
        public void PrinTing()
        {
            list.Add(1);
            list.Add(2);
            Console.WriteLine(list[0]);
        }
    }
}
