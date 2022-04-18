using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class LoginUI
    {

       LectureTimeUI lectureTimeUI = new LectureTimeUI();

        public void PrintLoginUI() // 로그인 UI출력
        {
            Console.SetWindowSize(Constants.WIDTH, 40);

          
            Console.WriteLine("\n\n");
            lectureTimeUI.PrintCenter("학 사 정 보 시 스 템", Constants.WIDTH+2);
            lectureTimeUI.PrintCenter("ESC : 프로그램 종료\n", Constants.WIDTH+60);
            lectureTimeUI.PrintCenter("============================== Sejong University ==============================\n\n", Constants.WIDTH+10);
            Console.WriteLine("                                                                       ▣      ▣▣▣    ▣▣▣  ▣▣▣▣  ▣      ▣");
            Console.WriteLine("                                                                       ▣     ▣    ▣  ▣          ▣     ▣▣    ▣");
            Console.WriteLine("                                                                       ▣     ▣    ▣  ▣   ▣     ▣     ▣  ▣  ▣");
            Console.WriteLine("                                                                       ▣     ▣    ▣  ▣    ▣    ▣     ▣    ▣▣");
            Console.WriteLine("                                                                       ▣▣▣  ▣▣▣    ▣▣▣  ▣▣▣▣  ▣      ▣\n\n");
        
            lectureTimeUI.PrintCenter("학번(8자리숫자) : \n", Constants.WIDTH-10); //62 15         
            lectureTimeUI.PrintCenter("비밀번호(8~14자리) : \n\n", Constants.WIDTH-10); // 63 16

    

            lectureTimeUI.PrintCenter("===============================================================================", Constants.WIDTH+10);

          
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
            lectureTimeUI.PrintCenter("학 사 정 보 시 스 템", Constants.WIDTH+2);
            lectureTimeUI.PrintCenter("ESC : 프로그램 종료\n", Constants.WIDTH+60);
            lectureTimeUI.PrintCenter("============================== Sejong University ==============================\n\n", Constants.WIDTH+10);
            Console.WriteLine("                                                                      ▣▣▣  ▣▣▣▣   ▣▣▣   ▣▣▣");
            Console.WriteLine("                                                                     ▣          ▣     ▣    ▣   ▣   ▣");
            Console.WriteLine("                                                                      ▣▣▣     ▣     ▣    ▣   ▣▣▣");
            Console.WriteLine("                                                                           ▣    ▣     ▣    ▣   ▣ ");
            Console.WriteLine("                                                                      ▣▣▣     ▣      ▣▣▣    ▣       \n\n");
            lectureTimeUI.PrintCenter("===============================================================================", Constants.WIDTH+10);

        }
        public void PrintReLogin() // 틀리거나 존재하지 않는 ID로그인시 
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\n");
            lectureTimeUI.PrintCenter("학 사 정 보 시 스 템", Constants.WIDTH+2);
            lectureTimeUI.PrintCenter("ESC : 프로그램 종료\n", Constants.WIDTH+60);
            lectureTimeUI.PrintCenter("============================== Sejong University ==============================\n\n\n\n", Constants.WIDTH+10);
            lectureTimeUI.PrintCenter("존재하지 않는 ID이거나, 비밀번호가 틀립니다!!\n\n", Constants.WIDTH);
            lectureTimeUI.PrintCenter(" 종료 : ESC      다시 로그인 : ENTER\n\n\n", Constants.WIDTH);
            lectureTimeUI.PrintCenter("===============================================================================", Constants.WIDTH+10);
        }
        




    }
}
