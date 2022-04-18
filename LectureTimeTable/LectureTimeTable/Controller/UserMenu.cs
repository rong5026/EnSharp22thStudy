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
        ExcelSaveMenu excelSaveMenu;
        Exception exception;
        ExcelUI excelUI;
        TimeTableUI timeTableUI;
        TimeTable timeTable;
        private int menuNumber;

        public UserMenu()
        {
            timeTable = new TimeTable();
            timeTableUI = new TimeTableUI();
            excelSaveMenu = new ExcelSaveMenu();
            userMenuUI = new UserMenuUI();
            menu = new SelectionMenu();
            excelUI = new ExcelUI();
            exception = new Exception();
            lectureTimeMenu = new LectureTimeMenu(menu, exception, excelUI);
            interestLectureMenu = new InterestLectureMenu(menu, exception, excelUI, timeTableUI, timeTable);
            registrationLectureMenu = new RegistrationLectureMenu(menu, exception, excelUI, timeTableUI, timeTable);
        }
        public void StartUserMenu()
        {


           
            while (Constants.PROGRAM_ON)
            {
                Console.Clear();
                userMenuUI.PrintUserMenu(1);
                menuNumber = 0;
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "UserMenu", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)


                switch (menuNumber)
                {
                    case Constants.LECTURE_TIME_CHECK:  // 시간표 조회
                        lectureTimeMenu.StartLectureTimeMenu();
                        break;
                    case Constants.LECTURE_INTERESTING: // 관심과목 담기
                        interestLectureMenu.StartInterestLectureMenu();
                        break;
                    case Constants.LECTURE_SUBSCRIPTION: // 수강신청
                        registrationLectureMenu.StartRegisterationLectureMenu();
                        break;
                    case Constants.LECTURE_SUBSCRIPTION_RESULT: // 수강내역조회
                        excelSaveMenu.StartEnterExcel();
                        break;
                    case Constants.STOP:
                        return;

                      
                }
                menuNumber--;
            }


        }
    }   
}
