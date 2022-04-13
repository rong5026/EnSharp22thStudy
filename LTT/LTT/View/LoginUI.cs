﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    internal class LoginUI
    {
        private void PrintCenter(string data,int width) // 문구 센터에 정렬
        {
            Console.WriteLine(String.Format("{0}", data).PadLeft(width - (width/2 - data.Length / 2)));
        }
       
       
        public void PrintLoginUI() // 로그인 UI출력
        {
            Console.SetWindowSize(120, 30);

          
            Console.WriteLine("\n\n");
            PrintCenter("학 사 정 보 시 스 템", 112);
            PrintCenter("ESC : 프로그램 종료\n", 170);
            PrintCenter("============================== Sejong University ==============================\n\n",120);
            Console.WriteLine("                                    ▣      ▣▣▣    ▣▣▣  ▣▣▣▣  ▣      ▣");
            Console.WriteLine("                                    ▣     ▣    ▣  ▣          ▣     ▣▣    ▣");
            Console.WriteLine("                                    ▣     ▣    ▣  ▣   ▣     ▣     ▣  ▣  ▣");
            Console.WriteLine("                                    ▣     ▣    ▣  ▣    ▣    ▣     ▣    ▣▣");
            Console.WriteLine("                                    ▣▣▣  ▣▣▣    ▣▣▣  ▣▣▣▣  ▣      ▣\n\n");
        
            PrintCenter("학번(8자리숫자) : \n", 100); //62 15         
            PrintCenter("비밀번호(8~14자리) : \n\n", 100); // 63 16

    

            PrintCenter("===============================================================================", 120);

          
        }

        public void PrintErrorMessage(int x,int y,string errorMessage)// id,password 예외처리 실패
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write(errorMessage);
            Console.ResetColor();
        }
        public void PrintSuccessMessage(int x, int y, string successMessage) // id,password 예외처리 성공
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write(successMessage);
            Console.ResetColor();
        }
        public void PrintProgramStop() // 프로그램 종료
        {
            Console.Clear();
            Console.SetWindowSize(120, 30);

            Console.WriteLine("\n\n");
            PrintCenter("학 사 정 보 시 스 템", 112);
            PrintCenter("ESC : 프로그램 종료\n", 170);
            PrintCenter("============================== Sejong University ==============================\n\n", 120);
            Console.WriteLine("                                        ▣▣▣  ▣▣▣▣   ▣▣▣   ▣▣▣");
            Console.WriteLine("                                       ▣          ▣     ▣    ▣   ▣   ▣");
            Console.WriteLine("                                        ▣▣▣     ▣     ▣    ▣   ▣▣▣");
            Console.WriteLine("                                             ▣    ▣     ▣    ▣   ▣ ");
            Console.WriteLine("                                        ▣▣▣     ▣      ▣▣▣    ▣       \n\n");
            PrintCenter("===============================================================================", 120);

        }
        public void PrintReLogin()
        {

            Console.Clear();
            Console.CursorVisible = false;
            PrintCenter("학 사 정 보 시 스 템", 112);
            PrintCenter("ESC : 프로그램 종료\n", 170);
            PrintCenter("============================== Sejong University ==============================\n\n\n\n", 120);
            PrintCenter(" 종료 : ESC      다시 로그인 : ENTER\n\n\n",120);
            PrintCenter("===============================================================================", 120);
        }
        




    }
}
