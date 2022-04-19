using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{
	internal class LibraryUI
	{
		MySQlData mySQlData;
		private string selectFirst;
		private string selectSecond;

		public LibraryUI(MySQlData mySQlData)
        {
			this.mySQlData = mySQlData;

		}
		public void PrintMainUI()
		{
			Console.SetCursorPosition(0, 0);
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


		public void PrintSelectUI(int selectNum, int type)  // type ->1.회원모드,관리자모드   2.로그인,회원가입
		{
			selectFirst = selectNum == 1 ? "●" : "○";
			selectSecond = selectNum == 2 ? "●" : "○";

			//Console.Clear();
			PrintMainUI();  // main 이미지 출력

			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.Write("                                   │                 ");
			if (selectNum == 1)
				if (type == 1)
					Console.ForegroundColor = ConsoleColor.Green;
				else
					Console.ForegroundColor = ConsoleColor.Red;
			if (type == Constants.FIRST_TYPE)
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

			if (type == Constants.FIRST_TYPE)
				Console.Write("{0}    관리자모드", selectSecond);
			else
				Console.Write("{0}    회원가입  ", selectSecond);
			Console.ResetColor();
			Console.WriteLine("               │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");

			Console.WriteLine("                                         ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");
		}
		
		public void PrintManagerMenuList(int selectNum, int menuNumber, string menuName)
		{
			Console.Write("                                   │                 ");
			if (selectNum == menuNumber)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.Write("{0}  {1}", selectFirst, menuName);
			Console.ResetColor();
			Console.WriteLine("                   │");
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



		public void ShowBookList(string name, string author, string publisher) // 이름 저자 출판사로 책 검색해서 출력
		{
			int[] validIndex = new int[8];
			int indexCount = 0;
			
			/*
			for (int index = 0; index < LibraryStart.bookList.Count; index++)
			{
				if (name != Constants.INPUT_EMPTY && author == Constants.INPUT_EMPTY && publisher == Constants.INPUT_EMPTY) // O X X 
				{
					if (name == LibraryStart.bookList[index].Name)
						validIndex[indexCount++] = index;

				}
				else if (name == Constants.INPUT_EMPTY && author != Constants.INPUT_EMPTY && publisher == Constants.INPUT_EMPTY) // X O X
				{
					if (author == LibraryStart.bookList[index].Author)
						validIndex[indexCount++] = index;
				}
				else if (name == Constants.INPUT_EMPTY && author == Constants.INPUT_EMPTY && publisher != Constants.INPUT_EMPTY) // X X O
				{
					if (publisher == LibraryStart.bookList[index].Publisher)
						validIndex[indexCount++] = index;
				}
				else if (name != null && author != null && publisher == null)//O O X
				{
					if (name == LibraryStart.bookList[index].Name && author == LibraryStart.bookList[index].Author)
						validIndex[indexCount++] = index;
				}
				else if (name == null && author != null && publisher != null)//X O O
				{
					if (publisher == LibraryStart.bookList[index].Publisher && author == LibraryStart.bookList[index].Author)
						validIndex[indexCount++] = index;
				}
				else if (name != null && author == null && publisher != null) // O X O
				{
					if (publisher == LibraryStart.bookList[index].Publisher && name == LibraryStart.bookList[index].Name)
						validIndex[indexCount++] = index;
				}
				else if (name != null && author != null && publisher != null)//O O O
				{
					if (name == LibraryStart.bookList[index].Name && author == LibraryStart.bookList[index].Author &&
						publisher == LibraryStart.bookList[index].Publisher)
						validIndex[indexCount++] = index;
				}
				/// X X X  값이 다없을때 

			}
			*/
			if (indexCount == 0)
			{
				indexCount = LibraryStart.bookList.Count;
				for (int index = 0; index < indexCount; index++)
					validIndex[index] = index;
			}

			for (int index = 0; index < indexCount; index++)
			{
				Console.WriteLine();
				Console.WriteLine("===========================================================================================================================\n");
				Console.WriteLine("책아이디 : {0} ", LibraryStart.bookList[validIndex[index]].Id);
				Console.WriteLine("책 제목 : {0} ", LibraryStart.bookList[validIndex[index]].Name);
				Console.WriteLine("작가 : {0} ", LibraryStart.bookList[validIndex[index]].Author);
				Console.WriteLine("출판사 : {0} ", LibraryStart.bookList[validIndex[index]].Publisher);
				Console.WriteLine("수량 : {0} ", LibraryStart.bookList[validIndex[index]].BookCount);
				Console.WriteLine("가격 : {0} ", LibraryStart.bookList[validIndex[index]].Price);
				Console.WriteLine("출시일 : {0} ", LibraryStart.bookList[validIndex[index]].Date);


			}
			Console.SetCursorPosition(0, 0);









		}

		public void PrintSearchBook() // 책찾기 
		{
			Console.WriteLine();

			Console.WriteLine("  제목으로 찾기 : "); // 18,1
			Console.WriteLine("  작가명으로 찾기 : "); //19,2
			Console.Write("  출판사로 찾기 : ");//18,3
			Console.WriteLine("\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(" ESC : 뒤로가기");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" ENTER : 입력하기");
			Console.ResetColor();
			Console.WriteLine(" 건너뛰고자 하는 목록은 ENTER을 눌러주세요");

		}

	}
}
