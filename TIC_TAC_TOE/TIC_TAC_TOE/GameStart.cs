using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class GameStart
    {

        const int EXIT = 0;
        const int SCORE = 3;

        PrintUI UI;      
        int gameMode;
        PlayGame start;
        ValidInput selectMenu;


        public GameStart()
        {
            UI = new PrintUI();           
            start = new PlayGame();
            selectMenu = new ValidInput();
        }
        public void StartGame()
        {
            UI.PrintGameStart();
            while (true)
            {
               
                UI.PrintMenu();
                gameMode = selectMenu.ValidNumber();  // 1,2,3,0 값을 예외처리 후 입력
                // 메뉴 선택  1.computer게임 2.user게임 3.score 4.Exit
              


                if (gameMode == EXIT)  // 4.Exit 선택 시 종료
                {
                    break;    // 프로그램 종료
                }
                else if(gameMode == SCORE)  // 3.Score 선택
                {
                    Console.Clear();
                    UI.PrintScore(0,0);
                }
                else  // 1 or 2 게임시작
                {             
                    start.GamePlay(gameMode);
                }
                    

            }
        }
        

    }
}
