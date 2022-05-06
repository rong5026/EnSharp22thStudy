using System;
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
            Console.WriteLine("                                출시일    : ");
            Console.WriteLine("                                ISBN      : ");
            Console.WriteLine("                                정보      : \n");
            Console.WriteLine("                                ------------------------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("                                            책 제목 - 영어,한글,숫자,?!+= 1개 이상 ");
            Console.WriteLine("                                            작가    - 영어, 한글 1글자 이상");
            Console.WriteLine("                                            출판사  - 영어, 한글, 숫자 중 1개 이상");
            Console.WriteLine("                                            수량    - 1~999 사이의 자연수");
            Console.WriteLine("                                            가격    - 1~9999999 사이의 자연수");
            Console.WriteLine("                                            출시일  - 19xx or 20xx-xx-xx ");
            Console.WriteLine("                                            ISBN    - 정수9개 + 영어1개 + 공백 + 정수13개");
            Console.WriteLine("                                            정보    - 최소1개의 문자(공백포함)\n");
            Console.ResetColor();
            Console.WriteLine("                                ------------------------------------------------------------\n");
          
            
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
        public void PrintRegisteredBook(BookDTO bookVO) // 선택한 책 정보 출력
        {
            Console.WriteLine("                                                  ◈현재 등록되어 있는 정보◈\n\n");
            Console.WriteLine("                             책제목(영어,한글,숫자,?!+= 1개 이상): {0}",bookVO.Name );
            Console.WriteLine("                             작가 (   영어, 한글 1글자 이상  )   : {0}",bookVO.Author );
            Console.WriteLine("                             출판사 (영어, 한글, 숫자 1개 이상)  : {0}",bookVO.Publisher );
            Console.WriteLine("                             수량 (    1~999 사이의 자연수   )   : {0}",bookVO.BookCount );
            Console.WriteLine("                             가격 (   1~9999999 사이의 자연수  ) : {0}",bookVO.Price );
            Console.WriteLine("                             출시일 (    19xx or 20xx-xx-xx    ) : {0}",bookVO.Date );
            Console.WriteLine("\n");
            Console.WriteLine("                                                  ◈변경 할 정보 입력 ◈\n\n");
        }

        public void PrintUserName(string userName) // 유저 이름 출력
        {
            Console.WriteLine("============================================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" User Name  : {0}", userName);
            Console.ResetColor();
          
        }
        public void PrintUserData(UserDTO userVO) // 유저 정보 출력
        {
            Console.WriteLine("============================================================================================================================\n");

            Console.WriteLine(" 유저Number : {0}", userVO.Number);
            Console.WriteLine(" 유저 ID    : {0}",userVO.Id);
            Console.WriteLine(" 유저 이름  : {0}", userVO.Name);
            Console.WriteLine(" 유저 나이  : {0}", userVO.Age);
            Console.WriteLine(" 유저 번호  : {0}", userVO.PhoneNumber);
            Console.WriteLine(" 유저 주소  : {0}\n\n", userVO.Address);

        }
        public void PrtinInputNaverBook(string enterMessage,string escMessage)
        {
            Console.WriteLine();
            Console.WriteLine("   책 이름    :");
            Console.WriteLine(" 찾을 책 수량 :\n");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ESC : {0}                 ", escMessage);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ENTER : {0}              ", enterMessage);
            Console.ResetColor();
        }
        public void PrintInputNaverISBN(string mainMessage,string enterMessage, string escMessage)
        {
            Console.WriteLine();
         
            Console.WriteLine("   {0}    :                                                   ", mainMessage);
            Console.WriteLine("                                               \n ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ESC : {0}                                                                                                     ", escMessage);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ENTER : {0}                                                                       ", enterMessage);
            Console.ResetColor();
        }
        
        public void PrintNaverBookList(string isbn,string title, string author, int price, string publisher, string pubdate, string description) // 네이버에서 찾은책 줄력
        {
            Console.WriteLine();

            Console.WriteLine("===========================================================================================================================\n");
      
            Console.WriteLine("책 ISBN  : {0} ", isbn);
            Console.WriteLine("책 제목  : {0} ", title);
            Console.WriteLine("작가     : {0} ", author);
            Console.WriteLine("가격     : {0} ", price);
            Console.WriteLine("출판사   : {0} ", publisher);
            Console.WriteLine("출시일   : {0} ", pubdate);
            Console.WriteLine("책 설명  : {0} ", description);
            Console.WriteLine("");

        }
        public void PrintLogData(List<LogDTO> list) // 로그 정보 출력
        {

            for (int index = 0; index < list.Count; index++)
            {
                Console.WriteLine("============================================================================================================================\n");

                Console.WriteLine(" 로그 ID     : {0}", list[index].Id);
                Console.WriteLine(" 로그 시간   : {0}", list[index].Time);
                Console.WriteLine(" 로그 사용자 : {0}", list[index].User);
                Console.WriteLine(" 로그 정보   : {0}", list[index].Information);
                Console.WriteLine(" 로그 행동   : {0}\n\n", list[index].Action);
            }
        }

    }
}
