using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class UserMenu
    {

        LibraryUI libraryUI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        BookSearching bookSearching;
        MySQlData mySQlData;
        int userid;
        bool delete;
        int menuNumber;

        public UserMenu(MySQlData mySQlData)
        {
            this.mySQlData = mySQlData;
           // bookSearching = new BookSearching(mySQlData);
        }
        public void StartUserMenu()
        {
           // libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 40);

            while (Constants.PROGRAM_ON)
            {
                menuNumber = mode.SelectUserManagerMenu("User", 7); // 유저메뉴 위아래 화살표로 선택하기
                
                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: // 도서찾기                    
                        book.SearchBook();
                        break;
                    case Constants.BOOK_RENT: // 도서대여
                        VariableData.book.BorrowBook();
                        break;
                    case Constants.BOOK_BORROW_LIST: //대여도서확인
                        VariableData.book.ConfirmRentedBook();
                        break;
                    case Constants.BOOK_RETURN: // 도서 반납
                        VariableData.book.ReturnBook();
                        break;
                    case Constants.BOOK_RETRUN_HISTORY:
                        VariableData.book.ConfirmReturnBook(); // 도서반납확인
                        break;
                    case Constants.USER_EDIT: // 회원정보 수정
                        EditUserData();
                        break;
                    case Constants.DELETE: // 계정삭제
                        delete = DeleteUserId();
                        if (delete)
                            return;
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
