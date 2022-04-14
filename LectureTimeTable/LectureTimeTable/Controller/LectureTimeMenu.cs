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
        Exception exception = new Exception();
        ExcelUI excelUI = new ExcelUI();

        int menuNumber;
        int input;


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
            menuNumber = 0;
            while (Constant.PROGRAM_ON)
            {
              
                menuNumber = menu.SelectVerticalMenu(6, "LectureTimeMenu", menuNumber); // 수직인 메뉴선택( 선택요소 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        department = StartLectureDepartmentMenu();
                        break;
                    case Constant.LECTURE_DIVISION: // 이수구분
                        division = StartLectureDivisionMenu();
                        break;
                    case Constant.LECTURE_NAME: // 교과목명
                        name = StartLectureName();
                        break;
                    case Constant.PROFESSOR: // 교수명
                        break;
                    case Constant.GRADE: // 학년
                        grade = StartLectureClassMenu();
                        break;
                    case Constant.CHECK: // 조회
                        StartLectureCheck(department, division, name, progessor,grade);
                        break;
                    case Constant.STOP: // 뒤로가기
                        return;


                }
                menuNumber--;

            }

        }
        private int StartLectureDepartmentMenu() // 학과 선택 리스트
        {                    
            lectureTimeUI.PrintLectureDepartment(1);

            input = menu.SelectHorisionMenu(5, "LectureDepartment"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if(input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            return input;            
        }    
        private int StartLectureDivisionMenu() // 이수구분 리스트
        {
            lectureTimeUI.PrintLetureDivision(1);
            input = menu.SelectHorisionMenu(4, "LectureDivision"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            return input;
        }
        private string StartLectureName() // 수업이름

        {
            lectureTimeUI.PrintLectureName(); // 이름 입력창
            
            Console.ReadKey();
            name = exception.EnterLectureName(82,14);
            Console.CursorVisible = false;
            return name;

        }
        private int StartLectureClassMenu() {  // 학년
            lectureTimeUI.PrintLectureClass(1);
            input = menu.SelectHorisionMenu(4, "LectureClass"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            return input;
        }

       
        private void StartLectureCheck(int department, int division, string name, string progessor, int grade) // 조회하기 버튼
        {
            excelUI.PrintExcelLectureTime(); // 강의시간표 시작 UI

            //excelUI.PrintExcelData(department, division, name, progessor,grade);
            excelUI.PrintExcelData("", "", name, progessor,"");
        }
    }
}
