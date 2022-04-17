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
   
        private string day;
        private string time;
        private int startHour;
        private int startMinute;
        private int endtHour;
        private int endMinute; // 접근제한자 사용하기


        private string className;
        private string classPlace;

        public void ShowLectureSchedule(List<int> list)
        {
            

            for (int index = 1; index < list.Count; index++)
            {
                FindTimeType( Convert.ToString(LTTStart.excelData.Data.GetValue(list[index], 9)), list[index]);
            }
        }
        private void FindTimeType(string timeData, int listNO) // 요일의 타입 3가지
        {

           

            day = Regex.Replace(timeData, @"[^가-힣]", ""); // 요일만 가져오기
            time = Regex.Replace(timeData, @"[^0-9]", ""); // 숫자만 가져옴

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
        private void ShowLectureScheduleUnit(char day, string time, int listNO) // 문자 잘라서 요일 1개, 시간 숫자 8자리 09001030
        {
            

            for (int index = 0; index < FindTimeRepeatCount(time); index++) // 시간표요소 출력
            {
                className = Convert.ToString(LTTStart.excelData.Data.GetValue(listNO, 5));
                classPlace = Convert.ToString(LTTStart.excelData.Data.GetValue(listNO, 10));
                Console.SetCursorPosition(FindTimeXposition(day), FindTimeYposition(time, 7+index*2));
                Console.WriteLine(className);
                Console.SetCursorPosition(FindTimeXposition(day), FindTimeYposition(time, 7+index * 2) +1);
                Console.WriteLine(classPlace);
            }

        }
        private int FindTimeYposition(string time,int initYposition) {  // 출력해야할 Y좌표를 리턴
            startHour = Convert.ToInt16(time.Substring(0, 2));
            startMinute = Convert.ToInt16(time.Substring(2, 2));

            if (startMinute == 30)
                return (startHour - 8) * 4 + initYposition; // 초기 y좌표에 더해줌

            else
                return (startHour - 8) * 4-2+ initYposition;


        }
        private int FindTimeXposition(char day) // 날짜로 x좌표 확인
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

        private int FindTimeRepeatCount(string time) // 몇번 반복해서 프린트해야하는지
        {
           

            startHour = Convert.ToInt16(time.Substring(0, 2));
            startMinute = Convert.ToInt16(time.Substring(2, 2));
            endtHour = Convert.ToInt16(time.Substring(4, 2));
            endMinute = Convert.ToInt16(time.Substring(6, 2));

            return ((endtHour - startHour) *60 + endMinute- startMinute)/30; 

        }
        public int CheckTime(string timeData, List<int> list) // 선택한 과목의 시간데이터 ,관심리스트
        {
            string oneDay;
            string onTime;
            string secondDay;
            string secondTime;
            int result;
            day = Regex.Replace(timeData, @"[^가-힣]", ""); // 요일만 가져오기
            time = Regex.Replace(timeData, @"[^0-9]", ""); // 숫자만 가져옴

         

            for (int intdex = 1; intdex < list.Count; intdex++) // 관심리스트 전부돌면서 
            {
               
                className = Convert.ToString(LTTStart.excelData.Data.GetValue(list[intdex], 9)); //관심리스트에 있는 시간데이터를 문자형태로 받아옴
                secondDay = Regex.Replace(className, @"[^가-힣]", ""); // 요일만 가져오기
                secondTime = Regex.Replace(className, @"[^0-9]", ""); // 숫자만 가져옴

             

                if (day.Length == 1)
                {
                  

                    result = FindTime(day[0], time, secondDay, secondTime);
                    if (result == Constant.OVERLAP)
                        return Constant.OVERLAP; // 겹침
                }

                else if (time.Length == 4) //월 090010 30 화 11001130
                {
                 

                    result =FindTime(day[0], time.Substring(0, 8), secondDay, secondTime);
                    if (result == Constant.OVERLAP)
                        return Constant.OVERLAP; // 겹침
                    result =FindTime(day[1], time.Substring(8, 8), secondDay, secondTime);
                    if (result == Constant.OVERLAP)
                        return Constant.OVERLAP; // 겹침
                }
                else
                {
               

                    result =FindTime(day[0], time, secondDay, secondTime);
                    if (result == Constant.OVERLAP)
                        return Constant.OVERLAP; // 겹침
                    result =FindTime(day[1], time, secondDay, secondTime);
                    if (result == Constant.OVERLAP)
                        return Constant.OVERLAP; // 겹침

                }

            }
           
            return 0;

        }
        public int FindTime(char day,string time, string secondDay, string secondTime)
        {
            // 월,화,수
            // 8자리수 12001230
            //월화수목
            //8자리일수도 16자리일수도 

            int result;
            if (secondDay.Length == 1)
            {
           

                result = FindLastResult(day, time, secondDay[0], secondTime);
                if (result == Constant.OVERLAP)
                    return Constant.OVERLAP; // 겹침
            }

            else if (secondTime.Length == 4) //월 09001030 화 11001130
            {
                result = FindLastResult(day, time, secondDay[0], secondTime.Substring(0, 8));
                if (result == Constant.OVERLAP)
                    return Constant.OVERLAP; // 겹침
                result = FindLastResult(day, time, secondDay[1], secondTime.Substring(8, 8));
                if (result == Constant.OVERLAP)
                    return Constant.OVERLAP; // 겹침
            }
            else
            {
                result = FindLastResult(day, time, secondDay[0], secondTime);
                if (result == Constant.OVERLAP)
                    return Constant.OVERLAP; // 겹침
                result = FindLastResult(day, time, secondDay[1], secondTime);
                if (result == Constant.OVERLAP)
                    return Constant.OVERLAP; // 겹침

            }

            return 0; // 안겹침

        }

        public int FindLastResult(char day1, string time1, char day2, string time2)
        {
            // 월  , 화 , 수
            // 8자리수 10001130
            // 월, 화 , 수
            // 8자리수

            if (day1 == day2)
            {
                int small1 = ChangeTimeType(time1.Substring(0, 4));// 1000
                int big1 = ChangeTimeType(time1.Substring(4, 4));//1130
                int small2 = ChangeTimeType(time2.Substring(0, 4));
                int big2 = ChangeTimeType(time2.Substring(4, 4));

          
                if ((small1 < small2 && small2 > big1) || (small1 < big2 && big2 > big1)   || (small2 < small1 && small1 > big2) || (small2 < big1 && big1 > big2) || (small1 == small2 && big1 == big2))
                {
                    return Constant.OVERLAP; // 겹침
                }
            }
            return 0; // 안겹침 

        }

        private int ChangeTimeType(string time)
        {
            int hour = Convert.ToInt16( time.Substring(0, 2)); 
            int minute = Convert.ToInt16(time.Substring (2, 2));

            return hour*60+minute;
        }
       
        
    }
}
