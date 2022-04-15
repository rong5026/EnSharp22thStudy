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
            return 1;

        }
    }
}
