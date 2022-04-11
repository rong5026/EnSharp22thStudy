using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class ManagerModeUI
    {
		LibraryUI UI = new LibraryUI();
		public void PrintRegisterBook()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                                 책 등 록                            │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│   뒤로가기 : 처음에 ESC키  입력하기 : 아무런 키 1개 입력 후 입력    │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");

			Console.WriteLine();
			Console.WriteLine(" 책 제목 : ");//11 8
			Console.WriteLine(" 작가 : "); // 8 9
			Console.WriteLine(" 출판사 : ");//10 10
			Console.WriteLine(" 수량 : ");//8 11
			Console.WriteLine(" 가격 : ");//8,12
			Console.WriteLine(" 출시일 : "); //10,13




		}
		public void PrintBookInputType()
		{
			Console.WriteLine(" 책 제목 입력 형식 : 모든문자");//11 8
			Console.WriteLine(" 작가 입력 형식 : 영어,한글 1글자 이상"); // 8 9
			Console.WriteLine(" 출판사 입력 형식 : 영어,한글 1글자이상");//10 10
			Console.WriteLine(" 수량 입력 형식 : 1~999");//8 11
			Console.WriteLine(" 가격 입력 형식 : 1 ~ 9999999");//8,12
			Console.WriteLine(" 출시일 입력 형식 예시 : 20xx-04-01 or  19xx-12-05 "); //10,13

			Console.SetCursorPosition(11, 8);

		}
		public void PrintRegisterBookSuccess()
		{
			Console.WriteLine("┌------------------------------------------------┐");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│                책 등 록 완 료 !                │");
			Console.WriteLine("│                                                │");
			Console.WriteLine("│      (뒤로가려면 아무키 1개를 눌러주세요)      │");
			Console.WriteLine("└------------------------------------------------┘\n");
		}

		public void PrintEditBookCount()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                             책 수 량 수 정                          │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│    뒤로가기 : 처음에 ESC키   입력하기 : 아무키 1개 입력 후 입력)    │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");
			Console.WriteLine();
			Console.WriteLine(" 수정 할 책 ID : "); // 17 8
			Console.WriteLine(" 수정 할 책 수량 : "); // 19 9
			Console.WriteLine(" 수정 할 책 ID 형식 :  1~999 수 입력"); // 17 8
			Console.WriteLine(" 수정 할 책 수량 형식: 1~999 수 입력 "); // 19 9

			UI.PrintBookList(null, null, null); // 책리스트 출력

			Console.SetCursorPosition(17, 8);
		}
		public void PrintEditBookCountSuccess()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                           수 량 수 정 완 료 !                       │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                 (뒤로가려면 아무키 1개를 눌러주세요)                │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");
			UI.PrintBookList(null, null, null); // 책리스트 출력
			Console.SetCursorPosition(0, 0);

		}
		public void PrintEditBookCountFail()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                      유효한 도서 ID가 아닙니다!                     │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                 (뒤로가려면 아무키 1개를 눌러주세요)                │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");
			UI.PrintBookList(null, null, null); // 책리스트 출력
			Console.SetCursorPosition(0, 0);

		}
		public void PrintDeleteBook()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                            삭 제 할 책 선 택                        │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│    뒤로가기 : 처음에 ESC키   입력하기 : 아무키 1개 입력 후 입력)    │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");
			Console.WriteLine();
			Console.WriteLine(" 삭제 할 책 ID : "); // 17 8
			Console.WriteLine(" 삭제 할 책 수량 : ");//18 9
			Console.WriteLine(" 삭제 할 책 ID 형식 :  1~999 수 입력"); // 17 8
			Console.WriteLine(" 삭제 할 책 수량 형식: 1~999 수 입력 "); // 19 9
			UI.PrintBookList(null, null, null); // 책리스트 출력

			Console.SetCursorPosition(17, 8);
		}
		public void PrintDeleteBookSuccess()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                              책 삭 제 완 료 !                       │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                 (뒤로가려면 아무키 1개를 눌러주세요)                │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");

			UI.PrintBookList(null, null, null); // 책리스트 출력

			Console.SetCursorPosition(0, 0);
		}
		public void PrintDeleteBookFail()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                              책 삭 제 실 패 !                       │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                 (뒤로가려면 아무키 1개를 눌러주세요)                │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");



		}

		public void PrintUserList()
		{
			Console.WriteLine("┌---------------------------------------------------------------------┐");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                             유 저 목 록                             │");
			Console.WriteLine("│                                                                     │");
			Console.WriteLine("│                 (뒤로가려면 아무키 1개를 눌러주세요)                │");
			Console.WriteLine("└---------------------------------------------------------------------┘\n");
			for (int index = 1; index < LibraryStart.userList.Count; index++)
			{
				Console.WriteLine("=====================================================================");
				Console.WriteLine(" User ID : {0}", LibraryStart.userList[index].Id);//38 21
				Console.WriteLine(" User PW : {0}", LibraryStart.userList[index].Password);//38 22
				Console.WriteLine(" User PW : {0}", LibraryStart.userList[index].Password);//38 23
				Console.WriteLine(" User Name : {0}", LibraryStart.userList[index].Name);//41 24
				Console.WriteLine(" User Age : {0}", LibraryStart.userList[index].Age);//39 25
				Console.WriteLine(" User PhoneNumber : {0}", LibraryStart.userList[index].PhoneNumber);//41 26
				Console.WriteLine(" User Address : {0}", LibraryStart.userList[index].Address);//38 27
			}
		}

	
	}
}
