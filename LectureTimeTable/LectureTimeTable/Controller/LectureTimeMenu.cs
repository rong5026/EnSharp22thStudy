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

        int department = 0;
        int division = 0;
        string name="";
        string progessor="";
        int grade=0;
       
        public void StartLectureTimeMenu()
        {
            Console.Clear();
            lectureTimeUI.PrintLectureTime(1);
            Console.CursorVisible = false;
            while (Constant.PROGRAM_ON)
            {
              
                menuNumber = menu.SelectVerticalMenu(6, "LectureTimeMenu"); // 수직인 메뉴선택( 선택요소 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        department = StartLectureDepartmentMenu();
                        break;
                    case Constant.LECTURE_DIVISION: // 이수구분
                        division = StartLectureDivisionMenu();
                        break;
                    case Constant.LECTURE_NAME: // 교과목명
                      
                        break;
                    case Constant.PROFESSOR: // 교수명
                        break;
                    case Constant.GRADE: // 학년
                        grade = StartLectureClassMenu();
                        break;
                    case Constant.CHECK: // 조회
                        break;
                    case Constant.STOP: // 뒤로가기
                        return;


                }

            }

        }
        private int StartLectureDepartmentMenu() // 학과 선택 리스트
        {                    
            lectureTimeUI.PrintLectureDepartment(1);
            
            menuNumber = menu.SelectHorisionMenu(5, "LectureDepartment"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if(menuNumber == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            return menuNumber;            
        }    
        private int StartLectureDivisionMenu() // 이수구분 리스트
        {
            lectureTimeUI.PrintLetureDivision(1);
            menuNumber = menu.SelectHorisionMenu(4, "LectureDivision"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (menuNumber == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            return menuNumber;
        }
        private int StartLectureClassMenu() {  // 학년
            lectureTimeUI.PrintLectureClass(1);
            menuNumber = menu.SelectHorisionMenu(4, "LectureClass"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (menuNumber == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            return menuNumber;
        }
    }
}
