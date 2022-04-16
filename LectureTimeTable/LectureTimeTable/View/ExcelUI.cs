using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class ExcelUI
    {
       
        StringSortUI sort = new StringSortUI();
        

        public void PrintExcelLectureTime()
        {
            

            Console.SetCursorPosition(0, 26);
            sort.PrintCenter("======================================================================== 2022학년도 1학기 강의 시간표 ======================================================================== ", 172);
            
            

        }

        public void PrintExcelData(List<int> list,int yPosition)
        {
            Console.SetCursorPosition(0, yPosition);
          

            for (int rowIndex = 0; rowIndex < list.Count; rowIndex++)
            {
               
                PrintExcelElement(3,yPosition+ rowIndex, list[rowIndex], 1);
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
            sort.PrintCenter("============================================================================================================================================================================ ", 180);

        }
        public void PrintExcelBack()
        {      
            sort.PrintCenter("ESC : 뒤로 돌아가기", 180);
        }

        private void PrintExcelElement(int xPosition,int yPosition,  int rowIndex,  int columnIndex)
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(LTTStart.excelData.Data.GetValue(rowIndex, columnIndex));
        }
        
    }
}
