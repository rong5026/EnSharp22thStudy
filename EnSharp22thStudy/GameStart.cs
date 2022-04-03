using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    internal class GameStart
    {
        public void StartGame()
        {

            while (true)
            {
                AvaliableNum first_num = new AvaliableNum();
                int typeStar = first_num.ValidStarNumber();  // 별 타입 입력값 예외 처리

                if (typeStar == -1)
                    break;  // 프로그램 종료 

                Console.WriteLine("---------------------------------------");


                int Column = first_num.ValidColNumber();  //줄 입력값 예외처리
                Console.WriteLine("---------------------------------------");

                PrintStar printStar = new PrintStar();
                printStar.ShowStar(typeStar, Column); // 별 출력

            }
            return;
        
        }
    }
    

}
