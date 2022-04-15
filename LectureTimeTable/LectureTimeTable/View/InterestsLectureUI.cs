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

			sort.PrintCenter("=========================================== 관심과목 담기 메뉴 ===========================================", Constant.WIDTH - 7);
			Console.WriteLine("\n\n");

			PrintInterestsLectureMenuList(selectNum, 1, "관심 과목 분야별 검색");
			PrintInterestsLectureMenuList(selectNum, 2, "관심 과목 강의 내역");
			PrintInterestsLectureMenuList(selectNum, 3, "관심 과목 시간표");
			PrintInterestsLectureMenuList(selectNum, 4, "관심 과목 삭제하기");
		

			Console.WriteLine("\n\n");
			sort.PrintCenter("=========================================================================================================", Constant.WIDTH + 1);

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

		

		public void PrintInterestLecture(int selectNum)// 관심과목 담기 분야별 검색
		{

			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			sort.PrintCenter("ENTER : 선택하기 ESC : 뒤로가기 ", Constant.WIDTH + 65);

			sort.PrintCenter("=========================================== 강의 시간표 조회 ===========================================", Constant.WIDTH - 7);
			Console.WriteLine();
			lectureTimeUI.PrintLectureTimeList(selectNum, 1, "개설 학과 전공");
			lectureTimeUI.PrintLectureTimeList(selectNum, 2, "학수번호 / 분반");
			lectureTimeUI.PrintLectureTimeList(selectNum, 3, "교과목명");
			lectureTimeUI.PrintLectureTimeList(selectNum, 4, "교수명");
			lectureTimeUI.PrintLectureTimeList(selectNum, 5, "학년");
			lectureTimeUI.PrintLectureTimeList(selectNum, 6, "조회");

			sort.PrintCenter("=========================================================================================================", Constant.WIDTH + 1);
			sort.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", Constant.WIDTH - 15);

			
		}
	

		public void PrintInputInterestLecture()
		{
			
			Console.SetCursorPosition(65, 23);
			Console.Write( "등록 가능 학점 : {0}      담은 학점 : {1}      담을 과목 NO : ", 24 - LTTStart.interestNumber, LTTStart.interestNumber);
		}

		public void PrintSuccessInterest() // 관심과목담기 성공
        {
			Console.SetCursorPosition(65, 23);
			Console.Write("성공! 관심과목 리스트에 담겼습니다!!      ESC : 나가기                     ");
		}
		public void PrintFailInterest() // 관심과목담기 실패
        {
			Console.SetCursorPosition(65, 23);
			Console.Write("실패! 이미 관심과목 리스트에 담겼있습니다!!       ESC : 나가기               ");
		}

	}
}
