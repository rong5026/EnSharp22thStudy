using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class InterestLectureMenu
    {

        SelectionMenu menu= new SelectionMenu();
        InterestsLectureUI interestsLectureUI= new InterestsLectureUI();
        LectureTimeMenu lectureTimeMenu= new LectureTimeMenu();
        LectureTimeUI lectureTimeUI= new LectureTimeUI();
        Exception exception = new Exception();
        int menuNumber;
        int input;
        
   
        List<int> indexNO=new List<int>();
        ExcelUI excelUI = new ExcelUI();
        int searchingCount; // 몇번 조건을 찾았는지

        string classNumber="";
        string divisionNumber="";

    
        public void StartInterestLectureMenu()
        {
            
            menuNumber = 0;
            Console.SetCursorPosition(0, 0);
   
            while (Constant.PROGRAM_ON)
            {
           

                interestsLectureUI.PrintInterestsLectureMenu(1); // 관심과목 담기 메인 메뉴
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "InterestLecture", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.INTERESTS_LECTURE_SEARCH:  // 관심 과목 분야별 검색
                        SearchInterestLecture(indexNO);
                        break;
                    case Constant.INTERESTS_LECTURE_LIST: // 관심 과목 강의 내역
                        break;
                    case Constant.INTERESTS_LECTURE_SCHEDULE: // 관심 과목 시간표
                        break;
                    case Constant.INTERESTS_LECTURE_DELETE: // 관심 과목 삭제
                        break;
                    case Constant.STOP:
                        return;


                }
                menuNumber--;
            }

        }

        public void SearchInterestLecture(List<int >list )
        {
            Console.Clear();
            interestsLectureUI.PrintInterestLecture(1); // 개설학과, 학수번호, 교과목,교수명,학년,조회 리스트
            Console.CursorVisible = false;

            list.Clear();
            list.Add(1); // 처음 1번에 있는 테마 정보저장

            input = 0;
            searchingCount = 0;
            while (Constant.PROGRAM_ON)
            {

                input = menu.SelectVerticalMenu(6, "InterestLectureSearch", input);// 수직메뉴 // 개설학과,학수번호 ...

                switch (input)
                {
                    case Constant.LECTURE_DEPARTMENT:  // 개설 학과 전공
                        searchingCount = lectureTimeMenu.StartLectureDepartmentMenu(list,searchingCount);
                        break;
                    case Constant.LECTURE_DIVISION: // 학수번호/분반
                        searchingCount = StartStudyClassNumber(list,searchingCount);                 
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
                    case Constant.CHECK: // 조회 및 관심과목신청
                        StartExcelCheck(list, 28);
                        return;
                    case Constant.STOP: // 뒤로가기
                        Console.Clear();
                        return;


                }
                input--;

            }

        }
        //학수벊로 분반 예외랑 조회 함수 만들어야함
        public int StartStudyClassNumber(List <int> list, int searchingCount) // 학수번호,분반
        {
            lectureTimeUI.PrintStudyNumber(); // 학수번호 입력창
            classNumber = exception.EnterStudyNumber(80, 12);
            Console.CursorVisible = false;//커서 숨김
            if (classNumber == "")
                return searchingCount + 1;
            lectureTimeUI.PrintDivisionNumber(); // 분반 입력창 
            divisionNumber = exception.EnterDivisionNumber(76, 13);

            Console.CursorVisible = false;//커서 숨김
            if (classNumber != "" && classNumber != "")
            {
                lectureTimeMenu.FindExcelindex(list, classNumber, 3, searchingCount);
                return lectureTimeMenu.FindExcelindex(list, divisionNumber, 4, searchingCount);
            }
            else
                return searchingCount + 1;

        }
        private void StartExcelCheck(List<int> list, int yPosition) // 조회하기 버튼
        {

            interestsLectureUI.PrintInputInterestLecture(); // 담을과목 선택 UI
            excelUI.PrintExcelLectureTime(); // 강의시간표 시작 UI
            excelUI.PrintExcelData(list, yPosition); // y좌표


            list.Clear();

         


        }
        public void SelectInterestLecture()
        {
            string classNO;

            while (Constant.PROGRAM_ON) // 관심과목담을 책선택
            {
                classNO = exception.EnterLectureNO(125, 23); // 입력

                if (classNO == "")
                    break;


                LTTStart.interestList.Add(Convert.ToInt16(classNO)); // 관심과목에 없으면 

            }
        }




    }


}
