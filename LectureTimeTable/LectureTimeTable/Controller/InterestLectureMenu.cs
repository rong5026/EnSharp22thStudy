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
        int menuNumber;
        public void StartInterestLectureMenu()
        {
            menuNumber = 0;
            while (Constant.PROGRAM_ON)
            {
                Console.Clear();

                interestsLectureUI.PrintInterestsLectureMenu(1);
                Console.CursorVisible = false;
                menuNumber = menu.SelectVerticalMenu(4, "InterestLecture", menuNumber); // 수직으로된 메뉴 ( 메뉴목록의 수, 메뉴타입)

                switch (menuNumber)
                {
                    case Constant.INTERESTS_LECTURE_SEARCH:  // 관심 과목 분야별 검색
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

    }
}
