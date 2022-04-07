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
			string selectFirst = selectNum == 1 ? "●" : "○";
			string selectSecond = selectNum == 2 ? "●" : "○";

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
			Console.WriteLine(" User ID (8~ 15글자 영어, 숫자포함) : ");
			Console.WriteLine(" User PW (8~ 15글자 영어, 숫자포함) : ");
			Console.WriteLine(" User PW  (     Password 확인     ) : ");
			Console.WriteLine(" User Name (한글,영어 포함 2글자 이상) :");
			Console.WriteLine(" User Age (   자연수 1세 ~ 200세   ) :");
			Console.WriteLine(" User PhoneNumber (   01xxxxxxxx  ) :");
			Console.WriteLine(" User Address (     한글 주소     ) :");




		}
	
		public void PrintCenter(string message)
        {
			Console.WriteLine(String.Format(message).PadLeft(WIDTH - (WIDTH / 2 - (message.Length / 2))));
		}
		
	}
}
