using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
 
    internal class SelectionMenu
    {
        int menuNumber;
        int menu;
        int input;
        UserMenuUI userMenuUI = new UserMenuUI();
        //LoginUI loginUI = new LoginUI();
        //Exception exceuption = new Exception();
        ConsoleKeyInfo keyInput;
        public int SelectUserMenu( int menuCount)
        {
            menuNumber = 0;
          
            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow: // 위로가기 키
                        menuNumber=SetMenuNumber(menuNumber, menuCount, "UP");
                        break;
                    case ConsoleKey.DownArrow: // 아래로가기 키
                        menuNumber=SetMenuNumber(menuNumber, menuCount, "DOWN");
                        break;
                    case ConsoleKey.Enter:
                        return (menuNumber % menuCount) + 1;
                    case ConsoleKey.Escape:
                        return Constant.STOP;
                }
            }
        }
        private int SetMenuNumber(int menuNumber,int menuCount, string type)
        {
            input = menuNumber;
            if (type == "UP") { input--; }
            else { input++; }

            if(input == -1)
                input = menuCount - 1;


            userMenuUI.PrintUserMenu((input % menuCount) + 1);

            return input; 
        }
    }
}
