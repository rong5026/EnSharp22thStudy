using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminModeUI
    {

        public void PrintAdminMenuMessage(string message) // Admin Main UI
        {
            Console.WriteLine("                                     ■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                          {0}                   ", message);
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                     ■■■■■■■■■■■■■■■■■■■■■■■■■■\n\n");
            Console.WriteLine("                                            ENTER : 확인          ESC : 뒤로가기  \n\n\n");

        }
        public void PrtinInputAddBook() // 책 입력 UI
        {
            Console.WriteLine("                                ------------------------------------------------------------\n");        
            Console.WriteLine("                                책 제목   : ");
            Console.WriteLine("                                작가      : ");
            Console.WriteLine("                                출판사    : ");
            Console.WriteLine("                                수량      : ");
            Console.WriteLine("                                가격      : ");
            Console.WriteLine("                                출시일    : \n");
            Console.WriteLine("                                ------------------------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("                                            책 제목 - 영어, 한글, 숫자 중 1개 이상 ");
            Console.WriteLine("                                            작가    - 영어, 한글 1글자 이상");
            Console.WriteLine("                                            출판사  - 영어, 한글, 숫자 중 1개 이상");
            Console.WriteLine("                                            수량    - 1~999 사이의 자연수");
            Console.WriteLine("                                            가격    - 1~9999999 사이의 자연수");
            Console.WriteLine("                                            출시일  - 19xx or 20xx-xx-xx \n");
            Console.ResetColor();
            Console.WriteLine("                                ------------------------------------------------------------\n");
            // 책 제목 중복 안됨 , 작가 중복 가능 , 출판사 중복 가능, 수량 중복가능, 가격 중복가능, 출시일 중복가능
            
        }
        public void PrintAddBookSuccess() // 책 추가 성공UI
        {
            Console.WriteLine("                                ------------------------------------------------------------\n");
            Console.WriteLine("                                                                                                   ");
            Console.WriteLine("                                                                                                 ");
            Console.WriteLine("                                                     **  책 추가 성공 !  **                               ");
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                               ");
            Console.WriteLine("                                                                                                   \n");
            Console.WriteLine("                                ------------------------------------------------------------\n");
        }
       
    }
}
