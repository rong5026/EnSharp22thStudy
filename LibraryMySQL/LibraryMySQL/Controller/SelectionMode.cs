using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{
    internal class SelectionMode
    {
        LibraryUI UI;
        ConsoleKeyInfo keyInput;

        public SelectionMode(LibraryUI UI)
        {
            this.UI = UI;   
        }





        int menuNumber;

        public int SelectMode(int type)
        {
            
            menuNumber = 1;
             UI.PrintSelectUI(Constants.USER_MODE, type);
            while (Constants.PROGRAM_ON)
            {
                 keyInput = Console.ReadKey(true);
                switch ( keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber = Constants.USER_MODE;
                         UI.PrintSelectUI(Constants.USER_MODE, type);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber = Constants.MANAGE_MODE;
                         UI.PrintSelectUI(Constants.MANAGE_MODE, type);
                        break;
                    case ConsoleKey.Enter:
                        return menuNumber;
                    case ConsoleKey.Escape:
                        return Constants.STOP;
                }
            }
        }

       public int SelectUserOrManagerMenu(string type, int menuCount)
       {
            menuNumber = 0;
            if(type == "User")
                 UI.PrintUserMenuUI(Constants.FIND_BOOK);
            else
                 UI.PrintManagerMenuUI(Constants.FIND_BOOK);
            while (Constants.PROGRAM_ON)
            {
                 keyInput = Console.ReadKey(true);
                switch ( keyInput.Key)
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
                        return Constants.STOP;
                }
            }
       }

    }
}
