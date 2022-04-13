using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class UserMenu
    {
        int menuNumber;
        SelectionMenu menu = new SelectionMenu();
        UserMenuUI userMenuUI = new UserMenuUI();
        public void StartUserMenu()
        {
            userMenuUI.PrintUserMenu(1);
            while (Constant.PROGRAM_ON)
            {
                Console.CursorVisible = false;
                menuNumber = menu.SelectUserMenu(4); // 메뉴의 수 인자


                switch (menuNumber)
                {
                    case Constant.LECTURE_CLASS_CHECK:  // 시간표 조회
                        break;
                    case Constant.LECTURE_INTERESTING: // 관심과목 담기
                        break;
                    case Constant.LECTURE_SUBSCRIPTION: // 수강신청
                        break;
                    case Constant.LECTURE_SUBSCRIPTION_RESULT: // 수강내역조회
                        break;
                    default: // 뒤로가기

                        break;
                }

            }


        }
    }   
}
