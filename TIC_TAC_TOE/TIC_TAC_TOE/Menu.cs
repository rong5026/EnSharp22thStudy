﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TAC_TOE
{
    internal class Menu
    {
        public int ShowMenu()
        {
           
            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│                 SELECT GAME MODE               │");
            Console.WriteLine("└------------------------------------------------┘");

            Console.WriteLine("┌------------------------------------------------┐");
            Console.WriteLine("│ 1.vs Computer  2.vs User  3.Scoreboard  0.Exit │");
            Console.WriteLine("└------------------------------------------------┘\n");


            ValidInput select_menu = new ValidInput();   // 1,2,3,0 값을 예외처리 후 입력
            return select_menu.ValidNumber();

        }
    }
}
