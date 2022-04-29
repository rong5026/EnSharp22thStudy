using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.Drawing;
namespace LibraryMySQL
{

    internal class LibraryStart

    {

        LibraryUI libraryUI;
      
        ValidInput validInput;
        UserModeUI userModeUI;
        Login login;
        SelectionMode mode;
        UserMode userMode;
      
       
        int menuNumber;

        public static string loginedUser;

        public LibraryStart()
        {

            libraryUI = new LibraryUI ();
            validInput = new ValidInput ();
            userModeUI = new UserModeUI ();
            login = new Login(userModeUI,validInput);
            mode = new SelectionMode(libraryUI);       
            userMode =  new UserMode(validInput,login, mode,libraryUI, userModeUI);
            
        }
      

        public void StartProgram()
        {

         
            libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 50);
           
            
            Console.CursorVisible = false;
            while (Constants.isPROGRAM_ON)
            {
                menuNumber =  mode.SelectMode(Constants.USER_MANAGER); // 회원모드 . 유저모드 선택
                switch (menuNumber)
                {
                    case Constants.USER_MODE: // 유저모드 일때
                        userMode.StartUserMode();
                        break;
                    case Constants.ADMIN_MODE: // 관리자 모드
                        userMode
                        break;
                    case Constants.STOP:
                     
                        return;


                }

            }
        
        }


    }

}
