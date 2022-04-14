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
		LectureTimeUI lectureTimeUI =new LectureTimeUI();
		string selectFirst;
		public void PrintInterestsLectureMenu(int selectNum)// 관심과목 담기 리스트 출력
		{
			
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

		public void PrintInterestsLectureMenuList(int selectNum, int menuNumber, string menuName) // 관심과목 담기 선택시 색변경
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

		public void PrintSearchInterestsLecture(int selectNum)
        {
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			sort.PrintCenter("ENTER :선택하기 ESC :뒤로가기 ", Constant.WIDTH + 46);

			sort.PrintCenter("============================= 관심과목 검색 =============================", Constant.WIDTH - 8);
			Console.WriteLine("\n\n");

			Console.WriteLine("\n\n");
			sort.PrintCenter("==================================================================================", Constant.WIDTH);

			sort.PrintCenter(" → 또는 ← 키를 눌러 메뉴를 이동하세요.", Constant.WIDTH - 12);
		}

		public void PrinInterestsDepartment(int selectNum)// 관심과목담을 학과 선택
		{
			Console.SetCursorPosition(60, 10);
			lectureTimeUI.PrintLectureHorisionList(selectNum, 1, "전체");
			lectureTimeUI.PrintLectureHorisionList(selectNum, 2, "컴퓨터공학과");
			lectureTimeUI.PrintLectureHorisionList(selectNum, 3, "지능기전공학부");
			lectureTimeUI.PrintLectureHorisionList(selectNum, 4, "소프트웨어학과");
			lectureTimeUI.PrintLectureHorisionList(selectNum, 5, "기계항공우주공학부");
		}
		public void PrintInputInterestLecture()
        {
			Console.SetCursorPosition(2, 19); 
			Console.Write("등록 가능 학점 : {0}      담은 학점 : {1}      담을 과목 NO : ", 24 - LTTStart.applicationCredit, LTTStart.applicationCredit);
        }

	}
}
