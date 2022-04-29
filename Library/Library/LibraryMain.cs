using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace Library
{
    internal class LibraryMain
    {
        
        static void Main(string[] args)
        {

            //LibraryStart start = new LibraryStart();
            //start.StartProgram();

            while (true)
            {
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^[1-9][0-9]{0,6}?$"))
                    Console.WriteLine("맞음");
                else
                    Console.WriteLine("아님");
            }




        }
    }
}
