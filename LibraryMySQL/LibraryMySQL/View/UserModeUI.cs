using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class UserModeUI
	{
	
		
		int bookIndex;
		string bookTime;
		

		public void PrintLogin()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                     로 그 인                   │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│	   ESC : 뒤로가기  ENTER : 입력하기      │");
			Console.WriteLine("└------------------------------------------------┘");
			Console.WriteLine("     User ID   : ");
			Console.WriteLine(" User Password : ");

		}
	

		public void PrintRegister()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                  회 원 가 입                   │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│	   ESC : 뒤로가기  ENTER : 입력하기      │");
			Console.WriteLine("└------------------------------------------------┘\n");
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : ");//38 7
			Console.WriteLine(" User PW (8~ 15글자 영어, 숫자포함) : ");//38 8
			Console.WriteLine(" User PW  (     Password 확인     ) : ");//38 9
			Console.WriteLine(" User Name (한글,영어 포함 1글자 이상) : ");//41 10
			Console.WriteLine(" User Age (  0,자연수 0세 ~ 200세   ) : ");//39 11
			Console.WriteLine(" User PhoneNumber (   01x-xxxx-xxxx  ) : ");//41 12
			Console.Write(" User Address (한글+숫자 최소 3개이상입력 ) : ");//46 13

		}

		public void BorrowBook()
		{
			Console.WriteLine("┌-------------------------------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                                           │");
			Console.WriteLine("│    빌릴 책의 ID를 입력해 주세요 :                                                         │"); //35, 2
			Console.WriteLine("│    값의 범위 : 0~ 999                                                                     │");
			Console.WriteLine("│                                                                                           │");
			Console.WriteLine("│    뒤로가기 : 처음에 ESC를 눌러주세요                                                     │");
			Console.WriteLine("│    입력하기: 아무런 값 1개를 입력 후 값을 입력해주세요.                                   │");
			Console.WriteLine("└-------------------------------------------------------------------------------------------┘\n");
		}


		public void PrintSuccessRegister()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│               회 원 가 입 성 공 !!             │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                ENTER을 눌러주세요           │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintMessage(int x, int y,string message)
        {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(x, y);
			Console.Write("{0}", message);
			Console.ResetColor();
		}


		public void PrintErrorMessage(int x, int y, string errorMessage)// id,password 예외처리 실패
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(x, y);
			Console.Write(errorMessage);
			Console.ResetColor();
		}
	}

}
