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
            Console.WriteLine();
			PrintLectureTimeList(selectNum, 1, "개설 학과 전공"); // 50 10 에 이제 리스트 보여주면됨
			PrintLectureTimeList(selectNum, 2, "이수 구분");
			PrintLectureTimeList(selectNum, 3, "교과목명");
			PrintLectureTimeList(selectNum, 4, "교수명");
			PrintLectureTimeList(selectNum, 5, "학년");
			PrintLectureTimeList(selectNum, 6, "조회");

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
		
		public void PrintLectureDepartment(int selectNum)
        {
			Console.SetCursorPosition(50, 10);
			PrintLectureDepartmentList(selectNum, 1, "전체");
			PrintLectureDepartmentList(selectNum, 2, "컴퓨터공학과");
			PrintLectureDepartmentList(selectNum, 3, "지능기전공학부");
			PrintLectureDepartmentList(selectNum, 4, "소프트웨어학과");
			PrintLectureDepartmentList(selectNum, 5, "기계항공우주공학부");

		}
		public void PrintLectureDepartmentList(int selectNum, int menuNumber, string menuName)
		{

			if (selectNum == menuNumber)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			
			Console.Write("{0} {1}  ", selectFirst, menuName);
		
			Console.ResetColor();

		}


	}
}
