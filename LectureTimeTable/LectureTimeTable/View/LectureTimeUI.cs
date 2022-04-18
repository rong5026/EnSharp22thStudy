using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class LectureTimeUI
    {

       
		private string selectFirst;

		public void PrintCenter(string data, int width) // 문구 센터에 정렬
		{
			Console.WriteLine(String.Format("{0}", data).PadLeft(width - ((width / 2) - (data.Length / 2))));
		}
		public void PrintLectureTime(int selectNum)
        {
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("\n\n\n\n\n\n");
            PrintCenter("ENTER : 선택하기 ESC : 뒤로가기 ", Constants.WIDTH+65);

            PrintCenter("=========================================== 강의 시간표 조회 ===========================================", Constants.WIDTH-7);
            Console.WriteLine();
			PrintLectureTimeList(selectNum, Constants.LECTURE_DEPARTMENT, "개설 학과 전공"); // 50 10 에 이제 리스트 보여주면됨
			PrintLectureTimeList(selectNum, Constants.LECTURE_DIVISION, "이수 구분");
			PrintLectureTimeList(selectNum, Constants.LECTURE_NAME, "교과목명");
			PrintLectureTimeList(selectNum, Constants.PROFESSOR, "교수명");
			PrintLectureTimeList(selectNum, Constants.GRADE, "학년");
			PrintLectureTimeList(selectNum, Constants.CHECK, "조회");

			PrintCenter("=========================================================================================================", Constants.WIDTH+1);
			PrintCenter(" ↑ 또는 ↓ 키를 눌러 메뉴고르고 ← 또는 → 키를 이용해 선택하세요.", Constants.WIDTH-30);
			PrintCenter("조건을 다 선택 후에는 ↑ , ↓ 키로 이동하여 [ 조회 ] 버튼을 눌러주세요", Constants.WIDTH - 30);

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
			Console.WriteLine("                                      {0}  {1}", selectFirst, menuName);
			Console.WriteLine();
			Console.ResetColor();

		}
		
		public void PrintLectureDepartment(int selectNum)// 학과
        {
			Console.SetCursorPosition(60, 10);
			PrintLectureHorisionList(selectNum, Constants.LECTURE_ALL, "전체");
			PrintLectureHorisionList(selectNum, Constants.COMPUTER_DEPARTMENT, "컴퓨터공학과");
			PrintLectureHorisionList(selectNum, Constants.INTELLIGENT_DEPARTMENT, "지능기전공학부");
			PrintLectureHorisionList(selectNum, Constants.SOFTWARE_DEPARTMENT, "소프트웨어학과");
			PrintLectureHorisionList(selectNum, Constants.AEROSPACE_DEPARTMENT, "기계항공우주공학부");

		}
		public void PrintLetureDivision(int selectNum) // 이수구분
        {
			Console.SetCursorPosition(60, 12);
			PrintLectureHorisionList(selectNum, Constants.LECTURE_ALL, "전체      ");
			PrintLectureHorisionList(selectNum, Constants.GYOYANG_PILSU_CLASS, "교양필수      ");
			PrintLectureHorisionList(selectNum, Constants.JEONGONG_PILSU_CLASS, "전공필수      ");
			PrintLectureHorisionList(selectNum, Constants.JEONGONG_SEONTAEG, "전공선택      ");
			
		}
		public void PrintLectureName() // 교과명 입력
		{
			Console.SetCursorPosition(60, 14);
			Console.Write("교과목명(1글자이상) : ");
		}
		public void PrintProfessorName() // 교수님이름 입력
		{
			Console.SetCursorPosition(60, 16);
			Console.Write("교수명(1글자이상) : ");
		}
		public void PrintStudyNumber() // 학수번호 입력
        {
			Console.SetCursorPosition(60, 12); //좌표
			Console.Write("학수번호(6자리수) : ");
		}
		public void PrintDivisionNumber() // 분반 입력
		{
			Console.SetCursorPosition(60, 13);//좌표
			Console.Write("분반(3자리수) : ");
		}
		public void PrintLectureClass(int selectNum) // 학년
        {
			Console.SetCursorPosition(60, 18);
			PrintLectureHorisionList(selectNum, Constants.LECTURE_ALL, "전체      ");
			PrintLectureHorisionList(selectNum, Constants.FIRST_CLASS, "1학년      ");
			PrintLectureHorisionList(selectNum, Constants.SECOND_CLASS, "2학년      ");
			PrintLectureHorisionList(selectNum, Constants.THIRD_CLASS, "3학년      ");
			PrintLectureHorisionList(selectNum, Constants.FOUR_CLASS, "4학년      ");
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
