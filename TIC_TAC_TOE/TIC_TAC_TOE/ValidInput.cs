using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class ValidInput
    {
            
        public const int EXIT = 0;
        public int ValidNumber()  // 입력값 유효성 검사
        {
            const int EXIT = 0;
            const int USERMODE = 1;
            const int COMPUTERMODE = 2;
            const int SCORE = 3;

            PrintUI UI = new PrintUI();
            string selectNum;
            char charNumber;
            int input;

            while (true)
            {
                Console.Write("Select Menu : ");
                selectNum = Console.ReadLine();   //입력값 

                if (selectNum.Length == 1)  // 입력값의 길이가 1일때 정수 1~4 조건 통과
                {
                    charNumber = Convert.ToChar(selectNum);
                    input = Convert.ToInt32(charNumber);
                    switch (input)
                    {
                        case 48:
                            UI.PrintGameStop(); // gamestopUI 프린트
                            return EXIT;
                            break;
                        case 49:
                            return USERMODE;
                            break;
                        case 50:
                            return COMPUTERMODE;
                            break;
                        case 51:
                            return SCORE;
                            break;
                        default:
                            Console.WriteLine("Enter an integer between 0 and 3");
                            return ValidNumber();  // 조건에 적합하지 않은 입력값 받았을 때 다시 리콜
                            break;
                    }                     
                }
                else
                {
                    Console.WriteLine("Enter an integer between 0 and 3");
                    return ValidNumber();  // 새로 입력값, 입력값이 한자리 수가 아닐때 
                }
               
            }
        }
    }
}
