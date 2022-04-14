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
                menuNumber = menu.SelectVerticalMenu(6, "LectureTimeMenu"); // 수직인 메뉴선택( 선택요소 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        lectureTimeUI.PrintLectureDepartment(1);
                        break;
                    case Constant.LECTURE_DIVISION: // 이수구분
                        break;
                    case Constant.LECTURE_NAME: // 교과목명
                        break;
                    case Constant.PROFESSOR: // 교수명
                        break;
                    case Constant.GRADE: // 학년
                        break;
                    case Constant.CHECK: // 조회
                        break;
                    case Constant.STOP: // 뒤로가기
                        return;


                }

            }

        }

       

    }
}
