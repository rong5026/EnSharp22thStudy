using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class UserMenu
    {

        SelectionMenu menu;
        UserMenuUI userMenuUI;
        LectureTimeMenu lectureTimeMenu;
        InterestLectureMenu interestLectureMenu;
        RegistrationLectureMenu registrationLectureMenu;
        Exception exception;
        ExcelUI excelUI;
        int menuNumber;

        public UserMenu()
        {
            userMenuUI = new UserMenuUI();
            menu = new SelectionMenu();
            excelUI = new ExcelUI();
            exception = new Exception();
            lectureTimeMenu = new LectureTimeMenu(menu, exception, excelUI);
            interestLectureMenu = new InterestLectureMenu(menu, exception, excelUI);
            registrationLectureMenu = new RegistrationLectureMenu(menu, exception, excelUI);
        }
        public void StartUserMenu()
        {


           
            while (Constant.PROGRAM_ON)
            {
                Console.Clear();
                userMenuUI.PrintUserMenu(1);
                menuNumber = 0;
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "UserMenu", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)


                switch (menuNumber)
                {
                    case Constant.LECTURE_TIME_CHECK:  // 시간표 조회
                        lectureTimeMenu.StartLectureTimeMenu();
                        break;
                    case Constant.LECTURE_INTERESTING: // 관심과목 담기
                        interestLectureMenu.StartInterestLectureMenu();
                        break;
                    case Constant.LECTURE_SUBSCRIPTION: // 수강신청
                        registrationLectureMenu.StartRegisterationLectureMenu();
                        break;
                    case Constant.LECTURE_SUBSCRIPTION_RESULT: // 수강내역조회
                        break;
                    case Constant.STOP:
                        return;

                      
                }
                menuNumber--;
            }


        }
    }   
}
