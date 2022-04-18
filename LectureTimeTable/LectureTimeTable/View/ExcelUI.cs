using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class ExcelUI
    {
       
       
       LectureTimeUI lectureTimeUI = new LectureTimeUI();
        public void PrintExcelLectureTime(int yPosition)
        {
            

            Console.SetCursorPosition(0, yPosition);
            lectureTimeUI.PrintCenter("======================================================================== 2022학년도 1학기 강의 시간표 ======================================================================== ", 172);
            
            

        }

        public void PrintExcelData(List<int> list,int yPosition,string type)
        {
            Console.SetCursorPosition(0, yPosition);
          
            if(type == "Register")
            {
                for(int index = 1; index < LTTStart.registerList.Count; index++)
                {
                    if (list.Contains(LTTStart.registerList[index]))
                    {
                        list.Remove(LTTStart.registerList[index]);
                    }
                }
            }
            for (int rowIndex = 0; rowIndex < list.Count; rowIndex++)
            {
               
                PrintExcelElement(3,yPosition+ rowIndex, list[rowIndex], 1); // x,y좌표값이라 매직넘버 처리는안했습니다
                PrintExcelElement(7, yPosition+ rowIndex, list[rowIndex], 2);
                PrintExcelElement(26, yPosition+ rowIndex, list[rowIndex], 3);
                PrintExcelElement(36, yPosition + rowIndex, list[rowIndex], 4);
                PrintExcelElement(42, yPosition + rowIndex, list[rowIndex], 5);
                PrintExcelElement(75, yPosition + rowIndex, list[rowIndex], 6);
                PrintExcelElement(88, yPosition + rowIndex, list[rowIndex], 7);
                PrintExcelElement(93, yPosition + rowIndex, list[rowIndex], 8);
                PrintExcelElement(98, yPosition + rowIndex, list[rowIndex], 9);
                PrintExcelElement(129, yPosition + rowIndex, list[rowIndex], 10);
                PrintExcelElement(143, yPosition + rowIndex, list[rowIndex], 11);
                PrintExcelElement(169, yPosition + rowIndex, list[rowIndex], 12);


                Console.WriteLine();
            }

            Console.WriteLine();
            lectureTimeUI.PrintCenter("============================================================================================================================================================================ ", 180);

        }
        public void PrintExcelBack()
        {
            lectureTimeUI.PrintCenter("ESC : 뒤로 돌아가기", 180);
        }

        private void PrintExcelElement(int xPosition,int yPosition,  int rowIndex,  int columnIndex)
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(LTTStart.excelData.Data.GetValue(rowIndex, columnIndex));
        }
        
    }
}
