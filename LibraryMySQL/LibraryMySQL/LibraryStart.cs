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

        public static List<UserVO> userList; 
        public static List<BookVO> bookList;

       
        BookVO bookVO;
        LibraryUI UI;
        SelectionMode mode;
        UserMode userMode;
        //ManagerMode managerMode;
        MySQlData mysqlData;
        int menuNumber;


      

        public LibraryStart()
        {
            mysqlData = MySQlData.Instance();
            
           
            bookVO = new BookVO();

            userList = new List<UserVO>();
            bookList = new List<BookVO>();
          
            UI = new LibraryUI();
            mode = new SelectionMode(UI);
          
            userMode = new UserMode(UI,mode, mysqlData);
          


         
           

        }
      

        public void StartProgram()
        {


         
            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);
            Console.CursorVisible = false;
            while (Constants.PROGRAM_ON)
            {
                menuNumber =  mode.SelectMode(Constants.USER_MANAGER); // 회원모드 . 유저모드 선택
                switch (menuNumber)
                {
                    case Constants.USER_MODE: // 유저모드 일때
                         userMode.StartUserMode();
                        break;
                    case Constants.MANAGE_MODE: // 관리자 모드
                         //managerMode.StartManagerMode();
                        break;
                    case Constants.STOP:
                         UI.PrintProgramStop(); // 종료
                        return;


                }

            }
        
        }


    }

}
