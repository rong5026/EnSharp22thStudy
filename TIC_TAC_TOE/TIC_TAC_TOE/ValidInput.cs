using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class ValidInput
    {
        public int ValidNumber()
        {
            while (true)
            {
                Console.Write("Select Menu : ");
                string Select_Num = Console.ReadLine();

                if (Select_Num.Length == 1)  // 입력값의 길이가 1일때 정수 1~4 조건 통과
                {
                    char Char_Num = Convert.ToChar(Select_Num);
                    int input = Convert.ToInt32(Char_Num);

                    if (input == 48)
                    {
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                  GAME STOP !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        return 0;
                    }
                    else if (input == 49)
                    {
                        return 1;
                    }
                    else if (input == 50)
                    {
                        return 2;
                    }
                    else if (input == 51)
                    {
                        return 3;
                    }
                    else
                    {
                        Console.WriteLine("Enter an integer between 0 and 3");
                        return ValidNumber();
                    }
               
                }
                else
                {
                    Console.WriteLine("Enter an integer between 0 and 3");
                    return ValidNumber();  // 새로 입력값 
                }
               
            }
        }
    }
}
