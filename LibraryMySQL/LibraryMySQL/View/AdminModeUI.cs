using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminModeUI
    {

        public void PrintAdminMenuMessage(string message)
        {
            Console.WriteLine("                                     ■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("                                     ■                                                ■");
            Console.WriteLine("                                     ■                                                ■");
            Console.WriteLine("                                     ■                     {0}                   ■", message);
            Console.WriteLine("                                     ■                                                ■");
            Console.WriteLine("                                     ■                                                ■");
            Console.WriteLine("                                     ■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("                                            ENTER : 확인          ESC : 뒤로가기  ");

        }

    }
}
