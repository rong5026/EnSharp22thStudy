using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class ValidInput
    {
        public int ValidNumber()  // 입력값 유효성 검사
        {
            while (true)
            {
                Console.Write("Select Menu : ");
                string Select_Num = Console.ReadLine();   //입력값 

                if (Select_Num.Length == 1)  // 입력값의 길이가 1일때 정수 1~4 조건 통과
                {
                    char Char_Num = Convert.ToChar(Select_Num);
                    int input = Convert.ToInt32(Char_Num);

                    if (input == 48)  // 0.Exit 선택 했을때  return 0
                    {
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                  GAME STOP !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        return 0;
                    }
                    else if (input == 49) // 1. computer Mode 선택 시 return 1.
                    {
                        return 1;
                    }
                    else if (input == 50)// 2. user Mode 선택 시 return 2.
                    {
                        return 2;
                    }
                    else if (input == 51)// 3. Score mode 선택 시 return 3.
                    {
                        return 3;
                    }
                    else
                    {
                        Console.WriteLine("Enter an integer between 0 and 3");
                        return ValidNumber();  // 조건에 적합하지 않은 입력값 받았을 때 다시 리콜
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
