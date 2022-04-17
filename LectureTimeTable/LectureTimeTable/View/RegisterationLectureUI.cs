using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class RegisterationLectureUI
    {
		StringSortUI sort = new StringSortUI();
		InterestsLectureUI interestsLectureUI = new InterestsLectureUI();
		LectureTimeUI lectureTimeUI = new LectureTimeUI();
		
		public void PrintRegisterationLectureMenu(int selectNum)// 수강신청 리스트 출력
		{


			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			sort.PrintCenter("ENTER :선택하기 ESC :뒤로가기 ", Constant.WIDTH + 46);

			sort.PrintCenter("=========================================== 수강신청 메인 메뉴 ===========================================", Constant.WIDTH - 7);
			Console.WriteLine("\n\n");

			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, 1, "수강 과목 분야별 검색");
			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, 2, "수강 신청 강의 내역");
			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, 3, "수강 신청 과목 시간표");
			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, 4, "수강 과목 삭제  ");


			Console.WriteLine("\n\n");
			sort.PrintCenter("=========================================================================================================", Constant.WIDTH + 1);

			sort.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", Constant.WIDTH - 12);
		}

		public void PrintRegisterationLecture(int selectNum)// 수강신청 담기 분야별 검색
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
			lectureTimeUI.PrintLectureTimeList(selectNum, 7, "관심과목에서 신청하기");

			sort.PrintCenter("=========================================================================================================", Constant.WIDTH + 1);
			sort.PrintCenter(" ↑ , ↓ 키로 메뉴를 선택 후  ← 또는 → 키를 이용해 선택하세요.", Constant.WIDTH - 30);
			sort.PrintCenter("조건을 다 선택 후에는 ↑ , ↓ 키로 이동하여 [ 조회 ] 버튼을 눌러주세요", Constant.WIDTH - 30);


		}
		
		public void PrintSelectedRegisterListUI(int xPosition, int yPosition)
		{
			Console.Clear();
			Console.SetCursorPosition(xPosition, yPosition);
			sort.PrintCenter("ESC : 나가기", Constant.WIDTH + 150);
			Console.WriteLine();
			sort.PrintCenter("============================================================================ 수강 과목 강의 목록 ============================================================================", Constant.WIDTH - 8);
		}

	
	}
}
