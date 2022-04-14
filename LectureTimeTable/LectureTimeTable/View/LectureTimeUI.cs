using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class LectureTimeUI
    {

        StringSort sort = new StringSort();
		string selectFirst;


		public void PrintLectureTime(int selectNum)
        {
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
            sort.PrintCenter("ENTER : 선택하기 ESC : 뒤로가기 ", 215);

            sort.PrintCenter("=========================================== 강의 시간표 조회 ===========================================", 143);
            Console.WriteLine();
			PrintLectureTimeList(selectNum, 1, "개설 학과 전공"); // 50 10 에 이제 리스트 보여주면됨
			PrintLectureTimeList(selectNum, 2, "이수 구분");
			PrintLectureTimeList(selectNum, 3, "교과목명");
			PrintLectureTimeList(selectNum, 4, "교수명");
			PrintLectureTimeList(selectNum, 5, "학년");
			PrintLectureTimeList(selectNum, 6, "조회");

			sort.PrintCenter("=========================================================================================================", 151);
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
			Console.WriteLine("                       {0}  {1}", selectFirst, menuName);
			Console.WriteLine();
			Console.ResetColor();

		}
		
		public void PrintLectureDepartment(int selectNum)
        {
			Console.SetCursorPosition(45, 10);
			PrintLectureHorisionList(selectNum, 1, "전체");
			PrintLectureHorisionList(selectNum, 2, "컴퓨터공학과");
			PrintLectureHorisionList(selectNum, 3, "지능기전공학부");
			PrintLectureHorisionList(selectNum, 4, "소프트웨어학과");
			PrintLectureHorisionList(selectNum, 5, "기계항공우주공학부");

		}
		public void PrintLetureDivision(int selectNum)
        {
			Console.SetCursorPosition(45, 12);
			PrintLectureHorisionList(selectNum, 1, "전체      ");
			PrintLectureHorisionList(selectNum, 2, "교양필수      ");
			PrintLectureHorisionList(selectNum, 3, "전공필수      ");
			PrintLectureHorisionList(selectNum, 4, "전공선택      ");
			
		}
		public void PrintLectureClass(int selectNum)
        {
			Console.SetCursorPosition(45, 18);
			PrintLectureHorisionList(selectNum, 1, "전체      ");
			PrintLectureHorisionList(selectNum, 2, "1학년      ");
			PrintLectureHorisionList(selectNum, 3, "2학년      ");
			PrintLectureHorisionList(selectNum, 5, "3학년      ");
			PrintLectureHorisionList(selectNum, 6, "4학년      ");
		}
		public void PrintLectureHorisionList(int selectNum, int menuNumber, string menuName)
		{

			if (selectNum == menuNumber)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			
			Console.Write( selectFirst+" "+menuName+" ");
			Console.ResetColor();
		}

	


	}
}
