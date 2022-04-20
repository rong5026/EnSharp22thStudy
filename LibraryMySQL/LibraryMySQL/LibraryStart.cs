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
        SelectionMode mode;
        UserMode userMode;
        int menuNumber;

        public LibraryStart()
        {
            libraryUI = new LibraryUI ();
           
            mode = new SelectionMode(libraryUI);       
            userMode =  new UserMode( mode);
        }
      

        public void StartProgram()
        {

         
            libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 60);
           
            
            Console.CursorVisible = false;
            while (Constants.isPROGRAM_ON)
            {
                menuNumber =  mode.SelectMode(Constants.USER_MANAGER); // 회원모드 . 유저모드 선택
                switch (menuNumber)
                {
                    case Constants.USER_MODE: // 유저모드 일때
                        userMode.StartUserMode();
                        break;
                    case Constants.MANAGE_MODE: // 관리자 모드                       
                        break;
                    case Constants.STOP:
                     
                        return;


                }

            }
        
        }


    }

}
