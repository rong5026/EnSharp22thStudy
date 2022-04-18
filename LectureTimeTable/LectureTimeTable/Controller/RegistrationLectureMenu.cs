using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
	
	internal class RegistrationLectureMenu
    {
		RegisterationLectureUI registerationLectureUI = new RegisterationLectureUI();
        InterestsLectureUI interestsLectureUI = new InterestsLectureUI();

        TimeTable timeTable;
        SelectionMenu menu;
        Exception exception;
        ExcelUI excelUI;
        LectureTimeMenu lectureTimeMenu;
        InterestLectureMenu interestLectureMenu;
        TimeTableUI timeTableUI;

        private int menuNumber;
        private int input;
        private int searchingCount;
        private string classNumber;
        List<int> indexNO;
        private bool result;

       
        public RegistrationLectureMenu(SelectionMenu menu ,Exception exception, ExcelUI excelUI, TimeTableUI timeTableUI, TimeTable timeTable)
        {
            this.timeTable = timeTable;
            this.timeTableUI = timeTableUI;
            this.menu = menu;
            this.exception = exception;
            this.excelUI = excelUI;
            indexNO = new List<int>();
            lectureTimeMenu = new LectureTimeMenu(menu, exception, excelUI);
            interestLectureMenu = new InterestLectureMenu(menu, exception, excelUI, timeTableUI, timeTable);

        }
        public void StartRegisterationLectureMenu()
		{
			menuNumber = 0;
			
            Console.SetCursorPosition(0, 0);
			while (Constants.PROGRAM_ON)
			{
				registerationLectureUI.PrintRegisterationLectureMenu(menuNumber+1); // 수강신청 메인 메뉴
				Console.CursorVisible = false;
				menuNumber = menu.SelectVerticalMenu(4, "RegisterLecture", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)
                switch (menuNumber)
                {
                    case Constants.LECTURE_SEARCH:  // 수강 과목 분야별 검색
                        SearchRegistertLecture(indexNO);
                        break;
                    case Constants.LECTURE_LIST: // 수강 과목 강의 내역
                        interestsLectureUI.PrintSelectedList(LTTStart.registerList,"Register");
                        interestLectureMenu.BackESC();
                        Console.Clear();
                        break;
                    case Constants.LECTURE_SCHEDULE: // 수강 과목 시간표                      
                        timeTableUI.PrintLectureSchedule(LTTStart.registerList, "Register");
                        interestLectureMenu.BackESC();
                        Console.Clear();
                        break;
                    case Constants.LECTURE_DELETE: // 수강 과목 삭제
                        DeleteRegisterLecture();
                        break;
                    case Constants.STOP:
                        return;


                }
                menuNumber--;
            }

		}
        public void DeleteRegisterLecture() // 수강과목 삭제
        {

            interestsLectureUI.PrintSelectedList(LTTStart.registerList,"Register"); // 수강과목 목록 출력
            interestsLectureUI.PrintInputDeleteLecture(LTTStart.registerNumber); //수강과목 삭제 입력창

            classNumber = exception.EnterLectureNO(109, 5);// 삭제할 NO입력

            if (classNumber != "")
                result = LTTStart.interestList.Contains(Convert.ToInt16(classNumber) + 1);
            else
            {
                Console.Clear();
                return;

            }
            if (result == false) // 수강과목에 삭제할 NO가 없을때 
            {
                //수강과목 삭제 식패!
                interestsLectureUI.PrintInterestStatus(65, 23, "실패! 수강과목 리스트 존재하지않는 NO입니다!      ESC: 나가기");
            }
            else
            {
                LTTStart.registerList.Remove(Convert.ToInt16(classNumber) + 1); // 해당 수강과목 삭제
                interestsLectureUI.PrintInterestStatus(65, 23, "성공! 수강과목 리스트에서 삭제되었습니다!.      ESC: 나가기");
                LTTStart.registerNumber -= Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNumber) + 1, 8)); // 수강과목 담은 학점

            }
            interestLectureMenu.BackESC();
            Console.Clear();


        }

        public void SearchRegistertLecture(List<int> list) // 목록 조건 선택
        {
            Console.Clear();
            registerationLectureUI.PrintRegisterationLecture(1); // 개설학과, 학수번호, 교과목,교수명,학년,조회 리스트
            Console.CursorVisible = false;

            list.Clear();
            list.Add(1); // 처음 1번에 있는 테마 정보저장

            input = 0; 
            searchingCount = 0;
            while (Constants.PROGRAM_ON)
            {

                input = menu.SelectVerticalMenu(7, "RegisterLectureSearch", input);// 수직메뉴

                switch (input)
                {
                    case Constants.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        searchingCount = lectureTimeMenu.StartLectureDepartmentMenu(list, searchingCount,"Register");
                        break;
                    case Constants.LECTURE_DIVISION: // 학수번호/분반
                        searchingCount = lectureTimeMenu.StartStudyClassNumber(list, searchingCount);
                        break;
                    case Constants.LECTURE_NAME: // 교과목명
                        searchingCount = lectureTimeMenu.StartLectureName(list, searchingCount);
                        break;
                    case Constants.PROFESSOR: // 교수명
                        searchingCount = lectureTimeMenu.StartProfessorName(list, searchingCount);
                        break;
                    case Constants.GRADE: // 학년
                        searchingCount = lectureTimeMenu.StartLectureClassMenu(list, searchingCount, "Register");
                        break;                   
                    case Constants.CHECK: // 수강과목신청
                        StartRegisterExcelCheck(list, 30);
                        input = 1;
                        Console.Clear();
                        return;
                    case Constants.INTEREST: // 관심과목                   
                        StartRegisterExcelCheck(LTTStart.interestList,30);                                         
                        input = 1;
                        Console.Clear();
                        return;
                    case Constants.STOP: // 뒤로가기
                        Console.Clear();
                        return;


                }
                input--;

            }

        }

        private void StartRegisterExcelCheck(List<int> list, int yPosition) // 수강과목신청
        {

           
           excelUI.PrintExcelLectureTime(28); // 강의시간표 시작 UI
           excelUI.PrintExcelData(list, yPosition,"Register"); // y좌표
          
           SelectRegisterLecture(list); //수강과목번호 입력 후 리스트에 추가
           

        }

        private int SelectRegisterLecture(List<int> list) // 수강목록 및 조건에 맞는 목록
        {
            string classNO;
            int selection;
            while (Constants.PROGRAM_ON) // 수강과목 선택
            {
                interestsLectureUI.PrintInputInterestLecture(LTTStart.registerNumber, 21, 65, 27); // 담을과목 선택 UI
                classNO = exception.EnterLectureNO(125, 27); // 입력

                if (classNO == Constants.INPUT_EMPTY)
                    break;

               
                if (LTTStart.registerList.Contains(Convert.ToInt16(classNO) + 1))//수강신청List에 같은 No가 있을때
                {
                    interestsLectureUI.PrintInterestStatus(65, 27, "실패! 이미 수강과목 리스트에 담겼있습니다!!       ESC : 나가기   ENTER : 다시입력              "); //수강신청실패!
                    selection = interestLectureMenu.Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectRegisterLecture(list);
                    return Constants.STOP;
                }
                else if( list.Contains(Convert.ToInt16(classNO) + 1)==false) // 출력된LIST에  해당 No없을때 
                {
                    interestsLectureUI.PrintInterestStatus(65, 27, "실패! 리스트에 없는 NO 입니다!!       ESC : 나가기   ENTER : 다시입력              "); //수강신청실패!
                    
                    selection = interestLectureMenu.Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectRegisterLecture(list);
                    return Constants.STOP;
                } 
                else if(LTTStart.registerNumber + Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO) + 1, 8)) > 24)
                {
                    interestsLectureUI.PrintInterestStatus(65, 27, "실패! 최대학점을 넘어섭니다!!       ESC : 나가기   ENTER : 다시입력              "); //수강신청실패!
                    selection = interestLectureMenu.Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectRegisterLecture(list);
                    return Constants.STOP;
                }
                else if (timeTable.CheckTime(Convert.ToString(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO) + 1, 9)), LTTStart.registerList) == 1)
                {
                    interestsLectureUI.PrintInterestStatus(65, 27, "실패!  등록하신 시간표와 시간이 겹칩니다!  ESC : 나가기   ENTER : 다시입력         "); //수강신청실패!
                    selection = interestLectureMenu.Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectRegisterLecture(list);
                    return Constants.STOP;
                }
                else if(LTTStart.registerNumber + Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO) + 1, 8))>21)
                {
                    interestsLectureUI.PrintInterestStatus(65, 27, "실패!  최대로 담을 수 있는 학점을 초과합니다!  ESC : 나가기   ENTER : 다시입력         "); //관담 실패!
                    selection = interestLectureMenu.Reinput();
                    if (selection == Constants.REINPUT)
                        return SelectRegisterLecture(list);
                    return Constants.STOP;
                }
                    LTTStart.registerList.Add(Convert.ToInt16(classNO) + 1); // 수강과목에 없으면 추가
                LTTStart.registerNumber += Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO) + 1, 8)); // 수강과목 담은 학점
                interestsLectureUI.PrintInterestStatus(65, 27, "성공! 수강과목 리스트에 담겼습니다!!      ESC : 나가기   ENTER : 다시입력                   ");

               

                // 수강신청 성공!
                selection = interestLectureMenu.Reinput();
                if (selection == Constants.REINPUT)                                  
                    return SelectRegisterLecture(list);              
                return Constants.STOP;

            }
            return Constants.STOP;
        }
    }
}
