using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    internal class PrintUI
    {
   


        public void PrintStartMenu()
        {
            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│    Select type of Star!!!!(If want to stop game Plese select 0)    │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
           
        }

        public void PrintStarType()
        {

            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│                          1. 삼각형 출력                            │");
            Console.WriteLine("│                          2. 역삼각형 출력                          │");
            Console.WriteLine("│                          3. 모래시계모양 출력                      │");
            Console.WriteLine("│                          4. 다이아몬드모양 출력                    │");
            Console.WriteLine("│                          0. 프로그램 종료                          │");
            Console.WriteLine("└--------------------------------------------------------------------┘");       

        }

        public void PrintStop()
        {
            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│                                 STOP                               │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
        }
        public void PrintInputStarType()  // 별 타입 입력
        {
            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│                     Select number from 1 to 4                      │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
            Console.Write(" Number : ");

        }
        public void PrintStarTypeError() // 별 타입 입력 오류시
        {

            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│                  ERROR !!   Select number from 1 to 4              │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
            Console.Write(" Number : ");
        }
        public void PrintColumError() // 줄 입력
        {

            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│                    Please enter only Integers!!!                   │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
            Console.Write(" Please enter a Integer : ");

        }
        public void PrintInputcolumn() // 줄 입력 오류시
        {
            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│                   How many lines will you print?                   │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
            Console.Write(" Please enter a number : ");
        }

        public void PrintLine()
        {
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        public void PrintRestart() // 별찍기 후 다시 시작
        {
            Console.WriteLine("┌--------------------------------------------------------------------┐");
            Console.WriteLine("│               If want to Restart,  Press Any Key !!!               │");
            Console.WriteLine("└--------------------------------------------------------------------┘");
        }

      
    }
}
