using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    class PrintStar
    {
        //dfdf
        PrintUI UI = new PrintUI();
        public void ShowStar(int starType,int column)  // 4가지 별타입 출력
        {
            switch (starType)
            {
                case 1: 
                    TriangleType(column, starType);
                    break;
                case 2:
                    TriangleType(column, starType);
                    break;
                case 3:
                    ReverseTriangleType(column);
                    TriangleType(column, starType);
                    break;
                default:
                    TriangleType(column, starType);
                    ReverseTriangleType(column);
                    break;
            }
            
            UI.PrintLine();  //    구분 줄을 프린트 해줌

           
        }

        public void TriangleType(int column, int starType)  // 삼각형 별쌓기
        {
            if (starType == 4)
                column--;

            for (int index = 0; index < column; index++)
            {
                if(starType ==4)
                    Console.Write(" ");
                for (int j = column - 1 - index; j > 0; j--)
                    Console.Write(" ");
                for (int k = 0; k < 2 * index + 1; k++)
                {  
                   Console.Write("*");
                }                     
                Console.WriteLine();
            }
        }
        public void ReverseTriangleType(int column) // 역삼각형 별쌓기
        {
            for (int index = 0; index < column; index++)
            {
                for (int j = 0; j < index; j++)
                    Console.Write(" ");
                for (int k = 2 * column - 2; k >= 2 * index; k--)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }

    
}
