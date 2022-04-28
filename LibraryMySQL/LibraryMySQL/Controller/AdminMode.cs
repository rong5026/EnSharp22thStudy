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
        public AdminMode()
        {
            validInput = new ValidInput();
            userModeUI = new UserModeUI();
            libraryUI = new LibraryUI();
            mode = new SelectionMode(libraryUI);
            login = new Login(userModeUI, validInput);
        }
        public void StartAdminMode()
        {

                       
            while (Constants.isPROGRAM_ON)
            {
                libraryUI.PrintMainUI(); // Admin 로그인 
                if (login.LoginUser("Admin") == Constants.BACK)
                    break;
            }
           


        }
        public void StartAdminMenu()
        {
            int menuNumber;

            libraryUI.PrintMainUI();
            while (Constants.isPROGRAM_ON)
            {
               
                menuNumber = mode.SelectUserManagerMenu("Admin", 6); // 유저메뉴 위아래 화살표로 선택하기

                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: //도서찾기                  
                     
                        break;
                    case Constants.BOOK_RENT: // 도서추가             
                       
                        break;
                    case Constants.BOOK_BORROW_LIST: //도서삭제         
                        
                        break;
                    case Constants.BOOK_RETURN: // 도서수정                
                      
                        break;
                    case Constants.BOOK_RETRUN_HISTORY: // 회원관리
                      
                        break;
                    case Constants.USER_EDIT: // 대여상황보기
                     
                        break;            
                    case Constants.EXIT:
                        return;
                    default:
                        return;


                }


            }

        }



    }
}
