using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace TIC_TAC_TOE
{
    internal class ValidInput
    {
        PrintUI UI = new PrintUI();
        const int EXIT = 0;
        const int USERMODE = 1;
        const int COMPUTERMODE = 2;
        const int SCORE = 3;
        const int GAME_STOP = 48;
        const int GAME_USER = 49;
        const int GAME_COMPUTER = 50;
        const int GAME_SCORE = 51;
        const int NUMBER_0 = 48;
        const int NUMBER_1 = 49;
        const int NUMBER_2 = 50;
        const int NUMBER_9 = 57;

        char charNumber;
        int input;
        string selectNum;

        public int FindValidNumber()  // 입력값 유효성 검사
        {
          
            while (true) // 매직넘버처리
            {
                Console.Write(" Select Menu : ");
                selectNum = Console.ReadLine();   //입력값 

                if (selectNum != null && selectNum.Length == 1)  // 입력값의 길이가 1일때 정수 1~4 조건 통과
                {
                    charNumber = Convert.ToChar(selectNum);
                    input = Convert.ToInt32(charNumber);
                    switch (input)
                    {
                        case GAME_STOP: //매직넘버처리
                            UI.PrintGameStop(); // gamestopUI 프린트
                            return EXIT;
                        case GAME_USER:
                            return USERMODE;
                        case GAME_COMPUTER:
                            return COMPUTERMODE;
                        case GAME_SCORE:
                            return SCORE;
                        default:
                            UI.PrintFindValidNumberError();
                            return FindValidNumber();  // 조건에 적합하지 않은 입력값 받았을 때 다시 리콜
                    }
                }
                else
                {
                    UI.PrintFindValidNumberError();
                    return FindValidNumber();  // 새로 입력값, 입력값이 한자리 수가 아닐때 
                }
            }
        }


        public int FindValidGameInput(int usernum,char[] gameBoard, int gameType) // 유효한 입력값 확인 후 리턴
        {
            
           selectNum = Console.ReadLine();

            if (selectNum != null && selectNum.Length == 1)
            {
                charNumber = Convert.ToChar(selectNum);
                input = Convert.ToInt32(charNumber);

                if (input >= NUMBER_0 && input <= NUMBER_9) // 1 ~ 9까지의 정수
                {
                    for (int index = 1; index < 9; index++)
                    {
                        if (gameBoard[index] == 'O' || gameBoard[index] == 'X')
                        {
                            if (index == (input - '0'))
                            {

                                UI.PrintFindValidGameInputError(gameBoard, gameType, usernum); // ERROR 프린트
                                return FindValidGameInput(usernum, gameBoard, gameType);  // 새로 입력값 
                            }
                        }
                    }
                    return input - '0';
                }
                else
                {
                    UI.PrintFindValidGameInputError(gameBoard, gameType, usernum); // ERROR 프린트
                    return FindValidGameInput(usernum, gameBoard, gameType);  // 새로 입력값 
                }
            }
            else
            {
                UI.PrintFindValidGameInputError(gameBoard, gameType, usernum); // ERROR 프린트
                return FindValidGameInput(usernum, gameBoard, gameType);  // 새로 입력값 
            }
        }

        public int FindWhoFirstInput(int gametype)
        {
            selectNum = Console.ReadLine();
            if (selectNum != null && selectNum.Length == 1)
            {
                charNumber = Convert.ToChar(selectNum);
                input = Convert.ToInt32(charNumber);

                if (input == NUMBER_1 || input == NUMBER_2) // 1 ~ 9까지의 정수
                {
                    return input - '0';
                }
                else
                {
                    Console.Clear();
                    if (gametype == 2)
                        UI.PrintWhoUserFirst(); // ERROR 프린트
                    else
                        UI.PrintWhoComputerFirst();
                    return FindWhoFirstInput(gametype);   // 새로 입력값 
                }
            }
            else
            {
                Console.Clear();
                if (gametype == 2)
                    UI.PrintWhoUserFirst(); // ERROR 프린트
                else
                    UI.PrintWhoComputerFirst();
                return FindWhoFirstInput(gametype);   // 새로 입력값 
            }
        }
    }
}
