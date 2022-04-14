﻿using System;
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


        string department = "";
        string division = "";
        string name="";
        string professor="";
        string grade ="";
       
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
                        professor = StartProfessorName();
                        break;
                    case Constant.GRADE: // 학년
                        grade = StartLectureClassMenu();
                        break;
                    case Constant.CHECK: // 조회
                       // StartLectureCheck(department, division, name, professor, grade);
                        break;
                    case Constant.STOP: // 뒤로가기
                        return;


                }
                menuNumber--;

            }

        }
        private string StartLectureDepartmentMenu() // 학과 선택 리스트
        {                    
            lectureTimeUI.PrintLectureDepartment(1);

            input = menu.SelectHorisionMenu(5, "LectureDepartment"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if(input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);

            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체
                    return "";
                case Constant.COMPUTER_DEPARTMENT: // 컴퓨터공학과
                    return "컴퓨터공학과";
                case Constant.INTELLIGENT_DEPARTMENT: // 지능기전공학부
                    return "지능기전공학부";
                case Constant.SOFTWARE_DEPARTMENT: // 소프트웨어학과
                    return "소프트웨어학과";
                case Constant.AEROSPACE_DEPARTMENT: // 기계항공우주공학부
                    return "기계항공우주공학부";
                default: return "-1";
            }
                       
        }    
        private string StartLectureDivisionMenu() // 이수구분 리스트
        {
            lectureTimeUI.PrintLetureDivision(1);
            input = menu.SelectHorisionMenu(4, "LectureDivision"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체 1
                    return "";
                case Constant.GYOYANG_PILSU_CLASS: // 공통교양필수 2 
                    return "공통교양필수";
                case Constant.JEONGONG_PILSU_CLASS: // 전공필수 3 
                    return "전공필수";
                case Constant.JEONGONG_SEONTAEG: // 전공선택 4
                    return "전공선택";
                default: return "-1";
            }
        }
        private string StartLectureName() // 수업이름

        {
            lectureTimeUI.PrintLectureName(); // 이름 입력창
            
           
            name = exception.EnterLectureName(82,14);
            Console.CursorVisible = false;
            return name;

        }
        private string StartProfessorName() // 교수님 이름

        {
            lectureTimeUI.PrintProfessorName(); // 이름 입력창

           
            professor = exception.EnterProfessorfeName(80, 16);
            Console.CursorVisible = false;
            return professor;

        }
        private string StartLectureClassMenu() {  // 학년
            lectureTimeUI.PrintLectureClass(1);
            input = menu.SelectHorisionMenu(5, "LectureClass"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);

            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체
                    return "";
                case Constant.FIRST_CLASS: // 1학년
                    return "1";
                case Constant.SECOND_CLASS: // 2학년
                    return "2";
                case Constant.THIRD_CLASS: // 3학년
                    return "3";
                case Constant.FOUR_CLASS: // 4학년
                    return "4";
                default: return "-1";
            }




        }
     
      
        private void StartLectureCheck(int department, int division, string name, string progessor, int grade) // 조회하기 버튼
        {
            //excelUI.PrintExcelLectureTime(); // 강의시간표 시작 UI
            excelUI.PrintExcelData(department, division, name, progessor, grade, 26); // y좌표

            //excelUI.PrintExcelData(department, division, name, progessor,grade);

        }
    }
}
