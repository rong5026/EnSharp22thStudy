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


		public LibraryUI()
        {
			mySQlData = MySQlData.Instance();
		}
	
		public void PrintMainUI()
		{
			Console.SetWindowSize(125, 50);
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
			Console.WriteLine("                                                                                    ");
		}
		
		public void PrintAdminMenuList(int selectNum, int menuNumber, string menuName)
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

		public void PrintEditMenuList(int selectNum, int menuNumber, string menuName)
		{
			
			if (selectNum == menuNumber)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				selectFirst = "●";
			}
			else
				selectFirst = "○";
			Console.WriteLine("                             {0}  {1}", selectFirst, menuName);
			Console.ResetColor();

		}
		public void PrintAdminMenuUI(int selectNum)
		{
			
			PrintMainUI();  // main 이미지 출력

			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");

			PrintAdminMenuList(selectNum, 1, "도서찾기");
			PrintAdminMenuList(selectNum, 2, "도서추가");
			PrintAdminMenuList(selectNum, 3, "도서삭제");
			PrintAdminMenuList(selectNum, 4, "도서수정");
			PrintAdminMenuList(selectNum, 5, "회원관리");
			PrintAdminMenuList(selectNum, 6, "대여상황");

			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");

			Console.WriteLine("                                         ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");

		}
		
		public void PrintAdminBookEditUI(int selectNum)
		{

			Console.SetCursorPosition(0, 27);
			PrintEditMenuList(selectNum, 1, " 책 제목 (영어, 한글, 숫자 1개 이상) :");
			PrintEditMenuList(selectNum, 2, " 작가 (   영어, 한글 1글자 이상  )   :");
			PrintEditMenuList(selectNum, 3, " 출판사 (영어, 한글, 숫자 1개 이상)  :");
			PrintEditMenuList(selectNum, 4, " 수량 (    1~999 사이의 자연수   )   :");
			PrintEditMenuList(selectNum, 5, " 가격 (   1~9999999 사이의 자연수  ) :");
			PrintEditMenuList(selectNum, 6, " 출시일 (    19xx or 20xx-xx-xx    ) :");
			PrintEditMenuList(selectNum, 7, "     ** 책 정보 수정하기 ** \n");



			Console.WriteLine("                                            ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");
			Console.WriteLine("                                         변경하고자 하는 항목을 선택 후 변경해주세요.");
			Console.WriteLine("                                       회원정보 수정하기 항목을 클릭하면 변경이 완료됩니다.");
		}
		public void PrintUserMenuUI(int selectNum)
		{
		
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

		public void PrintEditUI(int selectNum)
        {

			Console.SetCursorPosition(0, 22);
			PrintEditMenuList(selectNum, 1, " User ID (8~ 15글자 영어, 숫자포함) :");
			PrintEditMenuList(selectNum, 2, " User PW (8~ 15글자 영어, 숫자포함) :");
			PrintEditMenuList(selectNum, 3, " User Name (한글,영어 포함 2글자 이상) :");
			PrintEditMenuList(selectNum, 4, " User Age (  0,자연수 0세 ~ 200세   ) :");
			PrintEditMenuList(selectNum, 5, " User PhoneNumber (   01x-xxxx-xxxx  ) :");
			PrintEditMenuList(selectNum, 6, " User Address (도로명 주소 형식 ) :");
			PrintEditMenuList(selectNum, 7, "     ** 회원정보 수정하기 ** \n");




			Console.WriteLine("                                            ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");
			Console.WriteLine("                                         변경하고자 하는 항목을 선택 후 변경해주세요.");
			Console.WriteLine("                                       회원정보 수정하기 항목을 클릭하면 변경이 완료됩니다.");
		}


	
		public void ShowBorrowedBookList(List<BookVO> list,string type)
		{
			for (int index = 0; index < list.Count; index++)
			{
				Console.WriteLine();
				Console.WriteLine("===========================================================================================================================\n");
				Console.WriteLine("책아이디  : {0} ", list[index].Id);
				Console.WriteLine("책 제목   : {0} ", list[index].Name);
				Console.WriteLine("작가      : {0} ", list[index].Author);
				Console.WriteLine("출판사    : {0} ", list[index].Publisher);
				Console.WriteLine("수량      : {0} ", list[index].BookCount);
				Console.WriteLine("가격      : {0} ", list[index].Price);
				Console.WriteLine("출시일    : {0} ", list[index].Date);
				if(type !="반납책")
					Console.WriteLine("{0} 시간  : {1} ",type, list[index].Time);


			}
			Console.SetCursorPosition(0, 0);

		}
		public void ShowBookList(string name, string author, string publisher,List<BookVO> list) // 이름 저자 출판사로 책 검색해서 출력
		{
			

			int[] validIndex = new int[list.Count];
			int indexCount = 0;

		
	
			for (int index = 0; index < list.Count; index++)
			{
				if (name != Constants.INPUT_EMPTY && author == Constants.INPUT_EMPTY && publisher == Constants.INPUT_EMPTY) // O X X 
				{
					if ( list[index].Name.Contains(name))
						validIndex[indexCount++] = index;

				}
				else if (name == Constants.INPUT_EMPTY && author != Constants.INPUT_EMPTY && publisher == Constants.INPUT_EMPTY) // X O X
				{
					if (list[index].Author.Contains(author))
						validIndex[indexCount++] = index;
				}
				else if (name == Constants.INPUT_EMPTY && author == Constants.INPUT_EMPTY && publisher != Constants.INPUT_EMPTY) // X X O
				{
					if (list[index].Publisher.Contains(publisher))
						validIndex[indexCount++] = index;
				}
				else if (name != Constants.INPUT_EMPTY && author != Constants.INPUT_EMPTY && publisher == Constants.INPUT_EMPTY)//O O X
				{
					if (list[index].Name.Contains(name) && list[index].Author.Contains(author))
						validIndex[indexCount++] = index;
				}
				else if (name == Constants.INPUT_EMPTY && author != Constants.INPUT_EMPTY && publisher != Constants.INPUT_EMPTY)//X O O
				{
					if (list[index].Publisher.Contains(publisher) && list[index].Author.Contains(author))
						validIndex[indexCount++] = index;
				}
				else if (name != Constants.INPUT_EMPTY && author == Constants.INPUT_EMPTY && publisher != Constants.INPUT_EMPTY) // O X O
				{
					if (list[index].Publisher.Contains(publisher) && list[index].Name.Contains(name))
						validIndex[indexCount++] = index;
				}
				else if (name != Constants.INPUT_EMPTY && author != Constants.INPUT_EMPTY && publisher != Constants.INPUT_EMPTY)//O O O
				{
					if (list[index].Name.Contains(name) && list[index].Author.Contains(author) &&
						list[index].Publisher.Contains(publisher))
						validIndex[indexCount++] = index;
				}
				/// X X X  값이 다없을때 

			}

			if (indexCount == 0)
			{
				indexCount = list.Count;
				for (int index = 0; index < indexCount; index++)
					validIndex[index] = index;
			}

			for (int index = 0; index < indexCount; index++)
			{
				Console.WriteLine();
				Console.WriteLine("===========================================================================================================================\n");
				Console.WriteLine("책아이디 : {0} ", list[validIndex[index]].Id);
				Console.WriteLine("책 제목  : {0} ", list[validIndex[index]].Name);
				Console.WriteLine("작가     : {0} ", list[validIndex[index]].Author);
				Console.WriteLine("출판사   : {0} ", list[validIndex[index]].Publisher);
				Console.WriteLine("수량     : {0} ", list[validIndex[index]].BookCount);
				Console.WriteLine("가격     : {0} ", list[validIndex[index]].Price);
				Console.WriteLine("출시일   : {0} ", list[validIndex[index]].Date);


			}
			Console.SetCursorPosition(0, 0);





		}

		public void PrintSearchBook(string type) // 책찾기 
		{
			Console.SetCursorPosition(0, 0);
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
			if (type != "Return")
				Console.WriteLine(" 건너뛰고자 하는 목록은 ENTER을 눌러주세요");
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(" ENTER : 다시 검색하기   ESC : 뒤로가기");
				Console.ResetColor();
			}

		}

	}
}
