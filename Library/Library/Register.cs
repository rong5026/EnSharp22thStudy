using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Register
    {
        LibraryUI UI = new LibraryUI();
        ValidInput validInput = new ValidInput();
        ConsoleKeyInfo keyInput;
        string id;
        string password;
        string name;
        string age;
        string phoneNumber;
        string address;



        public bool UserRegister()
        {

            Console.Clear();
            UI.PrintRegister();
            Console.SetCursorPosition(38, 7);
            keyInput = Console.ReadKey(true);

            if (keyInput.Key == ConsoleKey.Escape)
                return false; // ESC 누르면 뒤로가기 
            else
            {
                id = validInput.EnterIdOrPassword(38,7);
                password = validInput.EnterIdOrPassword(38, 8);
                password = validInput.EnterIdOrPassword(38, 9);
                name = validInput.EnterUserName();
                age = validInput.EnterUserAge();
                phoneNumber = validInput.EnterUserPhoneNumber();
                address = validInput.EnterUserAddress();

            }
           

            return true;
        }
    }
}
