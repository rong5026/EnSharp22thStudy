using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class LectureTimeUI
    {

        CenterSort sort = new CenterSort();
		string selectFirst;


		public void PrintLectureTime(int selectNum)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n");
            sort.PrintCenter("ENTER : 선택하기 ESC : 뒤로가기 ", 215);

            sort.PrintCenter("======================================== 강의 시간표 조회 ========================================", 143);
            Console.WriteLine("\n\n");
			PrintLectureTimeUI(selectNum);
            Console.WriteLine("\n\n");
            sort.PrintCenter("===================================================================================================", 151);
			sort.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", 135);
		}
		public void PrintLectureTimeList(int selectNum, int menuNumber, string menuName)
		{

			if (selectNum == menuNumber)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.WriteLine("                          {0}  {1}", selectFirst, menuName);
			Console.WriteLine();
			Console.ResetColor();

		}
		public void PrintLectureTimeUI(int selectNum)
		{

			PrintLectureTimeList(selectNum, 1, "개설 학과 전공");
			PrintLectureTimeList(selectNum, 2, "이수 구분");
			PrintLectureTimeList(selectNum, 3, "교과목명");
			PrintLectureTimeList(selectNum, 4, "교수명");
			PrintLectureTimeList(selectNum, 5, "학년");
			PrintLectureTimeList(selectNum, 6, "조회");


		}
	}
}
