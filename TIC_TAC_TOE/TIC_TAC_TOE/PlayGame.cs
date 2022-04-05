﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace TIC_TAC_TOE
{
    internal class PlayGame :GameStart
    {
        protected int drawCount = 0; // 9번 끝났을 때 무승부 count
        public int[] score = { 0, 0 }; // user와 computer의 점수 배열
        PrintUI UI = new PrintUI();
        ValidInput exception = new ValidInput();
        char[] gameBoard = new char[10];    
    
        const int ATTACK_OR_DEFENSE_SUCCESS = 1;
        const int ATTACK_OR_DEFENSE_FAIL = -1;
        const int NO_VALID_VALUE = -1;
        const int USER_MODE = 2;
        const int COMPUTER_MODE = 3;
        const int USERWIN = 1;
        const int COMPUTERWIN = 2;
        const int DRAW = 3;
        const int DRAWCOUNT = 9;
        const int NO_WINNER = 0;
        const int WINNER_TRUE = 1;
        const int WINNER_FALSE = 0;

        int userModeWin;
        int computerModeWin;
        int user1Select;
        int user2Select;
        int index = 0;
        int boardIndex = 0;
        int userWinCount = 0;
        int numIndex = -1;
        int computerCount = 0;
        int userCount = 0;
        int profitIndex = 0;

        public PlayGame(char []gameBoar)
        {          
            this.gameBoard = gameBoar;
        }
        
        public void GamePlay(int gametype)
        {
               
            drawCount = 0;
            UI.PrintMenu(); // gameMenuUI 
          
            while (true)
            {
                if (gametype == USER_MODE) // User Mode 
                {                   
                    userModeWin = UserMode();  // 입력값 + board판에 'O' 찍기
        
                    switch (userModeWin)
                    {
                        case USERWIN: // 유저가 이겼을 때 UI 출력  return 1;
                            UI.PrintGameOver();
                            UI.PrintFirstUserWin();
                            return;
                          
                        case COMPUTERWIN: // 컴퓨터가 이겼을 때 UI 출력  return 2;
                            UI.PrintGameOver();
                            UI.PrintSecondUserWin();                           
                            return;
                           
                        case DRAW:// 비겼을때 UI출력  return 3;
                            UI.PrintGameOver();
                            UI.PrintDraw();
                            return;
                            
                    }
                }

                else if(gametype == COMPUTER_MODE) // Computer Mode
                {                   
                    computerModeWin = ComputerMode(); // computer의 자동선택

                    switch (computerModeWin)
                    {
                        case USERWIN:// 유저가 이겼을 때 UI 출력
                            UI.PrintGameOver();
                            UI.PrintFirstUserWin();

                            return;
                        case COMPUTERWIN:// 컴퓨터가 이겼을 때 UI 출력
                            UI.PrintGameOver();
                            UI.PrintComputerWin();
                            return;
                        case DRAW:// 비겼을때 UI출력
                            UI.PrintGameOver();
                            UI.PrintDraw();
                            return;
                    }
                }
            }
        }
        private int UserMode() // vs User Mode  유저끼리하는 모드
        {
            
                      
            Console.Clear();
            UI.PrintBoard(gameBoard, 1);  
            UI.PrintDistinguishUser(1);//User1 BoardUI 출력  

            user1Select = exception.FindValidGameInput(1, gameBoard, 1); //입력값 1~9 사이 정수 (유저정보,보드데이터,게임타입)
            gameBoard[user1Select] = 'O';
            drawCount++;

            Console.Clear();
            UI.PrintBoard(gameBoard,1);  // BoardUI 출력
           

            if (CheckWin('O') == USERWIN) 
            {               
                return USERWIN;  // USER1 승리시 1리턴
            }

            if (drawCount == DRAWCOUNT) // drawCount가 9가 되면 무승부 처리
                return DRAW;

            UI.PrintDistinguishUser(2);
            user2Select = exception.FindValidGameInput(2, gameBoard,1); // (유저정보,보드데이터,
                                                                    // 게임타입 1은 vs USER, 2는 vs Computer)
            gameBoard[user2Select] = 'X';
            drawCount++;

            Console.Clear();
            UI.PrintBoard(gameBoard, 1);  // BoardUI 출력

            if (CheckWin('X') == COMPUTERWIN)
            {
                return COMPUTERWIN;  //USER2 승리시 2리턴
            }
            else
            {
                return NO_WINNER; // 승리자가 없을떈 0 return
            }
           
        }
        private int ComputerMode() // vs Computer Mode  컴퓨터와 하는 모드
        {
         

            Console.Clear();
            UI.PrintBoard(gameBoard, 2);   // (보드데이터, 게임타입)
            UI.PrintDistinguishUser(1);   //user1 정보 출력
            user1Select = exception.FindValidGameInput(1, gameBoard,2); //입력값 유효성 검사
            gameBoard[user1Select] = 'O'; // board판에 사용자1의 'O'를 입력
            drawCount++;
        

            Console.Clear();
            UI.PrintBoard(gameBoard, 2);  // BoardUI 출력

            if (CheckWin('O') == USERWIN)
            {
                scoreList[0]++;// User1 승리시 점수 증가                                             
                return USERWIN;
            }

            if (drawCount == DRAWCOUNT)
                return DRAW; // 무승부 drawcount가 9일때 무승부

            ComputerAutoPlay(); // Computer Bot
            drawCount++;

            Console.Clear();
            UI.PrintBoard(gameBoard, 2);  // BoardUI 출력

            if (CheckWin('X') == COMPUTERWIN)
            {
                scoreList[1]++; ;// Computer 승리시 점수 증가
                return COMPUTERWIN;
            }
            else
            {
                return NO_WINNER;
            }
           
        }
        private void ComputerAutoPlay()
        {
            
            if(AttackAndDepense('X') == 0) // 공격할 곳이 없을때 0 리턴
            {
                if(AttackAndDepense('O') == 0)//방어할 곳이 없을 때 0 리턴
                {
                    index = FindComputerProfitIndex();
                    if (index == NO_VALID_VALUE)
                        gameBoard[GetRandom()] = 'X';  // 첫 게임 시작시 랜덤으로 두기
                    else
                        gameBoard[index] = 'X';  //유리한 곳에 두기
                                                       

                }
            }
            // 우선순위
            // 1. 게임을 끝낼 수 있으면 끝냄
            // 2. 방어
            // 3. 유리한 인덱스에 두기
            // 4. 랜덤
        }
        private int GetRandom() // 1~9사이의 비어있는 인덱스값 return
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
        private int FindComputerProfitIndex()
        {

            for (int index = 1; index <= 3; index++)  //세로 확인
            {

                index = VerifyIndex(index, index + 3, index + 6);
                if(index != 0)
                    return index;              
            }
            
            for (int index = 1; index <= 9; index = index + 3)  // 3*3 에서 가로줄 확인
            {
                index = VerifyIndex(index, index + 1, index + 2);
                if (index != 0)
                    return index;
            }

            index = VerifyIndex(1, 5, 9);
            if (index != 0)
                return index;
            index = VerifyIndex(3, 5, 7);
            if (index != 0)
                return index;
            else
                return -1;// 조건에 해당하는 인덱스가 없을때 -1
        }

        private int VerifyIndex(int firstIndex , int secondIndex , int thirdIndex)
        {
            if (gameBoard[firstIndex] == 'O')
                userCount++;
            else if (gameBoard[firstIndex] == 'X')
                computerCount++;
            else
                profitIndex = firstIndex;

            if (gameBoard[secondIndex] == 'O')
                userCount++;
            else if (gameBoard[secondIndex] == 'X')
                computerCount++;
            else
                profitIndex = secondIndex;


            if (gameBoard[thirdIndex] == 'O')
                userCount++;
            else if (gameBoard[thirdIndex] == 'X')
                computerCount++;
            else
                profitIndex = thirdIndex;

            if (computerCount == 1 && userCount == 0)
                return profitIndex;
            else
            {
                computerCount = 0;
                userCount = 0;
                return 0;
            }
        }


        private int AttackAndDepense(char OX)  // Computer Bot공격,방어 알고리즘, OX = "X" 또는 "O"값
        {
           

            for (int index = 1; index <= 3; index++)  //세로 확인
            {
                boardIndex = FindComputerIndex(index, index + 3, index + 6, OX);
                if (boardIndex != -1) { 
                    gameBoard[boardIndex] = 'X'; // 세로줄 중 공격이나 방어할 곳이 있으면 공격, 방어 
                    return ATTACK_OR_DEFENSE_SUCCESS;
                }
            }
        
            for(int index = 1; index <= 9; index = index + 3)  // 3X3 board에서 가로 확인
            {
                boardIndex = FindComputerIndex(index, index + 1, index + 2, OX);
                if (boardIndex != ATTACK_OR_DEFENSE_FAIL)
                {
                    gameBoard[boardIndex] = 'X';
                    return ATTACK_OR_DEFENSE_SUCCESS;
                }
            }

            boardIndex = FindComputerIndex(1,5,9, OX); // 대각선 확인
            if (boardIndex != ATTACK_OR_DEFENSE_FAIL)
            {
                gameBoard[boardIndex] = 'X';
                return ATTACK_OR_DEFENSE_SUCCESS;
            }
            boardIndex = FindComputerIndex(3, 5, 7, OX); // 대각선 확인
            if (boardIndex != ATTACK_OR_DEFENSE_FAIL)
            {
                gameBoard[boardIndex] = 'X';
                return ATTACK_OR_DEFENSE_SUCCESS;
            }
          
            return 0;   //  세로,가로,대각선을 탐색 후 게임을 끝낼 공격이 없고, 방어할 곳이 없을때 0 리턴
        }
        
        
        private int FindComputerIndex(int index1, int index2, int index3, char OX) // 공격 or 방어할 인덱스 리턴
        {
           


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
      
       
        private int CheckWin(char OX) // 승리를 확인
        {
            for(int index = 1; index <=9; index = index + 3)  // 3*3 에서 가로줄 확인
            {
                if(gameBoard[index] == OX && gameBoard[index + 1]== OX && gameBoard[index + 2] == OX)            
                    return WINNER_TRUE;   
            }
            for(int index = 1; index <= 3; index++) // 3*3 에서 세로줄 확인
            {
                if (gameBoard[index] == OX && gameBoard[index + 3] == OX && gameBoard[index + 6] == OX)
                    return WINNER_TRUE;
            }
            if (gameBoard[1] == OX && gameBoard[5] == OX && gameBoard[9] == OX) //3 * 3 에서 대각선 확인
            {
                return WINNER_TRUE;
            }
            else if (gameBoard[3] == OX && gameBoard[5] == OX && gameBoard[7] == OX) //3 * 3 에서 두번째 대각선 확인
            {
                return WINNER_TRUE;
            }

            else
                return WINNER_FALSE;
        }

       
       

    }


}
