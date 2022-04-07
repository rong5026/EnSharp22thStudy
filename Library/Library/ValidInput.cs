using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library
{
    internal class ValidInput
    {
        //private string id;
       // private string password;
        //private string name;
        //private int age;
        //private int number;
        //private string address;

        string stringInput;
        int integerInput;
        bool check;
        Regex regex;

        string id;
        string password;


        public string EnterId()
        {
            Console.SetCursorPosition(17, 5);
            id = Console.ReadLine();
            check = Regex.IsMatch(id, @"^[0-9a-zA-Z]{8,10}$");

            if (!check)
                return EnterId();
            return id;
        }
    }
}
