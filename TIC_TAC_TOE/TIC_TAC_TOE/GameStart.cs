using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class GameStart
    {
        public static class Score
        {
            public static int computerScore = 0;
            public static int playerScore = 0;
        }

        PrintUI UI = new PrintUI();
        Menu menu;
        int gameMode;
        PlayGame start;

        public void StartGame()
        {
            
            while (true)
            {

                UI.PrintGameStart();
                menu = new Menu();
                gameMode = menu.ShowMenu();  // 메뉴 선택  1.computer게임 2.user게임 3.score 4.Exit

               
                if (gameMode == 0)  // 4.Exit 선택 시 종료
                {
                    break;    // 프로그램 종료
                }
                else if(gameMode == 3)  // 3.Score 선택
                {
                    PlayGame start = new PlayGame();
                    Console.WriteLine("┌------------------------------------------------┐");
                    Console.WriteLine("│        USER SCORE : "+start.score[0]+"    COMPUTER SOCRE :" + start.score[1]+"     │");
                    Console.WriteLine("└------------------------------------------------┘\n"); //score 프린트
                }
                else  // 1 or 2 게임시작
                {
                    start = new PlayGame();
                    start.GamePlay(gameMode);
                }
                    

            }
        }
        

    }
}
