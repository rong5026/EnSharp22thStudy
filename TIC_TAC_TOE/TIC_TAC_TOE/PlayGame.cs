using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class PlayGame
    {

        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int[] score = { 0, 0 };
       
    


        public int drawCount = 0;
        public void GamePlay(int gametype)
        {
            int drawCount = 0;
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                  GAME START !!!                │");
            Console.WriteLine("└------------------------------------------------┘\n");

            char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


            while (true)
            {
                if (gametype == 2)
                {
                
                    int usermode_win = UserMode();
                   
                    if (usermode_win == 1)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_1 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    else if(usermode_win == 2)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_2 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    if (usermode_win == 3)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                      DRAW !!!                  │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }

                }

                else if(gametype == 1)
                {
                    
                    int computermode_win = ComputerMode();
                  
                    if (computermode_win == 1)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_1 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    else if (computermode_win == 2)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 Computer WIN !!!               │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    if (computermode_win == 3)
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
        public int UserMode()
        {
           
            Console.Clear();
            Board();

         
            DistinguishUser(1);
            int user1_select = ValidGameInput(1);
            arr[user1_select] = 'O';
            drawCount++;

            Console.Clear();
            Board();

 
            if (CheckWin('O') == 1)
            {
                return 1;  // USER1이 승리시 1리턴
            }

            if (drawCount == 9)
                return 3;
            DistinguishUser(2);
            int user2_select = ValidGameInput(2);
            arr[user2_select] = 'X';
            drawCount++;

            Console.Clear();
            Board();
           

            if (CheckWin('X') == 1)
            {
                return 2;  //USER2가 승리시 2리턴
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

            DistinguishUser(1);
            int user1_select = ValidGameInput(1);
            arr[user1_select] = 'O';
            drawCount++;


            Console.Clear();
            Board();

            if (CheckWin('O') == 1)
            {
                score[0] = score[0] + 1;
                return 1;
            }

            if (drawCount == 9)
                return 3;

            Bot_SearchIndex();
            drawCount++;

            Console.Clear();
            Board();

            if (CheckWin('X') == 1)
            {
                score[1] = score[1] + 1;
                return 2;
            }
            else
            {
                return 0;
            }
           




        }
        public void Bot_SearchIndex()
        {

            if(AttackAndSheild('X') == 0)
            {
                if(AttackAndSheild('O') == 0)
                {
                    RandomBot();
              
                }
            }
              // 게임을 끝낼 수 있으면 끝냄
            
   
            
            // 우선순위
            // 1. 게임을 끝낼 수 있으면 끝냄
            // 2. 방어
            // 3. 랜덤
        }
        public void RandomBot()  // 처음에 랜덤으로 시작
        {
            int board_index = GetRandom();
            Console.WriteLine(board_index);
           
            arr[board_index] = 'X';
          
        }
        public int GetRandom()
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
        public int AttackAndSheild(char t)  //  공격,방어 알고리즘
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

            index = ComputerFindIndex(1,5,9, t);
            if (index != -1)
            {
                arr[index] = 'X';
                return 1;
            }
            index = ComputerFindIndex(3, 5, 7, t);
            if (index != -1)
            {
                arr[index] = 'X';
                return 1;
            }
          
            return 0;   // 게임을 끝낼 공격, 방어할 곳이 없을때 0 리턴
        }
        
        
        public int ComputerFindIndex(int index1, int index2, int index3, char t)
        {
            int user_wincount = 0;
            int num_index = -1;


            if (arr[index1] == t) { user_wincount++; }
            else { num_index = index1; }

            if (arr[index2] == t) { user_wincount++; }
            else { num_index = index2; }

            if (arr[index3] == t) { user_wincount++; }
            else { num_index = index3; }

            if (user_wincount == 2)
            {
                if (arr[num_index] != 'O' && arr[num_index] != 'X')
                    return num_index;
                else
                    return -1;
            }
            else
                return -1;

        }
      
       
        public int CheckWin(char t)
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

        public int ValidGameInput(int usernum)
        {
            string Select_Num = Console.ReadLine();

            if (Select_Num.Length == 1)  
            {
                char Char_Num = Convert.ToChar(Select_Num);
                int input = Convert.ToInt32(Char_Num);

                if( input >= 49 && input <= 57)
                {
                    for( int i = 1; i < 9; i++)
                    {
                        if(arr[i] == 'O' || arr[i] == 'X')
                        {
                            if (i == (input - '0'))
                            {
                              
                                Console.WriteLine("Choose an unselected number from 1 to 9");
                                DistinguishUser(usernum);
                                return ValidGameInput(usernum);  // 새로 입력값 
                            }
                        }
                    }
                    return input - '0';
                }
                else
                {
                    Console.WriteLine("Choose an unselected number from 1 to 9");
                    DistinguishUser(usernum);
                    return ValidGameInput(usernum);  // 새로 입력값 
                }
            }
            else
            {
                Console.WriteLine("Choose an unselected number from 1 to 9");
                DistinguishUser(usernum);
                return ValidGameInput(usernum);  // 새로 입력값 
            }

        }
        public void DistinguishUser(int usernum)
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
