using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class LibraryUI
    {
		const Boolean PROGRAM_ON = true;
		const int WIDTH = 120;


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

		
		public void PrintSelectMainUI(int selectNum)  //1. 로그인 2. 회원가입
		{
			string user = selectNum == 1 ? "●" : "○";
			string manager = selectNum == 2 ? "●" : "○";

			Console.Clear();
			PrintMainUI();  // main 이미지 출력

			Console.WriteLine("                                   ┌------------------------------------------------┐");
			Console.WriteLine("                                   │                                                │");
			Console.Write("                                   │                 ");
			if (selectNum == 1) Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("{0}    유저모드", user);
			Console.ResetColor();
			Console.WriteLine("                 │");
			Console.Write("                                   │                 ");
			if (selectNum == 2) Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("{0}    관리자모드", manager);
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
			Console.Write("                                   │                 ");
			Console.Write("Program STOP");
			Console.ResetColor();
			Console.WriteLine("                   │");
			Console.WriteLine("                                   │                                                │");
			Console.WriteLine("                                   └------------------------------------------------┘");

		}
		public void PrintCenter(string message)
        {
			Console.WriteLine(String.Format(message).PadLeft(WIDTH - (WIDTH / 2 - (message.Length / 2))));
		}
		
	}
}
