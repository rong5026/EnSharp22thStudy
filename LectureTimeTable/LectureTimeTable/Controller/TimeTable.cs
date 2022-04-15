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
        int startHour;
        int startMinute;
        int endtHour;
        int endMinute;
        int count;
        int yPosition;

        string className;
        string classPlace;

        public void ShowLectureSchedule(List<int> list)
        {
            
           

            for (int index = 1; index < list.Count; index++)
            {
                FindTimeType( Convert.ToString(LTTStart.excelData.Data.GetValue(list[index], 9)), list[index]);
            }
        }
        public void FindTimeType(string timeData, int listNO)
        {

           

            day = Regex.Replace(timeData, @"[^가-힣]", ""); // 요일만 가져오기
            time = Regex.Replace(timeData, "[^0-9]", ""); // 숫자만 가져옴

            if (day.Length == 1)
            {
                ShowLectureScheduleUnit(day[0], time, listNO);  // 월09001030
            }
               
            else if (time.Length == 4) //월 09001030 화 11001130
            {
                ShowLectureScheduleUnit(day[0], time.Substring(0, 8), listNO);  // 월09001030
                ShowLectureScheduleUnit(day[1], time.Substring(8, 8), listNO);  // 화011001130
            }
            else
            {
                ShowLectureScheduleUnit(day[0], time, listNO);  // 월09001030
                ShowLectureScheduleUnit(day[1], time, listNO);  // 화011001130
            }
               

        }
        public void ShowLectureScheduleUnit(char day, string time, int listNO) // 문자 잘라서 요일 1개, 시간 숫자 8자리 09001030
        {
            

            for (int index = 0; index < FindTimeRepeatCount(time); index++)
            {
                className = Convert.ToString(LTTStart.excelData.Data.GetValue(listNO, 5));
                classPlace = Convert.ToString(LTTStart.excelData.Data.GetValue(listNO, 10));
                Console.SetCursorPosition(FindTimeXposition(day), FindTimeYposition(time, 6));
                Console.WriteLine(className);
                Console.SetCursorPosition(FindTimeXposition(day), FindTimeYposition(time, 6)+1);
                Console.WriteLine(classPlace);
            }

        }
        public int FindTimeYposition(string time,int initYposition) // 초기 y좌표는 11
        {
            startHour = Convert.ToInt16(time.Substring(0, 2));
            startMinute = Convert.ToInt16(time.Substring(2, 2));

            if (startMinute == 30)
                return (startHour - 9) * 4 + 2+ initYposition; // 초기 y좌표에 더해줌

            else
                return (startHour - 9) * 4+ initYposition;


        }
        public int FindTimeXposition(char day) // 날짜로 x좌표 확인
        {
            switch (day)
            {
                case '월':
                    return 13; 
                case '화':
                    return 46;
                case '수':
                    return 79;
                case '목':
                    return 112;
                case '금':
                    return 145;
                default:
                    return 0;
            }
        }

        public int FindTimeRepeatCount(string time) // 몇번 반복해서 프린트해야하는지
        {
           

            startHour = Convert.ToInt16(time.Substring(0, 2));
            startMinute = Convert.ToInt16(time.Substring(2, 2));
            endtHour = Convert.ToInt16(time.Substring(4, 2));
            endMinute = Convert.ToInt16(time.Substring(6, 2));

            return ((endtHour - startHour) *60 + endMinute- startMinute)/30; 

        }
      
       
        
    }
}
