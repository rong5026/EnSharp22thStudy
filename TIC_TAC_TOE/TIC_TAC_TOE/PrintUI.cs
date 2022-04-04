using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class PrintUI
    {

        public void PrintBoard(char[] gameBoard,int gameType)
        {

            Console.WriteLine("┌---------------------------------------┐");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", gameBoard[1], gameBoard[2], gameBoard[3]);
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│------------││------------││-----------│");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", gameBoard[4], gameBoard[5], gameBoard[6]);
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│------------││------------││-----------│");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│      {0}     ││      {1}     ││     {2}     │", gameBoard[7], gameBoard[8], gameBoard[9]);
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("│            ││            ││           │");
            Console.WriteLine("└---------------------------------------┘");

            if (gameType == 1)
            {
                Console.WriteLine("│  USER_1 =  [ O ]      USER_2 = [ X ]  │");
                Console.WriteLine("└---------------------------------------┘");
            }
            else
            {
                Console.WriteLine("│  USER_1 =  [ O ]    Computer = [ X ]  │");
                Console.WriteLine("└---------------------------------------┘");
            }

        }
       

        public void PrintGameOver()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.Write("│                  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER !!!");
            Console.ResetColor();
            Console.WriteLine("                 │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }

        public void PrintMenu()
        {
         
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                 SELECT GAME MODE               │");
            Console.WriteLine("└------------------------------------------------┘");
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│ 1.vs Computer  2.vs User  3.Scoreboard  0.Exit │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }
        public void PrintGameStart()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│            TIC TAC TOE GAME START !!           │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }

        public void PrintGameStop()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                  GAME STOP !!!                 │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }
        public void PrintFirstUserWin()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.Write("│                  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("USER_1 WIN !!!");
            Console.ResetColor();
            Console.WriteLine("                │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }

        public void PrintSecondUserWin()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.Write("│                  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("USER_2 WIN !!!");
            Console.ResetColor();
            Console.WriteLine("                │");
            Console.WriteLine("└------------------------------------------------┘\n");
         
        }
        public void PrintDraw()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.Write("│                    ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("DRAW !!!");
            Console.ResetColor();
            Console.WriteLine("                    │");
            Console.WriteLine("└------------------------------------------------┘\n");
        }
        public void PrintComputerWin()
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.Write("│                 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Computer WIN !!!");
            Console.ResetColor();
            Console.WriteLine("               │");
            Console.WriteLine("└------------------------------------------------┘\n");

        }
        public void PrintScore(int userScore, int computerScore)
        {
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│        USER SCORE : " + userScore + "    COMPUTER SOCRE :" + computerScore + "     │");
            Console.WriteLine("└------------------------------------------------┘\n"); 
        }
       
        public void PrintGameInputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Choose an unselected number from 1 to 9");
            Console.ResetColor();
        }

        public void PrintDistinguishUser(int usernum) // 유저 정보 출력
        {
            if (usernum == 1)
            {
                Console.WriteLine(" [User_1][ O ]  Select Number( 1 to 9 )");
                Console.WriteLine("==========================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" USER_1 : ");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine(" [User_2][ X ]  Select Number( 1 to 9 )");
                Console.WriteLine("==========================================");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" USER_2 : ");
                Console.ResetColor();
            }
        }

        public void PrintNumberError()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("       Enter an integer between 0 and 3 !!! \n");
            Console.ResetColor();
        }
    

    }
}
