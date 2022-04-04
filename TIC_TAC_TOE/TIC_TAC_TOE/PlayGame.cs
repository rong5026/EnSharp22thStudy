using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class PlayGame
    {
        public int drawCount = 0; // 9번 끝났을 때 무승부 count
        public int[] score = { 0, 0 }; // user와 computer의 점수 배열
        PrintUI UI = new PrintUI();
        char[] gameBoard = new char[10];

        const int ATTACK_OR_DEFENSE_SUCCESS = 1;
        const int ATTACK_OR_DEFENSE_FAIL = -1;
       

        public PlayGame(char []gameBoar)
        {          
            this.gameBoard = gameBoar;
        }
        
        public void GamePlay(int gametype)
        {
            int userModeWin;
            int computerModeWin;
            const int USERWIN = 1;
            const int COMPUTERWIN = 2;
            const int DRAW = 3;

            drawCount = 0;
            UI.PrintMenu(); // gameMenuUI 
          

            while (true)
            {
                if (gametype == 2) // User Mode 
                {                   
                    userModeWin = UserMode();  // 입력값 + board판에 'O' 찍기
        
                    switch (userModeWin)
                    {
                        case USERWIN:
                            UI.PrintGameOver();
                            UI.PrintFirstUserWin();
                            return;
                          
                        case COMPUTERWIN:
                            UI.PrintGameOver();
                            UI.PrintSecondUserWin();
                            return;
                           
                        case DRAW:
                            UI.PrintGameOver();
                            UI.PrintDraw();
                            return;
                            
                    }
                }

                else if(gametype == 1) // Computer Mode
                {                   
                    computerModeWin = ComputerMode(); // computer의 자동선택

                    switch (computerModeWin)
                    {
                        case USERWIN:
                            UI.PrintGameOver();
                            UI.PrintFirstUserWin();
                            return;
                        case COMPUTERWIN:
                            UI.PrintGameOver();
                            UI.PrintComputerWin();
                            return;
                        case DRAW:
                            UI.PrintGameOver();
                            UI.PrintDraw();
                            return;
                    }
                }
            }
        }
        public int UserMode() // user 입력값 
        {
            int user1Select;
            int user2Select;
            ValidInput exception = new ValidInput();
            Console.Clear();
            UI.PrintBoard(gameBoard, 1);  // BoardUI 출력


            UI.PrintDistinguishUser(1);
            user1Select = exception.ValidGameInput(1, gameBoard, 1); //입력값 1~9 사이 정수
            gameBoard[user1Select] = 'O';
            drawCount++;

            Console.Clear();
            UI.PrintBoard(gameBoard,1);  // BoardUI 출력
           

            if (CheckWin('O') == 1) 
            {               
                return 1;  // USER1 승리시 1리턴
            }

            if (drawCount == 9) // drawCount가 9가 되면 무승부 처리
                return 3;

            UI.PrintDistinguishUser(2);
            user2Select = exception.ValidGameInput(2, gameBoard,1);
            gameBoard[user2Select] = 'X';
            drawCount++;

            Console.Clear();
            UI.PrintBoard(gameBoard, 1);  // BoardUI 출력

            if (CheckWin('X') == 1)
            {
                return 2;  //USER2 승리시 2리턴
            }
            else
            {
                return 0;
            }
           
        }
        public int ComputerMode()
        {
            int user1Select;
            ValidInput exception = new ValidInput();

            Console.Clear();
            UI.PrintBoard(gameBoard, 2);  // BoardUI 출력 , 
            UI.PrintDistinguishUser(1);   //user1 정보 출력
            user1Select = exception.ValidGameInput(1, gameBoard,2); //입력값 유효성 검사
            gameBoard[user1Select] = 'O'; // board판에 사용자1의 'O'를 입력
            drawCount++;


            Console.Clear();
            UI.PrintBoard(gameBoard, 2);  // BoardUI 출력

            if (CheckWin('O') == 1)
            {
                score[0] = score[0] + 1; // User1 승리시 점수 증가
                return 1;
            }

            if (drawCount == 9)
                return 3; // 무승부 count가 9일때 무승부

            ComputerAutoPlay(); // Computer Bot
            drawCount++;

            Console.Clear();
            UI.PrintBoard(gameBoard, 2);  // BoardUI 출력

            if (CheckWin('X') == 1)
            {
                score[1] = score[1] + 1;// Computer 승리시 점수 증가
                return 2;
            }
            else
            {
                return 0;
            }
           
        }
        public void ComputerAutoPlay()
        {

            if(AttackAndSheild('X') == 0) // 공격
            {
                if(AttackAndSheild('O') == 0)//방어
                {
                    RandomBot();// 랜덤
              
                }
            }
            // 우선순위
            // 1. 게임을 끝낼 수 있으면 끝냄
            // 2. 방어
            // 3. 랜덤
        }
        public void RandomBot()  // 처음에 랜덤으로 시작
        {
            int boardIndex = GetRandom();                
            gameBoard[boardIndex] = 'X';  // 비어있는 인덱스에 랜덤으로 할당          
        }
        public int GetRandom() // 1~9사이의 비어있는 인덱스값 return
        {
            Random random = new Random();
            int boardIndex = random.Next(1, 9);


            for (int index = 1; index <= 9; index++)
            {
                if (gameBoard[index] == 'O' || gameBoard[index] == 'X')
                {
                    if (index == boardIndex)
                    {
                        return GetRandom();
                    }
                }
            }
            return boardIndex;
        }

      
        public int AttackAndSheild(char OX)  // Computer Bot공격,방어 알고리즘, OX = "X" 또는 "O"값
        {
            int boardIndex = 0;
         

            for (int index = 1; index <= 3; index++)  //세로 확인
            {
                boardIndex = ComputerFindIndex(index, index + 3, index + 6, OX);
                if (boardIndex != -1) { 
                    gameBoard[boardIndex] = 'X'; // 세로줄 중 공격이나 방어할 곳이 있으면 공격, 방어 
                    return ATTACK_OR_DEFENSE_SUCCESS;
                }
            }
        
            for(int index = 1; index <= 9; index = index + 3)  // 3X3 board에서 가로 확인
            {
                boardIndex = ComputerFindIndex(index, index + 1, index + 2, OX);
                if (boardIndex != ATTACK_OR_DEFENSE_FAIL)
                {
                    gameBoard[boardIndex] = 'X';
                    return ATTACK_OR_DEFENSE_SUCCESS;
                }
            }

            boardIndex = ComputerFindIndex(1,5,9, OX); // 대각선 확인
            if (boardIndex != ATTACK_OR_DEFENSE_FAIL)
            {
                gameBoard[boardIndex] = 'X';
                return ATTACK_OR_DEFENSE_SUCCESS;
            }
            boardIndex = ComputerFindIndex(3, 5, 7, OX); // 대각선 확인
            if (boardIndex != ATTACK_OR_DEFENSE_FAIL)
            {
                gameBoard[boardIndex] = 'X';
                return ATTACK_OR_DEFENSE_SUCCESS;
            }
          
            return 0;   //  세로,가로,대각선을 탐색 후 게임을 끝낼 공격이 없고, 방어할 곳이 없을때 0 리턴
        }
        
        
        public int ComputerFindIndex(int index1, int index2, int index3, char OX) // 공격 or 방어할 인덱스 리턴
        {
            int userWinCount = 0;
            int numIndex = -1;


            if (gameBoard[index1] == OX) { userWinCount++; }
            else { numIndex = index1; }

            if (gameBoard[index2] == OX) { userWinCount++; }
            else { numIndex = index2; }

            if (gameBoard[index3] == OX) { userWinCount++; }
            else { numIndex = index3; }

            if (userWinCount == 2) // 나열된 인덱스 값중 문자열 t의 수가 3개중에 2개가 있다면 
            {
                if (gameBoard[numIndex] != 'O' && gameBoard[numIndex] != 'X')
                    return numIndex;  //공격 or 방어를 해야하므로 3개중 나머지 1개의 인덱스 return
                else
                    return ATTACK_OR_DEFENSE_FAIL;
            }
            else
                return ATTACK_OR_DEFENSE_FAIL;

        }
      
       
        public int CheckWin(char OX) // 승리를 확인
        {
            for(int index = 1; index <=9; index = index + 3)  // 3*3 에서 가로줄 확인
            {
                if(gameBoard[index] == OX && gameBoard[index + 1]== OX && gameBoard[index + 2] == OX)            
                    return 1;   
            }
            for(int index = 1; index <= 3; index++) // 3*3 에서 세로줄 확인
            {
                if (gameBoard[index] == OX && gameBoard[index + 3] == OX && gameBoard[index + 6] == OX)
                    return 1;
            }
            if (gameBoard[1] == OX && gameBoard[5] == OX && gameBoard[9] == OX) //3 * 3 에서 대각선 확인
            {
                return 1;
            }
            else if (gameBoard[3] == OX && gameBoard[5] == OX && gameBoard[7] == OX) //3 * 3 에서 두번째 대각선 확인
            {
                return 1;
            }

            else
                return 0;
        }

       
       

    }


}
