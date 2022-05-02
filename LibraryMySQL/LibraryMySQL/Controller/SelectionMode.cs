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
               keyInput = Console.ReadKey(Constants.KEY_INPUT);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuNumber = Constants.USER_MODE;
                        libraryUI.PrintSelectUI(Constants.USER_MODE, type);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber = Constants.ADMIN_MODE;
                        libraryUI.PrintSelectUI(Constants.ADMIN_MODE, type);
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
            switch (menuType)
            {
                case "User":
                    libraryUI.PrintUserMenuUI(Constants.FIND_BOOK);
                    break;
                case "Edit":
                    libraryUI.PrintEditUI(Constants.USER_ID);
                    break;
                case "Admin":
                    libraryUI.PrintAdminMenuUI(Constants.FIND_BOOK);
                    break;
                case "BookEdit":
                    libraryUI.PrintAdminBookEditUI(Constants.BOOK_NAME);
                    break;
                case "Log":
                    libraryUI.PrintLogMenuUI(Constants.LOG_EDIT);
                    break;

            }
         

            Console.CursorVisible = Constants.isNONVISIBLE;
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
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
                case "Admin":
                    libraryUI.PrintAdminMenuUI((menuNumber % menuCount) + 1);
                    break;
                case "BookEdit":
                    libraryUI.PrintAdminBookEditUI((menuNumber % menuCount) + 1);
                    break;
                case "Log":
                    libraryUI.PrintLogMenuUI((menuNumber % menuCount) + 1);
                    break;
                default:
                    return;
            }

        }


    }
}
