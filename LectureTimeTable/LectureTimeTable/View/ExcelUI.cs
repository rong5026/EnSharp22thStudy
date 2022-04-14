using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class ExcelUI
    {
       
        StringSort sort = new StringSort();
        public void PrintExcelData(string department, string division, string className, string progessor, string grade )
        {
           
            Console.WriteLine("  NO  개설학과전공       학수번호  분반  교과목명    이수구분        학년 학점 요일 및 강의시간      강의실         메인교수명                 강의언어", 140);
        }
        public void PrintExcelLectureTime()
        {
           // Console.WriteLine(excelData.Data.GetValue(1, 1));

            Console.SetCursorPosition(0, 26);           
            sort.PrintCenter("========================================================== 2022학년도 1학기 강의 시간표 ========================================================== ", 180);
        }
    }
}
