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

      
       
        int menuNumber = 1;
        LibraryUI libraryUI;
        SelectionMode mode;
        Register register;
        Login login;
        UserModeUI userModeUI;
    
        ValidInput validInput;
        public UserMode( SelectionMode mode)
        {
          
            this.mode = mode;
            validInput = new ValidInput();
            userModeUI = new UserModeUI();
            libraryUI = new LibraryUI();
            login = new Login(userModeUI, validInput);
            register = new Register( userModeUI, validInput);
           
        
           
        }
        public void StartUserMode()
        {

            libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 50);  //메인화면
          


            while (Constants.isPROGRAM_ON)
            {
                Console.CursorVisible = false;
                menuNumber = mode.SelectMode(Constants.LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case Constants.LOGIN_MODE: // 로그인
                        login.LoginUser(); //
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




        } // 로그인을 했다면 UserMode 기능 출력, 선택

      
    }
}