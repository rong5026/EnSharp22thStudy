using System;
using System.Collections;
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
        int gameType;

        PrintUI UI;
        PlayGame start;
        ValidInput selectMenu;
        static public List<int> scoreList;


        char[] gameBoard = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public GameStart()
        {
            UI = new PrintUI();     
            selectMenu = new ValidInput();
          
        }
        public void StartGame()
        {
            scoreList = new List<int> { 0, 0 };
            UI.PrintGameStart();
            while (true)
            {
             
                UI.PrintMenu();
                gameType = selectMenu.ValidNumber();  // 1,2,3,0 값을 예외처리 후 입력
                // 메뉴 선택  1.computer게임 2.user게임 3.score 4.Exit
              


                if (gameType == EXIT)  // 4.Exit 선택 시 종료
                {
                    break;    // 프로그램 종료
                }
                else if(gameType == SCORE)  // 3.Score 선택
                {
                    Console.Clear();
                    UI.PrintScore(scoreList[0], scoreList[1]);
                }
                else  // 1 or 2 게임시작
                {

                    ResetBoard(); // Board 초기화
                    start = new PlayGame(gameBoard);
                    start.GamePlay(gameType);
                }
                    

            }
        }
        private void ResetBoard() // Board 초기화
        {
            for (int index = 0; index < gameBoard.Length; index++)         
                gameBoard[index] = Convert.ToChar(index + '0');
            
        }
        

    }
}
