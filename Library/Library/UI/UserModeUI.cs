using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserModeUI
    {
	
		int bookIndex;
		string bookTime;
		LoginedUser loginUser = new LoginedUser();

		public void PrintLogin()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                     로 그 인                   │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│    (뒤로가려면 아무런 ID,PW값을 넣어 ENTER)    │");
			Console.WriteLine("└------------------------------------------------┘");
			Console.WriteLine("     User ID   : ");
			Console.Write(" User Password : ");

		}
		public void PrintRealLogin()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│          로 그 인  하 시 겠 습 니 까 ?         │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│       예 : ENTER   아니오 :  아무키 1개        │");
			Console.WriteLine("└------------------------------------------------┘");
		}
		public void PrintLoginFail()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│        아이디 또는 비밀번호가 틀렸습니다.      │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│  (아이디, 비밀번호 8~15자리 영문자+숫자 혼합)  │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
			Console.WriteLine("└------------------------------------------------┘");
		}
		public void PrintRegister()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                  회 원 가 입                   │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│     (뒤로가려면 ESC, 입력하려면 아무키 1개)    │");
			Console.WriteLine("└------------------------------------------------┘\n");
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : ");//38 7
			Console.WriteLine(" User PW (8~ 15글자 영어, 숫자포함) : ");//38 8
			Console.WriteLine(" User PW  (     Password 확인     ) : ");//38 9
			Console.WriteLine(" User Name (한글,영어 포함 1글자 이상) : ");//41 10
			Console.WriteLine(" User Age (   자연수 0세 ~ 200세   ) : ");//39 11
			Console.WriteLine(" User PhoneNumber (   01x-xxxx-xxxx  ) : ");//41 12
			Console.Write(" User Address (한글+숫자 최소 3개이상입력 ) : ");//46 13

		}

		public void PrintSuccessRegister()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│               회 원 가 입 성 공 !!             │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintSuccessLogin()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                 로 그 인 성 공 !!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
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


		public void ReturnBook()
		{
			Console.WriteLine("┌----------------------------------------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                                                    │");
			Console.WriteLine("│    반납 할 책의 ID를 입력해 주세요 :                                                               │"); //38 2
			Console.WriteLine("│                                                                                                    │");
			Console.WriteLine("│    뒤로가기 : 처음에 ESC를 눌러주세요                                                              │");
			Console.WriteLine("│    입력하기: 아무런 값 1개를 입력 후 값을 입력해주세요.                                            │");
			Console.WriteLine("└----------------------------------------------------------------------------------------------------┘\n");
		}
		public void ReturnBookSuccess()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                   반 납  완 료                 │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│            (1초 후 화면이 넘어갑니다)          │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}

		public void PrintRentedBookList(int userIndex)
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                대 여 한 책 목 록               │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│       (뒤로가려면 아무키 1개를 눌러주세요)     │");
			Console.WriteLine("└------------------------------------------------┘\n");

			for (int index = 0; index < LibraryStart.userList[userIndex].RendtedBookId.Count; index++) // 빌려간 책의 수만큼 반복
			{
				Console.WriteLine();
				Console.WriteLine("===========================================================================================================================\n");
				Console.WriteLine("책아이디 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].Id);
				Console.WriteLine("책 제목 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].Name);
				Console.WriteLine("작가 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].Author);
				Console.WriteLine("출판사 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].Publisher);
				Console.WriteLine("수량 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].BookCount);
				Console.WriteLine("가격 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].Price);
				Console.WriteLine("출시일 : {0} ", LibraryStart.bookList[LibraryStart.userList[userIndex].RendtedBookId[index]].Date);


			}




		}
	


		public void PrintReturnBookTime()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                반 납 한 책 목 록               │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│       (뒤로가려면 아무키 1개를 눌러주세요)     │");
			Console.WriteLine("└------------------------------------------------┘\n");
			Console.WriteLine("\n");

			for (int index = 0; index < LibraryStart.userList[loginUser.SearchLoginUser()].ReturnBookTime.Count; index++)
			{
				bookIndex = LibraryStart.userList[loginUser.SearchLoginUser()].ReturnBookId[index];
				bookTime = LibraryStart.userList[loginUser.SearchLoginUser()].ReturnBookTime[index];
				Console.WriteLine("===========================================================================================================================\n");
				Console.WriteLine("반납시간 : {0} ", bookTime);
				Console.WriteLine("책아이디 : {0} ", LibraryStart.bookList[bookIndex].Id);
				Console.WriteLine("책 제목 : {0} ", LibraryStart.bookList[bookIndex].Name);
				Console.WriteLine("작가 : {0} ", LibraryStart.bookList[bookIndex].Author);
				Console.WriteLine("출판사 : {0} ", LibraryStart.bookList[bookIndex].Publisher);
				Console.WriteLine("수량 : {0} ", LibraryStart.bookList[bookIndex].BookCount);
				Console.WriteLine("가격 : {0} ", LibraryStart.bookList[bookIndex].Price);
				Console.WriteLine("출시일 : {0} ", LibraryStart.bookList[bookIndex].Date);

			}


		}
		public void PrintUserData(int userId)
		{
			Console.WriteLine("        ◈현재 등록되어 있는 정보◈\n\n");
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : {0}", LibraryStart.userList[userId].Id);
			Console.WriteLine(" User PW (8~ 15글자 영어, 숫자포함) : {0}", LibraryStart.userList[userId].Password);
			Console.WriteLine(" User Name (한글,영어 포함 2글자 이상) : {0}", LibraryStart.userList[userId].Name);
			Console.WriteLine(" User Age (   자연수 1세 ~ 200세   ) : {0}", LibraryStart.userList[userId].Age);
			Console.WriteLine(" User PhoneNumber (   01x-xxxx-xxxx  ) : {0}", LibraryStart.userList[userId].PhoneNumber);
			Console.Write(" User Address (     한글 주소     ) : {0}", LibraryStart.userList[userId].Address);
			Console.WriteLine("\n\n");
			Console.WriteLine("           ◈변경 할 정보 입력 ◈\n\n");
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : ");//38 21
			Console.WriteLine(" User PW (8~ 15글자 영어, 숫자포함) : ");//38 22
			Console.WriteLine(" User PW  (     Password 확인     ) : ");//38 23
			Console.WriteLine(" User Name (한글,영어 포함 2글자 이상) : ");//41 24
			Console.WriteLine(" User Age (   자연수 1세 ~ 200세   ) : ");//39 25
			Console.WriteLine(" User PhoneNumber (   01x-xxxx-xxxx  ) : ");//41 26
			    Console.Write(" User Address (한글+숫자 최소 3개이상입력 ) : ");//46 13
			Console.SetCursorPosition(38, 21);

		}	

		public void PrintMessage(int x, int y,string message)
        {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(x, y);
			Console.Write("{0}", message);
			Console.ResetColor();
		}
	}

}
