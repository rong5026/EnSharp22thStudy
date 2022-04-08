using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserMenu
    {
        const bool PROGRAM_ON = true;
        const int BOOK_SEARCH = 1;
        const int BOOK_RENT = 2;
        const int BOOK_BORROW_LIST = 3;
        const int USER_EDIT = 4;
        const int DELETE_ID = 5;
        const int EXIT = -1;
        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();

        int menuNumber;


        public void StartUserMenu()
        {
            UI.PrintMainUI();
            Console.SetWindowSize(125, 40);

            UI.PrintUserMenuUI(1);
            while (PROGRAM_ON)
            {
                menuNumber = mode.SelectUserMenu();// 도서찾기, 도서대여,대여도서확인,회원정보수정

                switch (menuNumber)
                {
                    case BOOK_SEARCH: // 도서찾기
                        //userMode.StartUserMode(userList);
                        break;
                    case BOOK_RENT: // 도서대여
                        break;
                    case BOOK_BORROW_LIST: //대여도서확인
                        UI.PrintProgramStop();
                        break;
                    case USER_EDIT: // 회원정보 수정
                        break;
                    case DELETE_ID: // 회원탈퇴
                        break;                   
                    case EXIT:
                        return;
                    default:
                        return;


                }

            }


        }
    }
}