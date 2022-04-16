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
        RegisterationLectureUI registerationLectureUI = new RegisterationLectureUI();
        int hourOne;
        int minuteOne;
        int hourTwo;
        int minuteTwo;
        int sum;
     
        public void PrintLectureSchedule(List<int> list,string type) // 시간표 출력

        {
            Console.Clear();
            if (type == "Interest")
                interestsLectureUI.PrintSelectedInterestListUI(0, 3);  //관심과목 목록 UI
            else
                registerationLectureUI.PrintSelectedRegisterListUI(0, 3);
            PrintLectureScheduleUI(); // 요일 , 시간UI
            Console.SetCursorPosition(0, 5);
            timeTable.ShowLectureSchedule(list); // 관심과목 시간표
            Console.Write("====================================================================================================================================================================================");
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
        }


        public void PrintLectureScheduleUI() // 시간표 주변 UI
        {
            hourOne = 8;
            minuteOne = 30;
            Console.SetCursorPosition(13, 6);
            Console.Write("월");
            Console.SetCursorPosition(46, 6);
            Console.Write("화");
            Console.SetCursorPosition(79, 6);
            Console.Write("수");
            Console.SetCursorPosition(112, 6);
            Console.Write("목");
            Console.SetCursorPosition(145, 6);
            Console.Write("금");
            Console.SetCursorPosition(2, 7);

            for(int count = 0; count < 22; count++)
            {
                Console.SetCursorPosition(2, 7+2*count);
                Console.Write("{0}:{1}~", hourOne.ToString("00"), minuteOne.ToString("00"));

                sum  = hourOne*60 + minuteOne+30;
                hourOne = sum / 60;
                minuteOne = sum % 60;
                Console.WriteLine("{0}:{1}\n", hourOne.ToString("00"), minuteOne.ToString("00"));
            }
        }
    }
}
