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
                    case USER_MODE: // 도서찾기
                        userMode.StartUserMode(userList);
                        break;
                    case MANAGE_MODE: // 도서대여
                        break;
                    case STOP: //대여도서확인
                        UI.PrintProgramStop();
                        break;
                    case decimal: // 회원정보 수정
                        break;
                    case 회원탈퇴: // 회원탈퇴


                }

            }
            

        }
    }
}
