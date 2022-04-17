using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
namespace LectureTimeTable
{
    internal class LTTMain
    {
        
        static void Main(string[] args)
        {

            LTTStart start = new LTTStart();
            start.StartLectureTimeTable();

            //등록되어있는 ID
            //ID = 19011617
            //PW = 11111111
           


        }
    }
}
