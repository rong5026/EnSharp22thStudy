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
        LibraryUI UI = new LibraryUI();
    
        int menuNumber;

        public int SelectMode(int type)
        {
            
            menuNumber = 1;
            UI.PrintSelectUI(Const.USER_MODE, type);
            while (Const.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber = Const.USER_MODE;
                        UI.PrintSelectUI(Const.USER_MODE, type);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber = Const.MANAGE_MODE;
                        UI.PrintSelectUI(Const.MANAGE_MODE, type);
                        break;
                    case ConsoleKey.Enter:
                        return menuNumber;
                    case ConsoleKey.Escape:
                        return Const.STOP;
                }
            }
        }

       public int SelectUserOrManagerMenu(string type, int menuCount)
       {
            menuNumber = 0;
            if(type == "User")
                UI.PrintUserMenuUI(Const.FIND_BOOK);
            else
                UI.PrintManagerMenuUI(Const.FIND_BOOK);
            while (Const.PROGRAM_ON)
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
                        return Const.STOP;
                }
            }
       }

    }
}
