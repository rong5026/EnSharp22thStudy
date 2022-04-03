using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnSharp22thStudy
{
    internal class GameStart
    {
        public static int GAMESTOP = -1;
        PrintUI UI;
        AvaliableNum firstnumber;
        PrintStar printStar;
        int column;
        int typeStar;

        public GameStart()
        {
            UI =  new PrintUI();
            firstnumber = new AvaliableNum();
            printStar = new PrintStar();
        }
        public void StartGame()
        {

            while (true)
            {
                Console.Clear();
                UI.PrintStartMenu();
                UI.PrintStarType();
                UI.PrintInputStarType(); // UI 출력

                typeStar = firstnumber.FindValidStarNumber();  // 별 타입 입력값 예외 처리

                if (typeStar == GAMESTOP)
                    break;  // 프로그램 종료 

                UI.PrintInputcolumn();
                column = firstnumber.FindValidColNumber();  //줄 입력값 예외처리
                UI.PrintLine();
              
                printStar.ShowStar(typeStar, column); // 별 출력

                UI.PrintRestart();
                Console.ReadLine(); // 다시 UI출력

            }
            return;
        
        }
    }
    

}
