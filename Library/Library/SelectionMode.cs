using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library
{
    internal class SelectionMode
    {
        ConsoleKeyInfo keyInput;

        const int FIND_BOOK = 1;
        const int USER_MODE = 1;
        const int MANAGE_MODE = 2;
        const int STOP = -1;
        LibraryUI UI = new LibraryUI();
        const Boolean PROGRAM_ON = true;
        int menuNumber;

        public int SelectMode(int type)
        {
            
            menuNumber = 1;
            UI.PrintSelectUI(USER_MODE, type);
            while (PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber = USER_MODE;
                        UI.PrintSelectUI(USER_MODE, type);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber = MANAGE_MODE;
                        UI.PrintSelectUI(MANAGE_MODE, type);
                        break;
                    case ConsoleKey.Enter:
                        return menuNumber;
                    case ConsoleKey.Escape:
                        return STOP;
                }
            }
        }

       public int SelectUserMenu()
       {
            menuNumber = 0;
            UI.PrintUserMenuUI(FIND_BOOK);

            while (PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber--;
                        if (menuNumber == -1)
                            menuNumber = 3;                
                        UI.PrintUserMenuUI((menuNumber % 4) + 1);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber++;                  
                        UI.PrintUserMenuUI((menuNumber % 4) + 1);
                        break;
                    case ConsoleKey.Enter:
                        return (menuNumber % 4) + 1;
                    case ConsoleKey.Escape:
                        return STOP;
                }
            }
        }
    }
}
