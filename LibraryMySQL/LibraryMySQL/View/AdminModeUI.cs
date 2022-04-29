﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminModeUI
    {

        public void PrintAdminMenuMessage(string message,string reEnter) // Admin Main UI
        {
            Console.WriteLine("                                     ■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                          {0}                   ", message);
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                     ■■■■■■■■■■■■■■■■■■■■■■■■■■\n\n");
            Console.WriteLine("                                            ENTER : {0}          ESC : 뒤로가기  \n\n\n", reEnter);

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
        public void PrintRegisteredBook(BookVO bookVO) // 선택한 책 정보 출력
        {
            Console.WriteLine("                                                  ◈현재 등록되어 있는 정보◈\n\n");
            Console.WriteLine("                             책 제목 (영어, 한글, 숫자 1개 이상) : {0}",bookVO.Name );
            Console.WriteLine("                             작가 (   영어, 한글 1글자 이상  )   : {0}",bookVO.Author );
            Console.WriteLine("                             출판사 (영어, 한글, 숫자 1개 이상)  : {0}",bookVO.Publisher );
            Console.WriteLine("                             수량 (    1~999 사이의 자연수   )   : {0}",bookVO.BookCount );
            Console.WriteLine("                             가격 (   1~9999999 사이의 자연수  ) : {0}",bookVO.Price );
            Console.WriteLine("                             출시일 (    19xx or 20xx-xx-xx    ) : {0}",bookVO.Date );
            Console.WriteLine("\n");
            Console.WriteLine("                                                  ◈변경 할 정보 입력 ◈\n\n");
        }

        public void PrintUserData(string userName) // 유저 이름 출력
        {
            Console.WriteLine("============================================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" User Name  : {0}", userName);
            Console.ResetColor();
          
        }
    }
}
