using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class UserModeUI
	{
	
		
		LibraryUI libraryUI = new LibraryUI();
		

		public void PrintLogin()
		{
			libraryUI.PrintMainUI();
			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                     로 그 인                   │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │	    ESC : 뒤로가기  ENTER : 입력하기        │");
			Console.WriteLine("                                   └------------------------------------------------┘");
			Console.WriteLine("                                        User ID   : ");
			Console.WriteLine("                                    User Password : ");

		}
	

		public void PrintRegister()
		{
			libraryUI.PrintMainUI();
			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                     회 원 가 입                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │	      ESC : 뒤로가기  ENTER : 입력하기      │");
			Console.WriteLine("                                   └------------------------------------------------┘\n");
			Console.WriteLine("                                    User ID (8~ 15글자 영어, 숫자포함) : ");//38 7
			Console.WriteLine("                                    User PW (8~ 15글자 영어, 숫자포함) : ");//38 8
			Console.WriteLine("                                    User PW  (     Password 확인     ) : ");//38 9
			Console.WriteLine("                                    User Name (한글,영어 포함 1글자 이상) : ");//41 10
			Console.WriteLine("                                    User Age (  0,자연수 0세 ~ 200세   ) : ");//39 11
			Console.WriteLine("                                    User PhoneNumber (   01x-xxxx-xxxx  ) : ");//41 12
			Console.WriteLine("                                    User Address (  도로명 주소 - OO시 OO구  ) : ");//46 13

			Console.ForegroundColor = ConsoleColor.Red;
		
			Console.WriteLine("                                    ex) 경기도 수원시 영통구 영통로124");
			Console.WriteLine("                                    ex) 서울특별시 강남구 남부순환로 지하2744");
			Console.WriteLine("                                    ex) 서울특별시 구로구 경인로248-29");
			Console.ResetColor();
		}

		public void PrintUserDataEdit()
		{
			Console.WriteLine("                                   ┌------------------------------------------------------┐");
			Console.WriteLine("                                   │                                                      │");
			Console.WriteLine("                                   │                개 인 정 보 바 꾸 기                  │");
			Console.WriteLine("                                   │                                                      │");
			Console.WriteLine("                                   │           ESC : 뒤로가기     ENTER : 선택하기        │");
			Console.WriteLine("                                   └------------------------------------------------------┘\n");


		}

		public void PrintDeleteID()
        {
			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │             회원탈퇴 하시겠습니까?             │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │            ENTER : 예   ESC : 아니오           │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");
			Console.WriteLine("                                                                                                      ");
			Console.WriteLine("                                                                                                      ");
			Console.WriteLine("                                                                                                      ");
		}
		public void PrintDeleteIDFail()
		{
			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │    대여중인 도서가 있어 탈퇴가 불가능합니다 !  │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                 ESC : 뒤로가기                 │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");
			Console.WriteLine("                                                                                                      ");
			Console.WriteLine("                                                                                                      ");
			Console.WriteLine("                                                                                                      ");
		}
		public void PrintLoginedUserData(UserDTO userVO)
		{
			Console.WriteLine("                                                  ◈현재 등록되어 있는 정보◈\n\n");
			Console.WriteLine("                             User ID (8~ 15글자 영어, 숫자포함) : {0}", userVO.Id);
			Console.WriteLine("                             User PW (8~ 15글자 영어, 숫자포함) : {0}", userVO.Password);
			Console.WriteLine("                             User Name (한글,영어 포함 2글자 이상) : {0}", userVO.Name);
			Console.WriteLine("                             User Age (   자연수 1세 ~ 200세   ) : {0}", userVO.Age);
			Console.WriteLine("                             User PhoneNumber (   01x-xxxx-xxxx  ) : {0}", userVO.PhoneNumber);
			Console.WriteLine("                             User Address (     한글 주소     ) : {0}", userVO.Address);
			Console.WriteLine("\n\n");
			Console.WriteLine("                                                  ◈변경 할 정보 입력 ◈\n\n");

		}


	
		

		public void PrintBorrowBookMessage(string message,string reEnter) // 반납, 대여 main UI
		{
			Console.WriteLine("                                                                                           ");
			Console.WriteLine("                                                                                             ");
			Console.WriteLine("     {0}                                                                                                       ",message);
			Console.WriteLine("                                                                                                              ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("     ESC : 뒤로가기                                                                         ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("     ENTER : {0}                                                                        ",reEnter);
			Console.ResetColor();
			Console.WriteLine("                                                                                           \n");
		}
		
		public void PrintReturnRentBook(string type, string reEnter)
		{
		
			Console.WriteLine("                                                                                           ");
			Console.WriteLine("                                                                                            ");
			Console.WriteLine("     {0} 책의 ID를 입력해 주세요 :                                                         ",type);
			Console.WriteLine("     값의 범위 : 0~ 999                                                                     ");
			Console.WriteLine("                                                                                            ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("     ESC : 뒤로가기                                                                         ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("     ENTER : {0}                                                                        ", reEnter);
			Console.ResetColor();
			Console.WriteLine("                                                                                           \n");
		}
		public void PrintReturnRentBookList(string type)
		{
			Console.WriteLine("                                                                                           ");
			Console.WriteLine("                                                                                            ");
			Console.WriteLine("     {0} 책의 리스트                                                                     ",type);
			Console.WriteLine("                                                                                        ");
			Console.WriteLine("                                                                                            ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("     ESC : 뒤로가기                                                                         ");
			Console.ResetColor();
			Console.WriteLine("                                                                                      ");
			Console.WriteLine("                                                                                           \n");
		}

		public void PrintSuccessRegister() // 회원가입 성공 메시지 출력
		{
			Console.CursorVisible = Constants.isNONVISIBLE;
			libraryUI.PrintMainUI();
			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │               회 원 가 입 성 공 !!             │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   │                ENTER을 눌러주세요              │");
			Console.WriteLine("                                   └------------------------------------------------┘\n");
		}



		public void PrintMessage(int x, int y,string message) // 메세지 출력
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
