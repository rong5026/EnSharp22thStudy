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
        LibraryUI libraryUI;
        ConsoleKeyInfo keyInput;

        public SelectionMode()
        {
            libraryUI = new LibraryUI();

        }
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
        public int SelectUserManagerMenu(string type, int menuCount) // 유저메뉴, 관리자 메뉴 상하 이동
        {
            menuNumber = 0;
            if (type == "User")
                libraryUI.PrintUserMenuUI(Constants.FIND_BOOK);
    
            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber--;
                        if (menuNumber == -1)
                            menuNumber = menuCount - 1;
                        if (type == "User")
                            libraryUI.PrintUserMenuUI((menuNumber % menuCount) + 1);
                     
                        break;
                    case ConsoleKey.DownArrow:
                        menuNumber++;
                        if (type == "User")
                            libraryUI.PrintUserMenuUI((menuNumber % menuCount) + 1);
                     
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
