using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class InterestLectureMenu
    {

        SelectionMenu menu = new SelectionMenu();
        InterestsLectureUI interestsLectureUI = new InterestsLectureUI();
        LectureTimeMenu lectureTimeMenu = new LectureTimeMenu();
        Exception exception = new Exception();
        int menuNumber;
        int input;
        List<int> indexNO;
        ExcelUI excelUI = new ExcelUI();

        public InterestLectureMenu()
        {
            indexNO= new List<int>();
        }

        public void StartInterestLectureMenu()
        {
            indexNO.Add(1);
            menuNumber = 0;
            Console.SetCursorPosition(0, 0);
            while (Constant.PROGRAM_ON)
            {
                

                interestsLectureUI.PrintInterestsLectureMenu(1);
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "InterestLecture", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.INTERESTS_LECTURE_SEARCH:  // 관심 과목 분야별 검색
                        SearchInterestLucture();
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

        public void SearchInterestLucture()
        {
            interestsLectureUI.PrinInterestsDepartment(1);

            input = menu.SelectHorisionMenu(5, "LectureDepartment"); // 수평인 메뉴선택( 선택요소 수, 메뉴타입)

            if (input == Constant.STOP) // 학과리스트에서 ESC를 눌렀을 때 출력된 UI삭제;
                interestsLectureUI.PrintInterestsLectureMenu(1);

            switch (input)
            {
                case Constant.LECTURE_ALL: // 전체
                    // 전체 리스트 보여주고 위에 담을과목 NO입력
                    SelectInterestLecture(indexNO, 22, "");
                    return;
                case Constant.COMPUTER_DEPARTMENT: // 컴퓨터공학과
                    SelectInterestLecture(indexNO, 22, "컴퓨터공학과");
                    return;
                case Constant.INTELLIGENT_DEPARTMENT: // 지능기전공학부
                    SelectInterestLecture(indexNO, 22, "지능기전공학부");                   
                    break;
                case Constant.SOFTWARE_DEPARTMENT: // 소프트웨어학과
                    SelectInterestLecture(indexNO, 22, "소프트웨어학과");
                    break;
                case Constant.AEROSPACE_DEPARTMENT: // 기계항공우주공학부
                    SelectInterestLecture(indexNO, 22, "기계항공우주공학부");
                    break;
                default: break;
            }
        }
        
        public void SelectInterestLecture(List<int> list, int yPosition,string type) // 해당 List 출력
        {
            
            interestsLectureUI.PrintInputInterestLecture();
            lectureTimeMenu.FindExcelindex(type, 2);  // 학부목록에서 선택한 type목록만 출력
            excelUI.PrintExcelLectureTime(); // 강의시간표 시작 UI
            excelUI.PrintExcelData(list, yPosition); // y좌표

            //담을 과목 입력

            //Console.SetCursorPosition(2, 19);
            input =  Convert.ToInt16(  exception.EnterLectureNO(2,19));

            indexNO.Clear();

       
        }


    }


}
