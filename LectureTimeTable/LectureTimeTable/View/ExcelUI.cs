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
        
        public void PrintExcelLectureTime()
        {
             //Console.WriteLine(excelData.Data.GetValue(1, 1));

            Console.SetCursorPosition(0, 26);
            sort.PrintCenter("======================================================================== 2022학년도 1학기 강의 시간표 ======================================================================== ", 172);
            
            

        }

        public void PrintExcelData(int department, int division, string className, string progessor, int grade ,int yPosition)
        {
            Console.SetCursorPosition(0, yPosition);
            sort.PrintCenter("======================================================================== 2022학년도 1학기 강의 시간표 ======================================================================== ", 172);

            /*Console.WriteLine("   NO  개설학과전공       학수번호  분반  교과목명                         이수구분     학년 학점 요일 및 강의시간               강의실        메인교수명                강의언어", 140);
            */
            Console.SetCursorPosition(0, yPosition+2);
            for(int columnIndex = 1; columnIndex <= 185; columnIndex++)
            {
               
                PrintExcelElement(3,yPosition+ columnIndex, columnIndex,1);
                PrintExcelElement(7, yPosition+ columnIndex, columnIndex,2);
                PrintExcelElement(26, yPosition+ columnIndex, columnIndex,3);
                PrintExcelElement(36, yPosition + columnIndex, columnIndex,4);
                PrintExcelElement(42, yPosition + columnIndex, columnIndex,5);
                PrintExcelElement(75, yPosition + columnIndex, columnIndex,6);
                PrintExcelElement(88, yPosition + columnIndex, columnIndex,7);
                PrintExcelElement(93, yPosition + columnIndex, columnIndex,8);
                PrintExcelElement(98, yPosition + columnIndex, columnIndex,9);
                PrintExcelElement(129, yPosition + columnIndex, columnIndex,10);
                PrintExcelElement(143, yPosition + columnIndex, columnIndex,11);
                PrintExcelElement(169, yPosition + columnIndex, columnIndex,12);


                Console.WriteLine();
            }
            Console.SetCursorPosition(175, 28);
            //Console.WriteLine("ㅇㄹ");
        }

        private void PrintExcelElement(int xPosition,int yPosition, int rowIndex ,int columnIndex)
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(LTTStart.excelData.Data.GetValue(rowIndex, columnIndex));
        }
        
    }
}
