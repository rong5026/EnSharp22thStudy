﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class LoginUI
    {

        StringSort sort = new StringSort();

        public void PrintLoginUI() // 로그인 UI출력
        {
            Console.SetWindowSize(Constant.WIDTH, 40);

          
            Console.WriteLine("\n\n");
            sort.PrintCenter("학 사 정 보 시 스 템", Constant.WIDTH+2);
            sort.PrintCenter("ESC : 프로그램 종료\n", Constant.WIDTH+60);
            sort.PrintCenter("============================== Sejong University ==============================\n\n", Constant.WIDTH+10);
            Console.WriteLine("                                                                       ▣      ▣▣▣    ▣▣▣  ▣▣▣▣  ▣      ▣");
            Console.WriteLine("                                                                       ▣     ▣    ▣  ▣          ▣     ▣▣    ▣");
            Console.WriteLine("                                                                       ▣     ▣    ▣  ▣   ▣     ▣     ▣  ▣  ▣");
            Console.WriteLine("                                                                       ▣     ▣    ▣  ▣    ▣    ▣     ▣    ▣▣");
            Console.WriteLine("                                                                       ▣▣▣  ▣▣▣    ▣▣▣  ▣▣▣▣  ▣      ▣\n\n");
        
            sort.PrintCenter("학번(8자리숫자) : \n", Constant.WIDTH-10); //62 15         
            sort.PrintCenter("비밀번호(8~14자리) : \n\n", Constant.WIDTH-10); // 63 16

    

            sort.PrintCenter("===============================================================================", Constant.WIDTH+10);

          
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
            

            Console.WriteLine("\n\n");
            sort.PrintCenter("학 사 정 보 시 스 템", Constant.WIDTH+2);
            sort.PrintCenter("ESC : 프로그램 종료\n", Constant.WIDTH+60);
            sort.PrintCenter("============================== Sejong University ==============================\n\n", Constant.WIDTH+10);
            Console.WriteLine("                                                                      ▣▣▣  ▣▣▣▣   ▣▣▣   ▣▣▣");
            Console.WriteLine("                                                                     ▣          ▣     ▣    ▣   ▣   ▣");
            Console.WriteLine("                                                                      ▣▣▣     ▣     ▣    ▣   ▣▣▣");
            Console.WriteLine("                                                                           ▣    ▣     ▣    ▣   ▣ ");
            Console.WriteLine("                                                                      ▣▣▣     ▣      ▣▣▣    ▣       \n\n");
            sort.PrintCenter("===============================================================================", Constant.WIDTH+10);

        }
        public void PrintReLogin() // 틀리거나 존재하지 않는 ID로그인시 
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\n");
            sort.PrintCenter("학 사 정 보 시 스 템", Constant.WIDTH+2);
            sort.PrintCenter("ESC : 프로그램 종료\n", Constant.WIDTH+60);
            sort.PrintCenter("============================== Sejong University ==============================\n\n\n\n", Constant.WIDTH+10);
            sort.PrintCenter("존재하지 않는 ID이거나, 비밀번호가 틀립니다!!\n\n", Constant.WIDTH);
            sort.PrintCenter(" 종료 : ESC      다시 로그인 : ENTER\n\n\n", Constant.WIDTH);
            sort.PrintCenter("===============================================================================", Constant.WIDTH+10);
        }
        




    }
}
