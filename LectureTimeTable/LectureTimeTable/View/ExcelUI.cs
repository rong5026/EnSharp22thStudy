using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class ExcelUI
    {
        ExcelData excelData = new ExcelData();
        public void PrintExcelData(string department, string division, string className, string progessor, string grade )
        {
            
        }
        public void Print()
        {
            Console.WriteLine(excelData.Data.GetValue(1, 1));
        }
    }
}
