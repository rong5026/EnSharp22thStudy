using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class LectureTimeMenu
    {
        LectureTimeUI lectureTimeUI = new LectureTimeUI();
        SelectionMenu menu = new SelectionMenu();
        int menuNumber;
        public void StartLectureTimeMenu()
        {
            lectureTimeUI.PrintLectureTime(1);

            while (Constant.PROGRAM_ON)
            {
                Console.CursorVisible = false;
                menuNumber = menu.SelectMenu(6); // 메뉴의 수 인자

                switch (menuNumber)
                {
                    case Constant.LECTURE_TIME_CHECK:  // 시간표 조회
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
