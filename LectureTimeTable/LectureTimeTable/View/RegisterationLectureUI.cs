using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class RegisterationLectureUI
    {
		
		InterestsLectureUI interestsLectureUI = new InterestsLectureUI();
		LectureTimeUI lectureTimeUI = new LectureTimeUI();
		
		public void PrintRegisterationLectureMenu(int selectNum)// 수강신청 리스트 출력
		{


			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			lectureTimeUI.PrintCenter("ENTER :선택하기 ESC :뒤로가기 ", Constants.WIDTH + 46);

			lectureTimeUI.PrintCenter("=========================================== 수강신청 메인 메뉴 ===========================================", Constants.WIDTH - 7);
			Console.WriteLine("\n\n");

			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_SEARCH, "수강 과목 분야별 검색");
			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_LIST, "수강 신청 강의 내역");
			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_SCHEDULE, "수강 신청 과목 시간표");
			interestsLectureUI.PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_DELETE, "수강 과목 삭제  ");


			Console.WriteLine("\n\n");
			lectureTimeUI.PrintCenter("=========================================================================================================", Constants.WIDTH + 1);

			lectureTimeUI.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", Constants.WIDTH - 12);
		}

		public void PrintRegisterationLecture(int selectNum)// 수강신청 담기 분야별 검색
		{

			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			lectureTimeUI.PrintCenter("ENTER : 선택하기 ESC : 뒤로가기 ", Constants.WIDTH + 65);

			lectureTimeUI.PrintCenter("=========================================== 강의 시간표 조회 ===========================================", Constants.WIDTH - 7);
			Console.WriteLine();
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.LECTURE_DEPARTMENT, "개설 학과 전공");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.LECTURE_CLASSNUMBER, "학수번호 / 분반");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.LECTURE_NAME, "교과목명");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.PROFESSOR, "교수명");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.GRADE, "학년");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.CHECK, "조회");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.INTEREST, "관심과목에서 신청하기");

			lectureTimeUI.PrintCenter("=========================================================================================================", Constants.WIDTH + 1);
			lectureTimeUI.PrintCenter(" ↑ , ↓ 키로 메뉴를 선택 후  ← 또는 → 키를 이용해 선택하세요.", Constants.WIDTH - 30);
			lectureTimeUI.PrintCenter("조건을 다 선택 후에는 ↑ , ↓ 키로 이동하여 [ 조회 ] 버튼을 눌러주세요", Constants.WIDTH - 30);


		}
		
		public void PrintSelectedRegisterListUI(int xPosition, int yPosition)
		{
			Console.Clear();
			Console.SetCursorPosition(xPosition, yPosition);
			lectureTimeUI.PrintCenter("ESC : 나가기", Constants.WIDTH + 150);
			Console.WriteLine();
			lectureTimeUI.PrintCenter("============================================================================ 수강 과목 강의 목록 ============================================================================", Constants.WIDTH - 8);
		}

	
	}
}
