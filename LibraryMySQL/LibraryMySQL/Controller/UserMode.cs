using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{
    internal class UserMode
    {

       
       
        private int menuNumber;
        LibraryUI libraryUI;
        SelectionMode mode;
        Register register;
        Login login;
        UserModeUI userModeUI;
        ValidInput validInput;
        UserMenu userMenu;

        public UserMode(ValidInput validInput,  Login login,SelectionMode mode,LibraryUI libraryUI,UserModeUI userModeUI)
        {
          
            this.userModeUI = userModeUI;
            this.mode = mode;
            this.libraryUI = libraryUI;
            this.validInput = validInput;
            this.login = login;
            userMenu = new UserMenu(validInput, userModeUI, libraryUI, mode);
            register = new Register( userModeUI, validInput);
            menuNumber = 1;
        }
        public void StartUserMode()
        {

            libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 50);  //메인화면        

            while (Constants.isPROGRAM_ON)
            {
                Console.CursorVisible = Constants.isNONVISIBLE;
                menuNumber = mode.SelectMode(Constants.LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case Constants.LOGIN_MODE: // 로그인
                       if( login.LoginUser("User") == Constants.USER_MODE)
                            userMenu.StartUserMenu();
                        Console.Clear(); 
                        break;                
                    case Constants.REGISTER_MODE: // 회원가입
                        register.RegistUser();
                        Console.Clear();
                        break;
                    case Constants.STOP:
                        return; // 뒤로가기


                }
          
            }
        }     
    }
}