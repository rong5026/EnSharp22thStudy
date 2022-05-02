using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{
    internal class LibraryMain
    {            
        static void Main(string[] args)
        {
            LibraryStart start = new LibraryStart();
            start.StartLibrary();

            /*while (true) {

                string n = Console.ReadLine();
                if (Regex.IsMatch(n, @"^([a-zA-Zㄱ-ㅎ가-힣0-9!?+-]{1,}\s{0,}){0,}[a-zA-Zㄱ-ㅎ가-힣0-9!?+-]{1,}$"))
                    Console.WriteLine("맞음");
                else
                            Console.WriteLine("틀림");

            }*/
           
        }
    }
}
