using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class UserMenu
    {
      
        SelectionMenu menu = new SelectionMenu();
        UserMenuUI userMenuUI = new UserMenuUI();
        LectureTimeMenu lectureTimeMenu = new LectureTimeMenu();
        int menuNumber;
        public void StartUserMenu()
        {
            
            while (Constant.PROGRAM_ON)
            {
                Console.Clear();
                userMenuUI.PrintUserMenu(1);
                
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "UserMenu"); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)


                switch (menuNumber)
                {
                    case Constant.LECTURE_TIME_CHECK:  // 시간표 조회
                        lectureTimeMenu.StartLectureTimeMenu();
                        break;
                    case Constant.LECTURE_INTERESTING: // 관심과목 담기
                        break;
                    case Constant.LECTURE_SUBSCRIPTION: // 수강신청
                        break;
                    case Constant.LECTURE_SUBSCRIPTION_RESULT: // 수강내역조회
                        break;
                    case Constant.STOP:
                        return;

                      
                }

            }


        }
    }   
}
