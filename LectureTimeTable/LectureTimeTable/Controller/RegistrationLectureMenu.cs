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
        LectureTimeMenu lectureTimeMenu = new LectureTimeMenu();
        SelectionMenu menu = new SelectionMenu();
        InterestsLectureUI interestsLectureUI = new InterestsLectureUI();
        InterestLectureMenu interestLectureMenu = new InterestLectureMenu();
        Exception exception = new Exception();
        ExcelUI excelUI = new ExcelUI();
        int menuNumber;
        int input;
        int searchingCount;
        List<int> indexNO = new List<int>();
        public void StartRegisterationLectureMenu()
		{
			menuNumber = 0;
			Console.SetCursorPosition(0, 0);
			while (Constant.PROGRAM_ON)
			{
				registerationLectureUI.PrintRegisterationLectureMenu(1); // 수강신청 메인 메뉴
				Console.CursorVisible = false;
				menuNumber = menu.SelectVerticalMenu(4, "RegisterLecture", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)
                switch (menuNumber)
                {
                    case Constant.LECTURE_SEARCH:  // 수강 과목 분야별 검색
                        SearchRegistertLecture(indexNO);
                        break;
                    case Constant.LECTURE_LIST: // 수강 과목 강의 내역
                      
                        Console.Clear();
                        break;
                    case Constant.LECTURE_SCHEDULE: // 수강 과목 시간표                      
                        
                        Console.Clear();
                        break;
                    case Constant.LECTURE_DELETE: // 수강 과목 삭제
                       
                        break;
                    case Constant.STOP:
                        return;


                }
                menuNumber--;
            }

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
            while (Constant.PROGRAM_ON)
            {

                input = menu.SelectVerticalMenu(7, "RegisterLectureSearch", input);// 수직메뉴

                switch (input)
                {
                    case Constant.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        searchingCount = lectureTimeMenu.StartLectureDepartmentMenu(list, searchingCount);
                        break;
                    case Constant.LECTURE_DIVISION: // 학수번호/분반
                        searchingCount = lectureTimeMenu.StartStudyClassNumber(list, searchingCount);
                        break;
                    case Constant.LECTURE_NAME: // 교과목명
                        searchingCount = lectureTimeMenu.StartLectureName(list, searchingCount);
                        break;
                    case Constant.PROFESSOR: // 교수명
                        searchingCount = lectureTimeMenu.StartProfessorName(list, searchingCount);
                        break;
                    case Constant.GRADE: // 학년
                        searchingCount = lectureTimeMenu.StartLectureClassMenu(list, searchingCount);
                        break;                   
                    case Constant.CHECK: // 수강과목신청
                        StartRegisterExcelCheck(list, 30);
                        Console.Clear();
                        return;
                    case Constant.Interest: // 관심과목
                        return;
                    case Constant.STOP: // 뒤로가기
                        Console.Clear();
                        return;


                }
                input--;

            }

        }

        private void StartRegisterExcelCheck(List<int> list, int yPosition) // 수강과목신청
        {

           interestsLectureUI.PrintInputInterestLecture(LTTStart.registerNumber,65,25); // 담을과목 선택 UI
           excelUI.PrintExcelLectureTime(); // 강의시간표 시작 UI
           excelUI.PrintExcelData(list, yPosition); // y좌표
           list.Clear();
            SelectRegisterLecture(); //수강과목번호 입력 후 리스트에 추가

        }

        public void SelectRegisterLecture() // 수강과목번호 입력 후 리스트에 추가
        {
            string classNO;

            while (Constant.PROGRAM_ON) // 수강과목 선택
            {

                classNO = exception.EnterLectureNO(125, 25); // 입력

                if (classNO == "")
                    break;
                if (LTTStart.registerList.Contains(Convert.ToInt16(classNO) + 1))//수강과목List에 같은 No가 있을때
                {
                    interestsLectureUI.PrintInterestStatus(65, 25, "실패! 이미 수강과목 리스트에 담겼있습니다!!       ESC : 나가기               "); //수강신청실패!
                    interestLectureMenu.BackESC();
                    return;
                }

                LTTStart.registerList.Add(Convert.ToInt16(classNO) + 1); // 관심과목에 없으면 추가
                LTTStart.registerNumber += Convert.ToInt16(LTTStart.excelData.Data.GetValue(Convert.ToInt16(classNO) + 1, 8)); // 관심과목 담은 학점
                interestsLectureUI.PrintInterestStatus(65, 25, "성공! 수강과목 리스트에 담겼습니다!!      ESC : 나가기                     ");
                // 수강신청 성공!
                interestLectureMenu.BackESC();
                return;

            }
        }
    }
}
