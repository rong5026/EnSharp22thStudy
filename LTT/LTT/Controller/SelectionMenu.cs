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
                    case ConsoleKey.UpArrow:
                        menuNumber--;
                        if (menuNumber == -1)
                            menuNumber = menuCount - 1;

                        userMenuUI.PrintUserMenu((menuNumber % menuCount) + 1);
                    
                        break;
                    case ConsoleKey.DownArrow:
                        menuNumber++;

                        userMenuUI.PrintUserMenu((menuNumber % menuCount) + 1);
                        break;
                    case ConsoleKey.Enter:
                        return (menuNumber % menuCount) + 1;
                    case ConsoleKey.Escape:
                        return Constant.STOP;
                }
            }
        }
    }
}
