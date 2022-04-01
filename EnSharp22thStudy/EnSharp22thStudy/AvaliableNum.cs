using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    internal class AvaliableNum
    {

        public int ValidStarNumber()  // 별 타입 입력값 예외 처리
        {

            while (true)
            {
             
                Console.Write("Select type of Star!!!!(If want to stop game Plese select 0)\nChoose a star type from 1 to 4\nNumber : ");
                string Select_Num = Console.ReadLine();

                if (Select_Num.Length == 1)  // 입력값의 길이가 1일때 정수 1~4 조건 통과
                {
                    char Char_Num = Convert.ToChar(Select_Num);
                    int input = Convert.ToInt32(Char_Num);
                    if (input == 48)
                    {
                        Console.WriteLine("@@ Stop @@"); //숫자 0 입력 시 프로그램 종료
                        return -1;  // -1 리턴해서 게임 종료
                    }
                    else if (input < 49 || input > 52)  // 입력값의 아스키코드 값이 숫자가 아닐때
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine(" @@ ERROR!!! select number from 1 to 4 @@");
                        Console.WriteLine("---------------------------------------");
                        return ValidStarNumber();  // 새로 입력값 받음
                    }
                    else
                        return int.Parse(Select_Num);  // 예외처리 후 정수값 리턴
                }
                else
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine(" @@ ERROR!!! select number from 1 to 4 @@");
                    Console.WriteLine("---------------------------------------");
                    return ValidStarNumber();  // 새로 입력값 
                }
            }
        }


        public int ValidColNumber() // 줄 입력값 예외 처리
        {
            int stringCount = 0;
            while (true)
            {
             
                Console.Write("How many lines will you print?\nPlease enter a number.. : ");

                string Column_Num = Console.ReadLine();  // 입력

                for (int i = 0; i < Column_Num.Length; i++)
                {
                    if (Convert.ToInt32(Column_Num[i]) < 48 || Convert.ToInt32(Column_Num[i]) > 57)
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine(" ERROR !!! Please enter only integers!!!");
                        Console.WriteLine("---------------------------------------");
                        return ValidColNumber();  // 입력값 한자리씩 예외 검사
                    }
                    else
                    {
                        stringCount++;  // 조건 통과시 count 1증가
                    }

                }
                if(stringCount == 0 ) // 입력된 값이 없을때 
                    return ValidColNumber();
                else if(stringCount == Column_Num.Length)  //입력값의 길이와 stringCount가 일치 시 모든 조건 통과
                    return int.Parse(Column_Num);  // 줄 입력값 리턴

            }


        }
    }
}
