using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class UserMenuUI
    {
		LectureTimeUI lectureTimeUI = new LectureTimeUI();
		private string selectFirst;

		public void PrintUserMenu(int selectNum)
        {
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			lectureTimeUI.PrintCenter("ENTER :선택하기 ESC :뒤로가기 ", Constant.WIDTH + 46);

			lectureTimeUI.PrintCenter("============================== 강좌조회 및 수강신청 ==============================", Constant.WIDTH-8);
			Console.WriteLine("\n\n");
			PrintUserMenuUI(selectNum);
			Console.WriteLine("\n\n");
			lectureTimeUI.PrintCenter("==================================================================================", Constant.WIDTH);

			lectureTimeUI.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", Constant.WIDTH-12);
		}

		public void PrintUserMenuList(int selectNum, int menuNumber, string menuName)
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
		public void PrintUserMenuUI(int selectNum)
		{
			
			PrintUserMenuList(selectNum, 1, "강의 시간표 조회");
			PrintUserMenuList(selectNum, 2, "관심과목 담기");
			PrintUserMenuList(selectNum, 3, "수강신청");
			PrintUserMenuList(selectNum, 4, "수강신청내역조회");
		

		}
	}
}
