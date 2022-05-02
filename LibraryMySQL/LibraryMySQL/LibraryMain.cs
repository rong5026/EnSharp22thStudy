using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LibraryMySQL
{
    internal class LibraryMain
    {            
        static void Main(string[] args)
        {
            //LibraryStart start = new LibraryStart();
            //start.StartLibrary();
            //   Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2022년도 1학기 강의시간표.txt");

            //File.Create(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Library로그기록.txt");

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Library로그기록.txt", "안녕");
           
           
        }
    }
}
