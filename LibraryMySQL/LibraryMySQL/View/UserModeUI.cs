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

		public void PrintSuccessRegister()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│               회 원 가 입 성 공 !!             │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│	          ESC : 뒤로가기                 │ ");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
	
		public void PrintSuccessRentBook()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│              대 여 하 기 성 공 !!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintFailRentBook()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│              대 여 하 기 실 패 !!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│   유요하지않은 ID이거나 책의 수량이 없습니다!  │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}

		public void PrintUserDateEdit()
		{
			Console.WriteLine("┌------------------------------------------------------┐");
			Console.WriteLine("│                                                      │");
			Console.WriteLine("│               개 인 정 보 바 꾸 기                   │");
			Console.WriteLine("│                                                      │");
			Console.WriteLine("│ 뒤로가려면 처음에 ESC, 입력하려면 아무런 값 1개 입력 │");
			Console.WriteLine("└------------------------------------------------------┘\n");
		}

		public void PrintSuccessEditUserData()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                정 보 수 정 완 료!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintDeleteUserId()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│         회 원 탈 퇴 하 시 겠 습 니 까 ?        │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│           예 : ENTER       아니오 : ESC        │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}

		public void PrintDeleteUserIdSuccess()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                회 원 탈 퇴 완 료               │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
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
