using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class UserMenuUI
    {
        StringSort sort = new StringSort();
		string selectFirst;

		public void PrintUserMenu(int selectNum)
        {
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n\n");
			sort.PrintCenter("ESC : 뒤로가기 ",215);

			sort.PrintCenter("============================== 강좌조회 및 수강신청 ==============================", 143);
			Console.WriteLine("\n\n");
			PrintUserMenuUI(selectNum);
			Console.WriteLine("\n\n");
			sort.PrintCenter("==================================================================================", 150);

			sort.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.",135);
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
			Console.WriteLine("                                                               {0}  {1}", selectFirst, menuName);
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
