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
        RegisterationLectureUI registerationLectureUI = new RegisterationLectureUI();   
        InterestsLectureUI interestsLectureUI = new InterestsLectureUI();   

        SelectionMenu menu;
        Exception exception;
        ExcelUI excelUI;
        private int menuNumber;
        private int input;
        private string cellValue;
        private string classname;
        private string professor;
        private string classNumber;
        private string divisionNumber;
        ConsoleKeyInfo keyInput;
        private int searchingCount ; // 몇번 조건을 찾았는지

        private List<int> indexNO;

       
        public LectureTimeMenu(SelectionMenu menu, Exception exception, ExcelUI excelUI)
        {
           
            this.menu = menu;
            this.exception = exception;
            this.excelUI = excelUI;
            menuNumber = 0;
            indexNO = new List<int>();
            searchingCount = 0;
            classname = Constants.INPUT_EMPTY;
            professor = Constants.INPUT_EMPTY;
            classNumber = Constants.INPUT_EMPTY;
            divisionNumber = Constants.INPUT_EMPTY;
        }
        public void StartLectureTimeMenu()
        {
            Console.Clear();
            lectureTimeUI.PrintLectureTime(1);
            Console.CursorVisible = false;
            
          
            indexNO.Add(1);  // 처음 1번에 있는 테마 정보저장

           
            searchingCount = 0;
            while (Constants.PROGRAM_ON)
            {
                
                menuNumber = menu.SelectVerticalMenu(6, "LectureTimeMenu", menuNumber); // 수직인 메뉴선택( 선택요소 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constants.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        searchingCount = StartLectureDepartmentMenu(indexNO,searchingCount, "Lecture");
                        break;
                    case Constants.LECTURE_DIVISION: // 이수구분
                        searchingCount = StartLectureDivisionMenu(indexNO,searchingCount, "Lecture");
                        break;
                    case Constants.LECTURE_NAME: // 교과목명
                        searchingCount =  StartLectureName(indexNO, searchingCount);
                        break;
                    case Constants.PROFESSOR: // 교수명
                        searchingCount = StartProfessorName(indexNO, searchingCount);
                        break;
                    case Constants.GRADE: // 학년
                        searchingCount = StartLectureClassMenu(indexNO, searchingCount, "Lecture");
                        break;
                    case Constants.CHECK: // 조회                      
                        StartLectureCheck(indexNO, 28);
                        menuNumber = 0;
                        return;
                    case Constants.STOP: // 뒤로가기
                        return;


                }
                menuNumber--;

            }

        }
        public int StartLectureDepartmentMenu(List<int> list,int searchingCount,string type) // 학과 선택 리스트
        {                    
            lectureTimeUI.PrintLectureDepartment(1);

            input = menu.SelectHorisionMenu(5, "LectureDepartment"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constants.STOP)
            { // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                if (type == "Lecture")
                    lectureTimeUI.PrintLectureTime(1);
                else if (type == "Register")
                    registerationLectureUI.PrintRegisterationLecture(1);
                else
                    interestsLectureUI.PrintInterestLecture(1);
            }

            switch (input)
            {
                case Constants.LECTURE_ALL: // 전체
                    return FindExcelindex(list, "", 2, searchingCount);
                   
                case Constants.COMPUTER_DEPARTMENT: // 컴퓨터공학과
                    return FindExcelindex(list, "컴퓨터공학과", 2, searchingCount);
                    
                case Constants.INTELLIGENT_DEPARTMENT: // 지능기전공학부
                    return FindExcelindex(list, "지능기전공학부", 2, searchingCount);                 
                case Constants.SOFTWARE_DEPARTMENT: // 소프트웨어학과
                    return FindExcelindex(list, "소프트웨어학과", 2, searchingCount);                  
                case Constants.AEROSPACE_DEPARTMENT: // 기계항공우주공학부
                    return FindExcelindex(list, "기계항공우주공학부", 2, searchingCount);
                  
                default: return Constants.STOP;
            }

            
                       
        }    
        
  

        private int StartLectureDivisionMenu(List<int> list, int searchingCount, string type) // 이수구분 리스트
        {
            lectureTimeUI.PrintLetureDivision(1);
            input = menu.SelectHorisionMenu(4, "LectureDivision"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constants.STOP)
            {  // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                if (type == "Lecture")
                    lectureTimeUI.PrintLectureTime(1);
                else if(type =="Register")
                    registerationLectureUI.PrintRegisterationLecture(1);
                else
                    interestsLectureUI.PrintInterestLecture(1);

            }
            switch (input)
            {
                case Constants.LECTURE_ALL: // 전체 1
                   return FindExcelindex(list, Constants.INPUT_EMPTY, 6, searchingCount);
                   
                case Constants.GYOYANG_PILSU_CLASS: // 공통교양필수 2 
                    return FindExcelindex(list, "공통교양필수", 6, searchingCount);
                   
                case Constants.JEONGONG_PILSU_CLASS: // 전공필수 3 
                    return FindExcelindex(list, "전공필수", 6, searchingCount);
                    
                case Constants.JEONGONG_SEONTAEG: // 전공선택 4
                    return FindExcelindex(list, "전공선택", 6, searchingCount);
                   
                default: return Constants.STOP;
            }
        }
        public int  StartLectureName(List<int> list, int searchingCount) // 수업이름
        {
            lectureTimeUI.PrintLectureName(); // 수업이름 입력창


            classname = exception.EnterLectureName(82,14);
            Console.CursorVisible = false;
            return FindExcelindex(list, classname, 5, searchingCount);

        }
        public int StartProfessorName(List<int> list, int searchingCount) // 교수님 이름

        {
            lectureTimeUI.PrintProfessorName(); // 교수님이름 입력창

            professor = exception.EnterProfessorfeName(80, 16);
            Console.CursorVisible = false;

            return  FindExcelindex(list, professor, 11, searchingCount);

        }
        public int StartLectureClassMenu(List<int> list, int searchingCount, string type) {  // 학년
            lectureTimeUI.PrintLectureClass(1);
            input = menu.SelectHorisionMenu(5, "LectureClass"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constants.STOP)
            {  // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                if (type == "Lecture")
                    lectureTimeUI.PrintLectureTime(1);
                else if (type == "Register")
                    registerationLectureUI.PrintRegisterationLecture(1);
                else
                    interestsLectureUI.PrintInterestLecture(1);
            }

            switch (input)
            {
                case Constants.LECTURE_ALL: // 전체
                    return FindExcelindex(list, "", 7, searchingCount);                 
                case Constants.FIRST_CLASS: // 1학년
                    return FindExcelindex(list, "1", 7, searchingCount);              
                case Constants.SECOND_CLASS: // 2학년
                    return FindExcelindex(list, "2", 7, searchingCount);                 
                case Constants.THIRD_CLASS: // 3학년
                    return FindExcelindex(list, "3", 7, searchingCount);             
                case Constants.FOUR_CLASS: // 4학년
                    return FindExcelindex(list, "4", 7, searchingCount);             
                default: return Constants.STOP;
            }




        }

        //학수벊로 분반 예외랑 조회 함수 만들어야함
        public int StartStudyClassNumber(List<int> list, int searchingCount) // 학수번호,분반
        {

            
            lectureTimeUI.PrintStudyNumber(); // 학수번호 입력창
            classNumber = exception.EnterStudyNumber(80, 12);
            Console.CursorVisible = false;//커서 숨김
            if (classNumber == Constants.INPUT_EMPTY)
                return searchingCount + 1;
            lectureTimeUI.PrintDivisionNumber(); // 분반 입력창 
            divisionNumber = exception.EnterDivisionNumber(76, 13);

            Console.CursorVisible = false;//커서 숨김
            if (classNumber != Constants.INPUT_EMPTY && divisionNumber != Constants.INPUT_EMPTY)
            {
                searchingCount = FindExcelindex(list, classNumber, 3, searchingCount);
                return FindExcelindex(list, divisionNumber, 4, searchingCount);
            }
            else
                return searchingCount + 1;

        }
        private void StartLectureCheck(List<int> list, int yPosition) // 조회하기
        {
            excelUI.PrintExcelLectureTime(27); // 강의시간표 시작 UI
            excelUI.PrintExcelData(list,yPosition,"Lecture"); // y좌표
            excelUI.PrintExcelBack(); // 뒤로가기 UI

            list.Clear();


            while (Constants.PROGRAM_ON) // ESC키 누르면 뒤로가기
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                    return;
              
            }



        }
        public int FindExcelindex(List<int> list,string word, int columnindex, int searchingCount) 
            // 검색시에 해당하는 index를 list에 넣음
        {
            for (int rowIndex = 2; rowIndex <= 185; rowIndex++)
            {
                cellValue = Convert.ToString(LTTStart.excelData.Data.GetValue(rowIndex, columnindex));

                if (cellValue.Contains(word) && searchingCount == 0)
                {

                    list.Add(rowIndex);

                }
                else if (cellValue.Contains(word) == false)
                {
                    list.Remove(rowIndex);
                }
            }
            return searchingCount + 1;
        }



    }
}
