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

       public int SelectUserOrManagerMenu(string type, int menuCount)
       {
            menuNumber = 0;
            if(type == "User")
                UI.PrintUserMenuUI(FIND_BOOK);
            else
                UI.PrintManagerMenuUI(FIND_BOOK);
            while (PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber--;
                        if (menuNumber == -1)
                            menuNumber = menuCount-1;
                        if (type == "User")
                            UI.PrintUserMenuUI((menuNumber % menuCount) + 1);
                        else
                            UI.PrintManagerMenuUI((menuNumber % menuCount) + 1);                 
                        break;
                    case ConsoleKey.DownArrow:
                        menuNumber++;
                        if (type == "User")
                            UI.PrintUserMenuUI((menuNumber % menuCount) + 1);
                        else
                            UI.PrintManagerMenuUI((menuNumber % menuCount) + 1);
                        break;
                    case ConsoleKey.Enter:
                        return (menuNumber % menuCount) + 1;
                    case ConsoleKey.Escape:
                        return STOP;
                }
            }
       }

    }
}
