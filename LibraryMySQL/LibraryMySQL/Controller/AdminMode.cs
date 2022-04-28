using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminMode
    {
        LibraryUI libraryUI;
        Login login;
        ValidInput validInput;
        UserModeUI userModeUI;
        SelectionMode mode;
        public AdminMode(ValidInput validInput, Login login, SelectionMode mode, LibraryUI libraryUI, UserModeUI userModeUI)
        {
            this.validInput = validInput;
            this.login = login;
            this.mode = mode;
            this.libraryUI = libraryUI;
            this.userModeUI = userModeUI;
          
               
        }
        public void StartAdminMode()
        {

                       
            while (Constants.isPROGRAM_ON)
            {
                libraryUI.PrintMainUI(); // Admin 로그인 
                if (login.LoginUser("Admin") == Constants.BACK)
                {
                    Console.Clear();
                    break;
                }
            }
           


        }
      



    }
}
