using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    internal class AvaliableNum
    {
        public static int GAME_STOP = -1;
        PrintUI UI;
        string selectNumber;
        char charNumber;
        int input;
        int stringCount;
        

     
        public int FindValidStarNumber()  // 별 타입 입력값 예외 처리
        {
            UI = new PrintUI();
            while (true)
            {

                Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
                {

                    var isCtrlC = e.SpecialKey == ConsoleSpecialKey.ControlC;
                    var isCtrlBreak = e.SpecialKey == ConsoleSpecialKey.ControlBreak;

                    // Prevent CTRL-C from terminating
                    if (isCtrlC)
                    {
                        e.Cancel = true;
                        Console.WriteLine("어오ㅓ슀");
                    }

                    // e.Cancel defaults to false so CTRL-BREAK will still cause termination

                };
                selectNumber = Console.ReadLine(); 
                
                    if (selectNumber != null && selectNumber.Length == 1)  // 입력값의 길이가 1일때 정수 1~4 조건 통과
                    {
                        charNumber = Convert.ToChar(selectNumber);
                        input = Convert.ToInt32(charNumber);

                        if (input == 48)
                        {
                            UI.PrintStop(); //숫자 0 입력 시 프로그램 종료
                            return GAME_STOP;  // -1 리턴해서 게임 종료
                        }
                        else if (input < 49 || input > 52)  // 입력값의 아스키코드 값이 숫자가 아닐때
                        {

                            Console.Clear();
                            UI.PrintStartMenu();
                            UI.PrintStarType();
                            UI.PrintStarTypeError();  // UI clear
                            return FindValidStarNumber();  // 새로 입력값 받음
                        }
                        else
                            return int.Parse(selectNumber);  // 예외처리 후 정수값 리턴
                    }
                    else
                    {
                        Console.Clear();
                        UI.PrintStartMenu();
                        UI.PrintStarType();
                        UI.PrintStarTypeError();// UI clear
                        return FindValidStarNumber();  // 새로 입력값 
                    }
                
                
            }
        }


        public int FindValidColNumber() // 줄 입력값 예외 처리
        {
            UI = new PrintUI();
            stringCount = 0;
            string column;
            while (true)
            {
               
                column = Console.ReadLine();  // 입력
                if (column != null)  
                {
                    for (int index = 0; index < column.Length; index++)
                    {
                        if (Convert.ToInt32(column[index]) < 48 || Convert.ToInt32(column[index]) > 57)
                        {
                            Console.Clear();
                            UI.PrintStartMenu();
                            UI.PrintStarType();
                            UI.PrintColumError();// UI clear
                            return FindValidColNumber();  // 입력값 한자리씩 예외 검사
                        }
                        else
                        {
                            stringCount++;  // 조건 통과시 count 1증가
                        }
                    }
                    if (stringCount == 0)
                    {  // 입력된 값이 없을때 
                        Console.Clear();
                        UI.PrintStartMenu();
                        UI.PrintStarType();
                        UI.PrintColumError();
                        return FindValidColNumber();// UI clear
                    }
                    else if (stringCount == column.Length)  //입력값의 길이와 stringCount가 일치 시 모든 조건 통과
                        return int.Parse(column);  // 줄 입력값 리턴
                }
                else
                {
                    Console.Clear();
                    UI.PrintStartMenu();
                    UI.PrintStarType();
                    UI.PrintColumError();
                    return FindValidColNumber();// UI clear
                }
            }
        }

        
    }
}
