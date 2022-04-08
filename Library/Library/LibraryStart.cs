using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library
{

    internal class LibraryStart
    {

        public static List<UserVO> userList = new List<UserVO>();
        public static List<BookVO> bookList = new List<BookVO>();


        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        UserMode userMode = new UserMode();
        UserVO user;
        BookVO book;

        const Boolean PROGRAM_ON = true;
        const int USER_MANAGER = 1;
        const int LOGIN_REGISTER = 2;
        int menuNumber;
        const int USER_MODE = 1;
        const int MANAGE_MODE = 2;
        const int STOP = -1;


        public LibraryStart()
        {
            user = new UserVO(null, null, null, null, null, null);  //현재 로그인한 계정
            userList.Add(user);

            user = new UserVO("hong1234", "hong1234", "홍영환", "23", "010-8791-4859", "서울시"); // 계정1
            userList.Add(user);
            user = new UserVO("abcd1234", "abcd1234", "피카츄", "21", "010-1234-1234", "서울시 오류동"); // 계정2
            userList.Add(user);

            //int id, string name, string author, string publisher, int bookCount, int price, string date)
            book = new BookVO(BookVO.totalBook, "자료구조 및 실습", "국형준", "세종대", 2, 14000, "2020-02-02");

            bookList.Add(book);
            book = new BookVO(BookVO.totalBook, "노래방가고싶다", "홍영환", "세종대", 1, 10000, "2020-04-08");
            bookList.Add(book);
            book = new BookVO(BookVO.totalBook, "너두? 나두", "황기태", "생능출판", 3, 20000, "2021-03-02");
            bookList.Add(book);
            book = new BookVO(BookVO.totalBook, "자바스크립트", "고경희", "이지스퍼블리싱", 1, 8000, "2022-11-05");
            bookList.Add(book);

        }
        public void StartProgram()
        {
       
            UI.PrintMainUI();
            Console.SetWindowSize(125, 45);
          
            while (PROGRAM_ON)
            {
                menuNumber = mode.SelectMode(USER_MANAGER); // 회원모드 . 유저모드 선택
                switch (menuNumber)
                {
                    case USER_MODE: // 유저모드 일때
                        userMode.StartUserMode(userList);
                        break;
                    case MANAGE_MODE: // 관리자 모드
                        break;
                    case STOP:
                        UI.PrintProgramStop(); // 종료
                        return;


                }

            }

        }


    }

}
