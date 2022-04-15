using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class2
    {
        Class1 class1 ;

        public Class2(Class1 class1)
        {
            this.class1 = class1;
        }

        public void Hong()
        {

            class1.PrinTing();
        }
    }
}
