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
   
      
        UserModeUI userModeUI;
        LibraryUI libraryUI;
        ConsoleKeyInfo keyInput;
        private int menuNumber;
        public SelectionMode(LibraryUI libraryUI)
        {
            this.libraryUI  = libraryUI;
            userModeUI = new UserModeUI();
        }
        public int SelectMode(int type)
        {
            
            menuNumber = 1;
            libraryUI.PrintSelectUI(Constants.USER_MODE, type);
            while (Constants.isPROGRAM_ON)
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
        public int SelectUserManagerMenu(string menuType, int menuCount) // 유저메뉴, 관리자 메뉴 상하 이동
        {
            menuNumber = 0;
            if (menuType == "User")
                libraryUI.PrintUserMenuUI(Constants.FIND_BOOK);
            else if(menuType == "Edit")




            Console.CursorVisible = false;
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber--;
                        if (menuNumber == -1)                      
                            menuNumber = menuCount - 1;
                        SelectMenuType(menuType, menuCount);                   
                        break;
                    case ConsoleKey.DownArrow:
                        menuNumber++;
                        SelectMenuType(menuType, menuCount);
                                        
                        break;
                    case ConsoleKey.Enter:
                        return (menuNumber % menuCount) + 1;
                    case ConsoleKey.Escape:
                        return Constants.STOP;
                }
            }
        }

        private void SelectMenuType(string menuType,int menuCount)
        {
            switch (menuType)
            {
                case "User":
                    libraryUI.PrintUserMenuUI((menuNumber % menuCount) + 1);
                    break;
                case "Edit":
                    libraryUI.PrintEditUI((menuNumber % menuCount) + 1);
                    break;
                default:
                    return;
            }

        }


    }
}
