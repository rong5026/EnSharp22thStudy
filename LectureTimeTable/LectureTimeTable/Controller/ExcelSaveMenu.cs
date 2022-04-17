using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class ExcelSaveMenu
    {
        TimeTableUI timeTableUI = new TimeTableUI();
        TimeTable timeTable = new TimeTable();
      
        ConsoleKeyInfo keyInput;
        public void StartEnterExcel(){
            Console.SetCursorPosition(0, 1);
            timeTableUI.PrintLectureSchedule(LTTStart.registerList, "SaveExcel");

            while (Constant.PROGRAM_ON) // ESC키 누르면 뒤로가기
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                    return;

                else if(keyInput.Key == ConsoleKey.Enter)
                {
                    timeTable.SendExcel();
                    return;
                }


            }
        }
       
    }
}
