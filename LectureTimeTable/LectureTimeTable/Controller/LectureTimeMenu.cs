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
        string result ="";
        string cellValue;


        string department = "";
        string division = "";
        string classname="";
        string professor="";
        string grade ="";
        ConsoleKeyInfo keyInput;
        int searchingCount = 0; // 몇번 조건을 찾았는지

        List<int> indexNO;

        public LectureTimeMenu()
        {


            menuNumber = 0;
            indexNO = new List<int>();


        }
        public void StartLectureTimeMenu()
        {
            Console.Clear();
            lectureTimeUI.PrintLectureTime(1);
            Console.CursorVisible = false;
            
            indexNO.Add(1);  // 처음 1번에 있는 테마 정보저장

           
            searchingCount = 0;
            while (Constant.PROGRAM_ON)
            {
                
                menuNumber = menu.SelectVerticalMenu(6, "LectureTimeMenu", menuNumber); // 수직인 메뉴선택( 선택요소 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        searchingCount = StartLectureDepartmentMenu(searchingCount);
                        break;
                    case Constant.LECTURE_DIVISION: // 이수구분
                        searchingCount = StartLectureDivisionMenu(searchingCount);
                        break;
                    case Constant.LECTURE_NAME: // 교과목명
                        searchingCount =  StartLectureName(searchingCount);
                        break;
                    case Constant.PROFESSOR: // 교수명
                        searchingCount = StartLectureName(searchingCount);
                        break;
                    case Constant.GRADE: // 학년
                        searchingCount = StartLectureName(searchingCount);
                        break;
                    case Constant.CHECK: // 조회                      
                        StartLectureCheck(indexNO, 28);
                        return;
                    case Constant.STOP: // 뒤로가기
                        return;


                }
                menuNumber--;

            }

        }
        public int StartLectureDepartmentMenu(int searchingCount) // 학과 선택 리스트
        {                    
            lectureTimeUI.PrintLectureDepartment(1);

            input = menu.SelectHorisionMenu(5, "LectureDepartment"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if(input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);

            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체
                    return FindExcelindex(indexNO,"", 2, searchingCount);
                   
                case Constant.COMPUTER_DEPARTMENT: // 컴퓨터공학과
                    return FindExcelindex(indexNO,"컴퓨터공학과", 2, searchingCount);
                    
                case Constant.INTELLIGENT_DEPARTMENT: // 지능기전공학부
                    return FindExcelindex(indexNO,"지능기전공학부", 2, searchingCount);                 
                case Constant.SOFTWARE_DEPARTMENT: // 소프트웨어학과
                    return FindExcelindex(indexNO,"소프트웨어학과", 2, searchingCount);                  
                case Constant.AEROSPACE_DEPARTMENT: // 기계항공우주공학부
                    return FindExcelindex(indexNO,"기계항공우주공학부", 2, searchingCount);
                  
                default: return Constant.STOP;
            }

            
                       
        }    
        
  

        private int StartLectureDivisionMenu(int searchingCount) // 이수구분 리스트
        {
            lectureTimeUI.PrintLetureDivision(1);
            input = menu.SelectHorisionMenu(4, "LectureDivision"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);
            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체 1
                   return FindExcelindex(indexNO,"", 6, searchingCount);
                   
                case Constant.GYOYANG_PILSU_CLASS: // 공통교양필수 2 
                    return FindExcelindex(indexNO, "공통교양필수", 6, searchingCount);
                   
                case Constant.JEONGONG_PILSU_CLASS: // 전공필수 3 
                    return FindExcelindex(indexNO, "전공필수", 6, searchingCount);
                    
                case Constant.JEONGONG_SEONTAEG: // 전공선택 4
                    return FindExcelindex(indexNO, "전공선택", 6, searchingCount);
                   
                default: return Constant.STOP;
            }
        }
        public int  StartLectureName(int searchingCount) // 수업이름
        {
            lectureTimeUI.PrintLectureName(); // 수업이름 입력창


            classname = exception.EnterLectureName(82,14);
            Console.CursorVisible = false;
            return FindExcelindex(indexNO, classname, 5, searchingCount);

        }
        public int StartProfessorName(int searchingCount) // 교수님 이름

        {
            lectureTimeUI.PrintProfessorName(); // 교수님이름 입력창

            professor = exception.EnterProfessorfeName(80, 16);
            Console.CursorVisible = false;

            return  FindExcelindex(indexNO, professor, 11, searchingCount);

        }
        public int StartLectureClassMenu(int searchingCount) {  // 학년
            lectureTimeUI.PrintLectureClass(1);
            input = menu.SelectHorisionMenu(5, "LectureClass"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                lectureTimeUI.PrintLectureTime(1);

            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체
                    return FindExcelindex(indexNO, "", 7, searchingCount);
                    break;
                case Constant.FIRST_CLASS: // 1학년
                    return FindExcelindex(indexNO, "1", 7, searchingCount);
                    break;
                case Constant.SECOND_CLASS: // 2학년
                    return FindExcelindex(indexNO, "2", 7, searchingCount);
                    break;
                case Constant.THIRD_CLASS: // 3학년
                    return FindExcelindex(indexNO, "3", 7, searchingCount);
                    break;
                case Constant.FOUR_CLASS: // 4학년
                    return FindExcelindex(indexNO, "4", 7, searchingCount);
                    break;
                default: return Constant.STOP;
            }




        }
     
      
        private void StartLectureCheck(List<int> list, int yPosition) // 조회하기 버튼
        {
            excelUI.PrintExcelLectureTime(); // 강의시간표 시작 UI
            excelUI.PrintExcelData(list,yPosition); // y좌표
            excelUI.PrintExcelBack(); // 뒤로가기 UI

            indexNO.Clear();


            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                    return;
            }



        }
        public int FindExcelindex(List<int> list,string word, int columnindex, int searchingCount) // 검색시에 해당하는 index를 list에 넣음
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
