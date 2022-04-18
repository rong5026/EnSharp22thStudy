using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class InterestLectureMenu 
    {

       
        InterestsLectureUI interestsLectureUI= new InterestsLectureUI();
        TimeTableUI timeTableUI;
        SelectionMenu menu;
        Exception exception;
        ExcelUI excelUI;
        TimeTable timeTable;
        LectureTimeMenu lectureTimeMenu;

        ConsoleKeyInfo keyInput;
        private int menuNumber;
        private int input;
        List<int> indexNO;
        private int searchingCount; // 몇번 조건을 찾았는지
      




        public InterestLectureMenu(SelectionMenu menu, Exception exception, ExcelUI excelUI, TimeTableUI timeTableUI, TimeTable timeTable)
        {
           

            indexNO = new List<int>();
            this.timeTable = timeTable;
            this.timeTableUI = timeTableUI;
            this.menu = menu;
            this.exception = exception;
            this.excelUI = excelUI;
            lectureTimeMenu = new LectureTimeMenu(menu, exception, excelUI);
            
        }
        public void StartInterestLectureMenu()
        {
            
            menuNumber = 0;
            Console.SetCursorPosition(0, 0);
   
            while (Constants.PROGRAM_ON)
            {
           
                
                interestsLectureUI.PrintInterestsLectureMenu(1); // 관심과목 담기 메인 메뉴
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "InterestLecture", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)

                switch (menuNumber)
                {
                    
                    case Constants.LECTURE_SEARCH:  // 관심 과목 분야별 검색
                        SearchInterestLecture(indexNO);
                        break;
                    case Constants.LECTURE_LIST: // 관심 과목 강의 내역
                        interestsLectureUI.PrintSelectedList(LTTStart.interestList,"Interest");
                        BackESC();
                        Console.Clear();
                        break;
                    case Constants.LECTURE_SCHEDULE: // 관심 과목 시간표                      
                        timeTableUI.PrintLectureSchedule(LTTStart.interestList,"Interest");
                        BackESC();
                        Console.Clear();
                        break;
                    case Constants.LECTURE_DELETE: // 관심 과목 삭제
                        DeleteInterestLecture();                       
                        break;
                    case Constants.STOP:
                        return;


                }
                menuNumber = 0;
            }

        }
        private void SearchInterestLectureList(List<int> list)
        {
            while (Constants.PROGRAM_ON)
            {
                SearchInterestLecture(list);

            }
        }
        private void SearchInterestLecture(List<int >list ) // 목록 조건 선택
        {
            Console.Clear();
            interestsLectureUI.PrintInterestLecture(1); // 개설학과, 학수번호, 교과목,교수명,학년,조회 리스트
            Console.CursorVisible = false;

            list.Clear();
            list.Add(1); // 처음 1번에 있는 테마 정보저장

            input = 0;
            searchingCount = 0;
            while (Constants.PROGRAM_ON)
            {

                input = menu.SelectVerticalMenu(6, "InterestLectureSearch", input);// 수직메뉴 // 개설학과,학수번호 ...
                
                switch (input)
                {
                    
                    case Constants.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        searchingCount = lectureTimeMenu.StartLectureDepartmentMenu(list,searchingCount,"Interest");
                        break;
                    case Constants.LECTURE_DIVISION: // 학수번호/분반
                        searchingCount = lectureTimeMenu.StartStudyClassNumber(list,searchingCount);                 
                        break;
                    case Constants.LECTURE_NAME: // 교과목명
                        searchingCount = lectureTimeMenu.StartLectureName(list, searchingCount);
                        break;
                    case Constants.PROFESSOR: // 교수명
                        searchingCount = lectureTimeMenu.StartProfessorName(list, searchingCount);
                        break;
                    case Constants.GRADE: // 학년
                        searchingCount = lectureTimeMenu.StartLectureClassMenu(list, searchingCount, "Interest");
                        break;
                    case Constants.CHECK: // 조회 및 관심과목신청
                        StartExcelCheck(list, 30);                   
                        Console.Clear();
                        return;
                    case Constants.STOP: // 뒤로가기
                        Console.Clear();
                        return;


                }
                input--;

            }

        }
        
        private void StartExcelCheck(List<int> list, int yPosition) // 조회하기 
        {

           
            excelUI.PrintExcelLectureTime(28); // 강의시간표 시작 UI
            excelUI.PrintExcelData(list, yPosition,"Interest"); // y좌표
           
            SelectInterestLecture(list); //관심과목번호 입력 후 리스트에 추가

            list.Clear();


        }
        private int SelectInterestLecture(List<int> list) // 관심과목번호 입력 후 리스트에 추가
        {
            string classNO;
            int selection;
            while (Constants.PROGRAM_ON) // 관심과목 선택
            {
                interestsLectureUI.PrintInputInterestLecture(LTTStart.interestNumber, 24, 65, 25); // 관심과목 담을과목 선택 UI
                classNO = exception.EnterLectureNO(125, 25); // 입력

                if (classNO == "")
                    break;
                if (LTTStart.interestList.Contains(Convert.ToInt16(classNO)+1))//관심과목List에 같은 No가 있을때
                {
                    interestsLectureUI.PrintInterestStatus(65, 25, "실패! 이미 관심과목 리스트에 담겼있습니다!!       ESC : 나가기   ENTER : 다시입력             "); //관담 실패!

                    selection =Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectInterestLecture(list);
                    return Constants.STOP;
                }
                else if( list.Contains(Convert.ToInt16(classNO)+1)==false)
                {
                    interestsLectureUI.PrintInterestStatus(65, 25, "실패! !! 리스트에 없는 No 입니다!       ESC : 나가기   ENTER : 다시입력         "); //관담 실패!
                    selection =Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectInterestLecture(list);
                    return Constants.STOP;
                }
                else if(timeTable.CheckTime( Convert.ToString( LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO)+1,9)) , LTTStart.interestList) == 1)
                {
                    interestsLectureUI.PrintInterestStatus(65, 25, "실패!  등록하신 시간표와 시간이 겹칩니다!  ESC : 나가기   ENTER : 다시입력         "); //관담 실패!
                    selection = Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectInterestLecture(list);
                    return Constants.STOP;
                }
                else if ( LTTStart.interestNumber + Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO) + 1, 8)) >24)
                {
                    interestsLectureUI.PrintInterestStatus(65, 25, "실패!  최대로 담을 수 있는 학점을 초과합니다!  ESC : 나가기   ENTER : 다시입력         "); //관담 실패!
                    selection = Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectInterestLecture(list);
                    return Constants.STOP;
                }

                LTTStart.interestList.Add(Convert.ToInt16(classNO)+1); // 관심과목에 없으면 추가
                LTTStart.interestNumber += Convert.ToInt16 (LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO)+1, 8)); // 관심과목 담은 학점
                interestsLectureUI.PrintInterestStatus(65,25, "성공! 관심과목 리스트에 담겼습니다!!       ESC : 나가기   ENTER : 다시입력           ");
                // 관담 성공!
                
                selection = Reinput();
                if (selection == Constants.REINPUT)
                    return SelectInterestLecture(list);             
                return Constants.STOP;

            }
            return Constants.STOP;

        }
        public int Reinput()
        {
            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                    return Constants.BACK;
                else if (keyInput.Key == ConsoleKey.Enter)
                    return Constants.REINPUT;
            }
        }
        public void BackESC() // 뒤로가기
        {
            
            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape) 
                     return;
            }
        }

        private void DeleteInterestLecture() // 관심과목 삭제
        {
            bool result;
            string classNumber;

            interestsLectureUI.PrintSelectedList(LTTStart.interestList,"Interest"); // 관심과목 목록 출력
            interestsLectureUI.PrintInputDeleteLecture(LTTStart.interestNumber); //관심과목 삭제 입력창

            classNumber = exception.EnterLectureNO(109, 5);// 삭제할 NO입력

            if (classNumber != "")
                result = LTTStart.interestList.Contains(Convert.ToInt16(classNumber) + 1);
            else
            {
                Console.Clear();
                return;
                
            }
            if(result == false) // 관심과목에 삭제할 NO가 없을때 
            {
                //관담 삭제 식패!
                interestsLectureUI.PrintInterestStatus(65, 23, "실패! 관심과목 리스트 존재하지않는 NO입니다!      ESC: 나가기");
            }
            else 
            { 
                LTTStart.interestList.Remove(Convert.ToInt16(classNumber)+1); // 해당 관심과목 삭제
                interestsLectureUI.PrintInterestStatus(65, 23, "성공! 관심과목 리스트에서 삭제되었습니다!.      ESC: 나가기");
                LTTStart.interestNumber -= Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNumber) + 1, 8)); // 관심과목 담은 학점

            }
            BackESC();
            Console.Clear();


        }





    }


}
