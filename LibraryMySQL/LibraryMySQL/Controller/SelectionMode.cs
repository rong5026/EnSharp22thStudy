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
   
        int menuNumber;
        UserModeUI userModeUI = new UserModeUI();
        LibraryUI libraryUI = new LibraryUI();
        ConsoleKeyInfo keyInput;

        public int SelectMode(int type)
        {
            
            menuNumber = 1;
            libraryUI.PrintSelectUI(Constants.USER_MODE, type);
            while (Constants.PROGRAM_ON)
            {
               keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber = Constants.USER_MODE;
                        libraryUI.PrintSelectUI(Constants.USER_MODE, type);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber = Constants.MANAGE_MODE;
                        libraryUI.PrintSelectUI(Constants.MANAGE_MODE, type);
                        break;
                    case ConsoleKey.Enter:
                        return menuNumber;
                    case ConsoleKey.Escape:
                        return Constants.STOP;
                }
            }
        }

       

    }
}
