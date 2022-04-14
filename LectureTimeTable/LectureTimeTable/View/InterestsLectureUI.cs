using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class InterestsLectureUI
    {
		StringSort sort = new StringSort();
		string selectFirst;
		public void PrintInterestsLectureMenu(int selectNum)
        {
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			sort.PrintCenter("ENTER :선택하기 ESC :뒤로가기 ", Constant.WIDTH + 46);

			sort.PrintCenter("============================= 관심과목 담기 메인메뉴 =============================", Constant.WIDTH - 8);
			Console.WriteLine("\n\n");

			PrintInterestsLectureMenuList(selectNum, 1, "관심 과목 분야별 검색");
			PrintInterestsLectureMenuList(selectNum, 2, "관심 과목 강의 내역");
			PrintInterestsLectureMenuList(selectNum, 3, "관심 과목 시간표");
			PrintInterestsLectureMenuList(selectNum, 4, "관심 과목 삭제");

			Console.WriteLine("\n\n");
			sort.PrintCenter("==================================================================================", Constant.WIDTH);

			sort.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", Constant.WIDTH - 12);
		}

		public void PrintInterestsLectureMenuList(int selectNum, int menuNumber, string menuName)
		{

			if (selectNum == menuNumber)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.WriteLine("                                                                                {0}  {1}", selectFirst, menuName);
			Console.ResetColor();

		}
	
	}
}
