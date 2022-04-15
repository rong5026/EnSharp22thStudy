using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LectureTimeTable
{
    internal class TimeTable
    {
        string input;
        string day;
        string time;
        public int FindTimeType(string timeData)
        {

            input = Regex.Replace(timeData, @"[^가-힣0-9]", ""); // 공백, 문자 제거

            day = Regex.Replace(timeData, @"[^가-힣]", ""); // 요일만 가져오기
            time = Regex.Replace(timeData, "[^0-9]", ""); // 숫자만 가져옴

            if (day.Length == 1)
                return 1;
            else if (time.Length == 4)
                return 3;
            else
                return 2;

        }
        
       /* public int FindTimeYposition()
        {

        }
        public int FindTimeXposition(string day) // 날짜로 x좌표 확인
        {
            switch (day)
            {
                case "월":
                    return 13; 
                case "화":
                    return 46;
                case "수":
                    return 79;
                case "목":
                    return 112;
                case "금":
                    return 145;
                default:
                    return 0;
            }
        }

        public int FindTimeRepeatCount(string time) // 몇번 반복해서 프린트해야하는지
        {
            int startHour;
            int startMinute;
            int endtHour;
            int endMinute;

            startHour = Convert.ToInt16(time.Substring(0, 1));
            startMinute = Convert.ToInt16(time.Substring(2, 3));
            endtHour = Convert.ToInt16(time.Substring(4, 5));
            endMinute = Convert.ToInt16(time.Substring(6, 7));

            return 0;

        }
        public void ShowLectureSchedule(string day, string time)
        {

            for(int index = 0; index < day.Length; index++) // 요일의 수만큼 출력
            {
               // if(day[index]==)
            }
        }
        */
    }
}
