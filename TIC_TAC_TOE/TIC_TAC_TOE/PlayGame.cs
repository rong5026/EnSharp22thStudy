using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class PlayGame
    {
        static int[] score = { 0, 0 };
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public void GamePlay(int gametype)
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                  GAME START !!!                │");
            Console.WriteLine("└------------------------------------------------┘\n");

            while (true)
            {
                if (gametype == 2)
                {
                    int winscore = UserMode();
                    if(winscore == 1)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_1 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }
                    else if(winscore == 2)
                    {
                        PrintGameOver();
                        Console.WriteLine("┌------------------------------------------------┐");
                        Console.WriteLine("│                 USER_2 WIN !!!                 │");
                        Console.WriteLine("└------------------------------------------------┘\n");
                        break;
                    }                       
                }
                else if(gametype == 1)
                {

                }

            }

        }
        public int UserMode()
        {
            Console.Clear();
            Board();

            Console.WriteLine("[User_1][ O ]  Select Number( 1 to 9 )");
            Console.Write("USER_1 : ");
            int user1_select = ValidGameInput();
            arr[user1_select] = 'O';
            if(CheckWin('o') == 1)
            { 
                return 1;
            }

            Console.Clear();
            Board();
            
            Console.WriteLine("[User_2][ X ]  Select Number( 1 to 9 )");
            Console.Write("USER_2 : ");
            int user2_select = ValidGameInput();
            arr[user2_select] = 'X';
            if (CheckWin('X') == 1)
            {
                return 2;
            }
            else
                return 0;
        }
        public int ComputerMode()
        {
            score[0] = score[0] + CheckWin('O');
            return 1;
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

        public int ValidGameInput()
        {
            string Select_Num = Console.ReadLine();

            if (Select_Num.Length == 1)  
            {
                char Char_Num = Convert.ToChar(Select_Num);
                int input = Convert.ToInt32(Char_Num);

                if( input >= 49 && input <= 57)
                {
                    return input - '0';
                }
                else
                {
                    Console.WriteLine("Choose an unselected number from 1 to 9");
                    return ValidGameInput();  // 새로 입력값 
                }
            }
            else
            {
                Console.WriteLine("Choose an unselected number from 1 to 9");
                return ValidGameInput();  // 새로 입력값 
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
            Console.WriteLine("└---------------------------------------┘")
        }

        public void PrintGameOver()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                  GAME OVER !!!                 │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }

    }


}
