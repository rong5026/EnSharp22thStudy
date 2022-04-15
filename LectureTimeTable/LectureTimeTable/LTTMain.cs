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

           // LTTStart start = new LTTStart();
           // start.LTT();
            
            try
            {
                // Excel Application 객체 생성
                Excel.Application application = new Excel.Application();

                // Workbook 객체 생성 및 파일 오픈 (바탕화면에 있는 excelStudy.xlsx 가져옴)
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2022년도 1학기 강의시간표.xlsx");

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.get_Range("A1", "L185") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 데이터 출력

            

                string a = Convert.ToString( data.GetValue(21, 9));
                a = Regex.Replace(a, @"[^0-9]", "");

                int A = Convert.ToInt16(a.Substring(8, 2));
                int B = Convert.ToInt16(a.Substring(2, 2));

                Console.WriteLine(a);
                Console.WriteLine(A);
                Console.Write(B);
                //Console.WriteLine(data.GetValue(2, 2));
              

                // 한글은 1개에 2칸 영어는 1칸  숫자는 1칸

                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
            

           
           







        }
    }
}
