using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminMenu
    {
        LibraryUI libraryUI;
        SelectionMode mode;
        BookSearching bookSearching;

        UserModeUI userModeUI;
        ValidInput validInput;
        MySQlData mySQlData;

        public AdminMenu(ValidInput validInput, UserModeUI userModeUI)
        {
            this.validInput = validInput;
            this.userModeUI = userModeUI;
            bookSearching = new BookSearching();
            libraryUI = new LibraryUI();
            mode = new SelectionMode(libraryUI);
            mySQlData = MySQlData.Instance();
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
                    case Constants.BOOK_ADD: // 도서추가             

                        break;
                    case Constants.BOOK_DELETE: //도서삭제         

                        break;
                    case Constants.BOOK_EDIT: // 도서수정                

                        break;
                    case Constants.USER_CARE: // 회원관리

                        break;
                    case Constants.TOTAL_USER_RENTBOOK: // 대여상황보기

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
