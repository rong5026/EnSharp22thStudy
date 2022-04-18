using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class InterestsLectureUI
    {
	
		LectureTimeUI lectureTimeUI =new LectureTimeUI();
		ExcelUI excelUI = new ExcelUI();
		private string selectFirst;
		public void PrintInterestsLectureMenu(int selectNum)// 관심과목 담기 리스트 출력
		{
			
			
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
			lectureTimeUI.PrintCenter("ENTER :선택하기 ESC :뒤로가기 ", Constants.WIDTH + 46);

			lectureTimeUI.PrintCenter("=========================================== 관심과목 담기 메뉴 ===========================================", Constants.WIDTH - 7);
			Console.WriteLine("\n\n");

			PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_SEARCH, "관심 과목 분야별 검색");
			PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_LIST, "관심 과목 강의 내역");
			PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_SCHEDULE, "관심 과목 시간표");
			PrintInterestsLectureMenuList(selectNum, Constants.LECTURE_DELETE, "관심 과목 삭제하기");
		

			Console.WriteLine("\n\n");
			lectureTimeUI.PrintCenter("=========================================================================================================", Constants.WIDTH + 1);

			lectureTimeUI.PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.", Constants.WIDTH - 12);
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
			lectureTimeUI.PrintCenter("ENTER : 선택하기 ESC : 뒤로가기 ", Constants.WIDTH + 65);

			lectureTimeUI.PrintCenter("=========================================== 강의 시간표 조회 ===========================================", Constants.WIDTH - 7);
			Console.WriteLine();
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.LECTURE_DEPARTMENT, "개설 학과 전공");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.LECTURE_DIVISION, "학수번호 / 분반");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.LECTURE_NAME, "교과목명");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.PROFESSOR, "교수명");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.GRADE, "학년");
			lectureTimeUI.PrintLectureTimeList(selectNum, Constants.CHECK, "조회");

			lectureTimeUI.PrintCenter("=========================================================================================================", Constants.WIDTH + 1);
			lectureTimeUI.PrintCenter(" ↑ , ↓ 키로 메뉴를 선택 후  ← 또는 → 키를 이용해 선택하세요.", Constants.WIDTH - 30);
			lectureTimeUI.PrintCenter("조건을 다 선택 후에는 ↑ , ↓ 키로 이동하여 [ 조회 ] 버튼을 눌러주세요", Constants.WIDTH - 30);


		}
	

		public void PrintInputInterestLecture(int number,int totalNumber,int xPosition, int yPosition) // 관심과목 등록 입력창
		{
			
			Console.SetCursorPosition(xPosition, yPosition);
			Console.Write( "등록 가능 학점 : {0}      담은 학점 : {1}      담을 과목 NO :                       ", totalNumber - number, number);
		}
		public void PrintInputDeleteLecture(int number) //관심과목 삭제 입력창
        {
			Console.SetCursorPosition(65, 5);
			Console.Write("         담은 학점 : {0}    삭제할 과목 NO :                      ", number);
		}

		public void PrintInterestStatus(int xPosition, int yPosition, string output) // 관심과목담기 성공,실패
																			   // 관심과목삭제 성공, 실패
        {		
			Console.SetCursorPosition(xPosition,yPosition);
			Console.CursorVisible = false;
			Console.Write(output);	
		}
		
		public void PrintSelectedList(List <int> list,string type) // 관심과목 or 수강과목 목록 출력
        {

			PrintSelectedListUI(0,4, type);
			excelUI.PrintExcelData(list, 10,"Interest") ;
			

			excelUI.PrintExcelBack(); // 뒤로가기
		}

		public void PrintSelectedListUI(int xPosition, int yPosition,string type)
        {
			Console.Clear();
			Console.SetCursorPosition(xPosition, yPosition);
			lectureTimeUI.PrintCenter("ESC : 나가기", Constants.WIDTH + 150);
			Console.WriteLine();
			if(type == "Interest")
				lectureTimeUI.PrintCenter("============================================================================ 관심 과목 강의 목록 ============================================================================", Constants.WIDTH - 8);
			else
				lectureTimeUI.PrintCenter("============================================================================ 수강 과목 강의 목록 ============================================================================", Constants.WIDTH - 8);
		}
	}
}
