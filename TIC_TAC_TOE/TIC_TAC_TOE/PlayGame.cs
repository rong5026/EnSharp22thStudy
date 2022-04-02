using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class PlayGame
    {

        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // 게임판 초기화
        public int drawCount = 0; // 9번 끝났을 때 무승부 count
        public int []score = { 0, 0 }; // user와 computer의 점수 배열
        
        public void GamePlay(int gametype)
        {
            drawCount = 0;
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                  GAME START !!!                │");
            Console.WriteLine("└------------------------------------------------┘\n");

            char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


            while (true)
            {
                if (gametype == 2) // User Mode 
                {
                    
                    int usermode_win = UserMode();  // 입력값 + board판에 'O' 찍기
                   
                    if (usermode_win == 1) //user 가 이겼을때
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_1 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    else if(usermode_win == 2) // computer가 이겼을때
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_2 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    if (usermode_win == 3) // 무승부일때
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                      DRAW !!!                  │");
                        Console.WriteLine("└------------------------------------------------┘\n");                       
                        break;
                    }

                }

                else if(gametype == 1) // Computer Mode
                {
                    
                    int computermode_win = ComputerMode(); // computer의 자동선택
                  
                    if (computermode_win == 1) //user 승리
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_1 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    else if (computermode_win == 2) // computer 승리
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 Computer WIN !!!               │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    if (computermode_win == 3) // 무승부
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                      DRAW !!!                  │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }


                }

            }

        }
        public int UserMode() // user 입력값 
        {
           
            Console.Clear();
            Board();

         
            PrintDistinguishUser(1);
            int user1_select = ValidGameInput(1); //입력값 1~9 사이 정수
            arr[user1_select] = 'O';
            drawCount++;

            Console.Clear();
            Board();

 
            if (CheckWin('O') == 1) 
            {
                return 1;  // USER1 승리시 1리턴
            }

            if (drawCount == 9) // drawCount가 9가 되면 무승부 처리
                return 3;
            PrintDistinguishUser(2);
            int user2_select = ValidGameInput(2);
            arr[user2_select] = 'X';
            drawCount++;

            Console.Clear();
            Board();
           

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
            Console.Clear();
            Board();

            PrintDistinguishUser(1);   //user1 정보 출력
            int user1_select = ValidGameInput(1); //입력값 유효성 검사
            arr[user1_select] = 'O'; // board판에 사용자1의 'O'를 입력
            drawCount++;


            Console.Clear();
            Board();

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
            Board();

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
            int board_index = GetRandom();                
            arr[board_index] = 'X';  // 비어있는 인덱스에 랜덤으로 할당          
        }
        public int GetRandom() // 1~9사이의 비어있는 인덱스값 return
        {
            Random random = new Random();
            int board_index = random.Next(1, 9);


            for (int i = 1; i <= 9; i++)
            {
                if (arr[i] == 'O' || arr[i] == 'X')
                {
                    if (i == board_index)
                    {
                        return GetRandom();
                    }
                }
            }
            return board_index;
        }
        public int AttackAndSheild(char t)  // Computer Bot공격,방어 알고리즘
        {
            int index = 0;
            for (int i = 1; i <= 3; i++)  //세로 확인
            {
                index = ComputerFindIndex(i, i + 3, i + 6, t);
                if (index != -1) { 
                    arr[index] = 'X';
                    return 1;
                }
            }
        
            for(int i =1; i<=9; i = i + 3)  // 3X3 board에서 가로 확인
            {
                index = ComputerFindIndex(i, i + 1, i + 2, t);
                if (index != -1)
                {
                    arr[index] = 'X';
                    return 1;
                }
            }

            index = ComputerFindIndex(1,5,9, t); // 대각선 확인
            if (index != -1)
            {
                arr[index] = 'X';
                return 1;
            }
            index = ComputerFindIndex(3, 5, 7, t); // 대각선 확인
            if (index != -1)
            {
                arr[index] = 'X';
                return 1;
            }
          
            return 0;   // 게임을 끝낼 공격, 방어할 곳이 없을때 0 리턴
        }
        
        
        public int ComputerFindIndex(int index1, int index2, int index3, char t) // 공격 or 방어할 인덱스 리턴
        {
            int user_wincount = 0;
            int num_index = -1;


            if (arr[index1] == t) { user_wincount++; }
            else { num_index = index1; }

            if (arr[index2] == t) { user_wincount++; }
            else { num_index = index2; }

            if (arr[index3] == t) { user_wincount++; }
            else { num_index = index3; }

            if (user_wincount == 2) // 나열된 인덱스 값중 문자열 t의 수가 3개중에 2개가 있다면 
            {
                if (arr[num_index] != 'O' && arr[num_index] != 'X')
                    return num_index;  //공격 or 방어를 해야하므로 3개중 나머지 1개의 인덱스 return
                else
                    return -1;
            }
            else
                return -1;

        }
      
       
        public int CheckWin(char t) // 승리를 확인
        {
            for(int i = 1; i <=9; i=i+3)
            {
                if(arr[i] == t && arr[i+1]==t && arr[i + 2] == t)            
                    return 1;   
            }
            for(int i = 1; i <=3; i++)
            {
                if (arr[i] == t && arr[i + 3] == t && arr[i + 6] == t)
                    return 1;
            }
            if (arr[1] == t && arr[5] == t && arr[9] == t)
            {
                return 1;
            }
            else if (arr[3] == t && arr[5] == t && arr[7] == t)
            {
                return 1;
            }

            else
                return 0;
        }

        public int ValidGameInput(int usernum) // 유효한 입력값 확인 후 리턴
        {
            string Select_Num = Console.ReadLine();

            if (Select_Num.Length == 1)  
            {
                char Char_Num = Convert.ToChar(Select_Num);
                int input = Convert.ToInt32(Char_Num);

                if( input >= 49 && input <= 57) // 1 ~ 9까지의 정수
                {
                    for( int i = 1; i < 9; i++)
                    {
                        if(arr[i] == 'O' || arr[i] == 'X')
                        {
                            if (i == (input - '0')) 
                            {
                              
                                Console.WriteLine("Choose an unselected number from 1 to 9");
                                PrintDistinguishUser(usernum);
                                return ValidGameInput(usernum);  // 새로 입력값 
                            }
                        }
                    }
                    return input - '0';
                }
                else
                {
                    Console.WriteLine("Choose an unselected number from 1 to 9");
                    PrintDistinguishUser(usernum);
                    return ValidGameInput(usernum);  // 새로 입력값 
                }
            }
            else
            {
                Console.WriteLine("Choose an unselected number from 1 to 9");
                PrintDistinguishUser(usernum);
                return ValidGameInput(usernum);  // 새로 입력값 
            }

        }
        public void PrintDistinguishUser(int usernum) // 유저 정보 출력
        {
            if (usernum == 1)
            {
                Console.WriteLine("[User_1][ O ]  Select Number( 1 to 9 )");
                Console.Write("USER_1 : ");
            }
            else
            {
                Console.WriteLine("[User_2][ X ]  Select Number( 1 to 9 )");
                Console.Write("USER_2 : ");
            }
        }
        public static void Board()
        {
            
            Console.WriteLine("┌---------------------------------------┐");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", arr[1], arr[2], arr[3]);
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│------------││------------││-----------│");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", arr[4], arr[5], arr[6]);
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│------------││------------││-----------│");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", arr[7], arr[8], arr[9]);
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("└---------------------------------------┘");
            Console.WriteLine("│  USER_1 =  [ O ]      USER_2 = [ X ]  │");
            Console.WriteLine("└---------------------------------------┘");
        }

        public void PrintGameOver()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                  GAME OVER !!!                 │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }

    }


}
