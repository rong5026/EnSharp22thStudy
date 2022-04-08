using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library
{
    internal class LibraryUI
    {
		const Boolean PROGRAM_ON = true;
		const int WIDTH = 120;
		const int FIRST_TYPE = 1;
		string selectFirst;
		string selectSecond;
		int bookIndex;
		string bookTime;
		LoginUser loginUser=new LoginUser();


		public void PrintMainUI()
        {
			
			Console.WriteLine();
			Console.WriteLine("                                                     @@          @@");
			Console.WriteLine("                                                  (@@              @@)");
			Console.WriteLine("                     @@)               @@          @:    (:@@:)    :@          @@               (@@");
			Console.WriteLine("                    @                 :#            @@@@@@0@@0@@@@@@            #:                 @");
			Console.WriteLine("                   (##@@#:      (#@#<--(@@@@      _-@@            @@-_      @@@@)-->#@#)     :#@@##)");
			Console.WriteLine("                        (@@@@@@@@@         @@@@@@@                    @@@@@@@         @@@@@@@@@)\n");
			//
			Console.WriteLine("                 ####      ####    ########      ########             ###       ########      ####     ####  ");
			Console.WriteLine("                  ##        ##      ##     ##     ##     ##           ###        ##     ##     ##       ##    ");
			Console.WriteLine("                  ##        ##      ##    ###     ##      ##         ## ##       ##      ##     ##     ##     ");
			Console.WriteLine("                  ##        ##      ##  ##        ##     ##         ##   ##      ##     ##       ##  ##        ");
			Console.WriteLine("                  ##        ##      ##  ##        ##  ###          #########     ##  ###           ###         ");
			Console.WriteLine("                  ##        ##      ##    ###     ####   ##       ##       ##    ####   ##         ##           ");
			Console.WriteLine("                  ##        ##      ##     ###    ##       ##    ##         ##   ##       ##       ##           ");
			Console.WriteLine("                 ########  ####    #########     ####       ### ##           ## ####       ###    ####          \n");
			//
			Console.WriteLine("            @@)                                    * L I B R A R Y *                                     (@@");
			Console.WriteLine("           @     @@         @@@)                                                        (@@@         @@     @");
			Console.WriteLine("          @    _@  @       @          @@@@@@    _____@@#<<(==)>>#@@_____    @@@@@@          @       @  @_    @");
			Console.WriteLine("          (#@@#@       @@@@:@@@@@@@@@@  || @@@@@  | @ << (-==-) >> @ |  @@@@@ ||  @@@@@@@@@@:@@@@       @#@@#)");
			Console.WriteLine("               @@@@@@@@              @@@@@   |  @@@@ --<< (==) >>-- @@@@  |   @@@@@              @@@@@@@@");
			Console.WriteLine("                                      @   @###@@@  @@@@_        _@@@@  @@@###@   @");
			Console.WriteLine("                                                       @-  ()  -@");
			Console.WriteLine("                                                        @------@");
			Console.WriteLine("                                                         @@__@@");

			Console.WriteLine("                           ENTER : 선택                                             ESC : 나가기   \n");
		
		
		}

		
		public void PrintSelectUI(int selectNum,int type)  // type ->1.회원모드,관리자모드   2.로그인,회원가입
		{
			selectFirst = selectNum == 1 ? "●" : "○";
			selectSecond = selectNum == 2 ? "●" : "○";

			Console.Clear();
			PrintMainUI();  // main 이미지 출력

			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.Write("                                   │                 ");
			if (selectNum == 1) 
				if(type == 1)
					Console.ForegroundColor = ConsoleColor.Green;
				else
					Console.ForegroundColor = ConsoleColor.Red;
			if (type == FIRST_TYPE)
				Console.Write("{0}    유저모드", selectFirst);
			else
				Console.Write("{0}    로그인  ", selectFirst);

			Console.ResetColor();
			Console.WriteLine("                 │");
			Console.Write("                                   │                 ");

			if (selectNum == 2)
				if (type == 1)
					Console.ForegroundColor = ConsoleColor.Green;
				else
					Console.ForegroundColor = ConsoleColor.Red;

			if (type == FIRST_TYPE)
				Console.Write("{0}    관리자모드", selectSecond);
			else
				Console.Write("{0}    회원가입  ", selectSecond);
			Console.ResetColor();
			Console.WriteLine("               │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");

			Console.WriteLine("                                         ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");
		}
		public void PrintUserMenuUI(int selectNum)
        {
			Console.Clear();
			PrintMainUI();  // main 이미지 출력
			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");

			Console.Write("                                   │                 ");
			if (selectNum == 1)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  도서찾기", selectFirst);
			Console.ResetColor();
			Console.WriteLine("                   │");


			Console.Write("                                   │                 ");
			if (selectNum == 2)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  도서대여", selectFirst);
			Console.ResetColor();
			Console.WriteLine("                   │");

			Console.Write("                                   │                 ");
			if (selectNum == 3)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  도서대여확인", selectFirst);
			Console.ResetColor();
			Console.WriteLine("               │");

			Console.Write("                                   │                 ");
			if (selectNum == 4)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  도서반납", selectFirst);
			Console.ResetColor();
			Console.WriteLine("                   │");


			Console.Write("                                   │                 ");
			if (selectNum == 5)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  도서반납내역", selectFirst);
			Console.ResetColor();
			Console.WriteLine("               │");



			Console.Write("                                   │                 ");
			if (selectNum == 6)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  회원정보수정", selectFirst);
			Console.ResetColor();
			Console.WriteLine("               │");

			Console.Write("                                   │                 ");
			if (selectNum == 7)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  회원탈퇴", selectFirst);
			Console.ResetColor();
			Console.WriteLine("                   │");




			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");

			Console.WriteLine("                                         ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");


		}

		public void PrintProgramStop()
        {
			Console.Clear();
			PrintMainUI();  // main 이미지 출력

			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.Write("                                   │                   ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Program STOP");
			Console.ResetColor();
			Console.ResetColor();
			Console.WriteLine("                 │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");

		}

		public void PrintLogin()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                     로 그 인                   │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│          (뒤로가려면 ESC를 눌러주세요)         │");
			Console.WriteLine("└------------------------------------------------┘");
			Console.WriteLine("     User ID   : ");
			Console.Write(" User Password : "); 
			
		}
		public void PrintLoginFail()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│        아이디 또는 비밀번호가 틀렸습니다.      │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│  (아이디, 비밀번호 8~15자리 영문자+숫자 혼합)  │");
			Console.WriteLine("└------------------------------------------------┘");
		}
		public void PrintRegister()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                  회 원 가 입                   │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│          (뒤로가려면 ESC를 눌러주세요)         │");
			Console.WriteLine("└------------------------------------------------┘\n");
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : ");//38 7
			Console.WriteLine(" User PW (8~ 15글자 영어, 숫자포함) : ");//38 8
			Console.WriteLine(" User PW  (     Password 확인     ) : ");//38 9
			Console.WriteLine(" User Name (한글,영어 포함 2글자 이상) : ");//41 10
			Console.WriteLine(" User Age (   자연수 1세 ~ 200세   ) : ");//39 11
			Console.WriteLine(" User PhoneNumber (   01x-xxxx-xxxx  ) : ");//41 12
			    Console.Write(" User Address (     한글 주소     ) : ");//38 13

		}
		
		public void PrintSuccessRegister()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│               회 원 가 입 성 공 !!             │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│              (ENTER을 눌러주세요 !)            │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintSuccessLogin()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                 로 그 인 성 공 !!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│              (ENTER을 눌러주세요 !)            │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintSuccessRentBook()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│              대 여 하 기 성 공 !!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│       (뒤로가려면 아무키 1개를 눌러주세요      │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintSuccessEditUserData()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                정 보 수 정 완 료!              │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│              (ENTER을 눌러주세요 !)            │");
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
			Console.WriteLine("│              (ENTER을 눌러주세요 !)            │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintSearchBook()
        {
			Console.WriteLine();
			
			Console.WriteLine("  제목으로 찾기 : "); // 18,1
			Console.WriteLine("  작가명으로 찾기 : "); //19,2
			Console.Write("  출판사로 찾기 : ");//18,3
			Console.WriteLine("\n");
			Console.WriteLine("(뒤로가려면 ESC를 눌러주세요)");
			Console.WriteLine("(건너띄려면 p를 위에서 부터 건너띄고자 하는 검색옵션을 한번씩 눌러주세요)");

		}
		public void BorrowBook()
        {
			Console.WriteLine("┌----------------------------------------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                                                    │");
			Console.WriteLine("│    빌릴 책의 ID를 입력해 주세요 :                                                                  │"); //35, 2
			Console.WriteLine("│                                                                                                    │");
			Console.WriteLine("│    (뒤로가려면 ESC를 눌러주세요)                                                                   │");
			Console.WriteLine("└----------------------------------------------------------------------------------------------------┘\n");
		}
		public void ReturnBook()
        {
			Console.WriteLine("┌----------------------------------------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                                                    │");
			Console.WriteLine("│    반납 할 책의 ID를 입력해 주세요 :                                                               │"); //38 2
			Console.WriteLine("│                                                                                                    │");
			Console.WriteLine("│    (뒤로가려면 ESC를 눌러주세요)                                                                   │");
			Console.WriteLine("└----------------------------------------------------------------------------------------------------┘\n");
		}
		public void ReturnBookSuccess()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                   반 납  완 료                 │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│       (뒤로가려면 아무키 1개를 눌러주세요)     │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}
		public void PrintBookList(string name,string author, string publisher) // 이름 저자 출판사로 책 검색해서 출력
        {
			int[] validIndex = new int[LibraryStart.bookList.Count];
			int indexCount = 0;

			
			for(int index = 0; index < LibraryStart.bookList.Count; index++)
            {
				if (name != null && author == null && publisher == null) // O X X 
                {
					if(name == LibraryStart.bookList[index].Name )              
						validIndex[indexCount++] = index;
                    
                }
				else if(name == null && author != null && publisher == null) // X O X
                {
					if (author == LibraryStart.bookList[index].Author)
						validIndex[indexCount++] = index;
				}
				else if(name == null && author == null && publisher != null) // X X O
                {
					if (publisher == LibraryStart.bookList[index].Publisher)
						validIndex[indexCount++] = index;
				}
				else if(name != null && author != null && publisher == null)//O O X
                {
					if (name == LibraryStart.bookList[index].Name && author == LibraryStart.bookList[index].Author)
						validIndex[indexCount++] = index;
				}
				else if(name == null && author != null && publisher != null)//X O O
                {
					if (publisher == LibraryStart.bookList[index].Publisher && author == LibraryStart.bookList[index].Author)
						validIndex[indexCount++] = index;
				}
				else if(name != null && author == null && publisher != null) // O X O
                {
					if (publisher == LibraryStart.bookList[index].Publisher && name == LibraryStart.bookList[index].Name)
						validIndex[indexCount++] = index;
				}
				else if(name!=null && author !=null && publisher != null)//O O O
                {
					if ( name == LibraryStart.bookList[index].Name && author == LibraryStart.bookList[index].Author &&
						publisher == LibraryStart.bookList[index].Publisher)
						validIndex[indexCount++] = index;
				}
				/// X X X  값이 다없을때 
					
            }

			if (indexCount == 0)
			{
				indexCount = LibraryStart.bookList.Count;
				for(int index = 0; index < indexCount; index++)
					validIndex[index] = index;
			}

			for (int index = 0; index< indexCount; index++)
            {
				Console.WriteLine();
				Console.WriteLine("===========================================================================================================================\n");
				Console.WriteLine("책아이디 : {0} ",LibraryStart.bookList[validIndex[index]].Id);
				Console.WriteLine("책 제목 : {0} ", LibraryStart.bookList[validIndex[index]].Name);
				Console.WriteLine("작가 : {0} ", LibraryStart.bookList[validIndex[index]].Author);
				Console.WriteLine("출판사 : {0} ", LibraryStart.bookList[validIndex[index]].Publisher);
				Console.WriteLine("수량 : {0} ", LibraryStart.bookList[validIndex[index]].BookCount);
				Console.WriteLine("가격 : {0} ", LibraryStart.bookList[validIndex[index]].Price);
				Console.WriteLine("출시일 : {0} ", LibraryStart.bookList[validIndex[index]].Date);


			}




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
		public void PrintUserDateEdit()
        {
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│               개 인 정 보 바 꾸 기             │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│          (뒤로가려면 ESC를 눌러주세요)         │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}

		public void PrintUserData(int userId)
        {
			Console.WriteLine("        ◈현재 등록되어 있는 정보◈\n\n");
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : {0}",LibraryStart.userList[userId].Id);
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
			Console.WriteLine(" User Address (     한글 주소     ) : ");//38 27
			Console.SetCursorPosition(38, 21);

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

		




	}
}
