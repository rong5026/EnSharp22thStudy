using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{


    internal class TimeTableUI
    {
        TimeTable timeTable = new TimeTable();
        InterestsLectureUI interestsLectureUI = new InterestsLectureUI();

        public void PrintLectureSchedule()
        {
            interestsLectureUI.PrintSelectedInterestListUI();  //관심과목 목록 UI
            Console.SetCursorPosition(0, 5);
            timeTable.ShowLectureSchedule(LTTStart.interestList); // 관심과목 시간표
        }
    }
}
