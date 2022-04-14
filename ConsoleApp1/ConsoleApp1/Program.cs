using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
namespace LectureTimeTableExample
{
    class Program
    {
        // 바탕화면에 excelStudy.xlsx 파일을 다운로드 받은 후 실행해보기!
        // C#에서 Excel을 사용하는 자세한 방법은 검색을 통해 스스로 공부해봅시다.
        static void Main(string[] args)
        {
            bool check;
            while (true)
            {
              
                string input = Console.ReadLine();
                check = Regex.IsMatch(input, @"^[a-zA-Z0-9가-힣:+#()]{1,}$");
                Console.WriteLine(check);
            }
        }
    }
}
