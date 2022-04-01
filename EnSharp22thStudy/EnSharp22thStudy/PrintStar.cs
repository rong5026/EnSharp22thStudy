using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    class PrintStar
    {
        public void ShowStar(int star_num,int column_num)  // 4가지 별타입 출력
        {

            if (star_num == 1)
            {
                StarType1(column_num);
            }

            else if (star_num == 2)
            {
                StarType2(column_num);  
            }
            else if(star_num == 3)
            {
                StarType2(column_num);
                StarType1(column_num);
            }
            else
            {
                StarType1(column_num);
                StarType2(column_num);
            }
            Console.WriteLine("---------------------------------------");
        }

        public void StarType1(int column_num)  // 삼각형 별쌓기
        {
            for (int i = 0; i < column_num; i++)
            {
                for (int j = column_num - 1 - i; j > 0; j--)
                    Console.Write(" ");
                for (int k = 0; k < 2 * i + 1; k++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        public void StarType2(int column_num) // 역삼각형 별쌓기
        {
            for (int i = 0; i < column_num; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write(" ");
                for (int k = 2 * column_num - 2; k >= 2 * i; k--)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }

    
}
