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

        public static List<UserVO> userList; 
        public static List<BookVO> bookList;
   

        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        UserMode userMode = new UserMode();
        ManagerMode managerMode = new ManagerMode();    
        UserVO user;
        BookVO bookVO;

        int menuNumber;

        
      
        
        

    
        public LibraryStart()
        {
           
            userList = new List<UserVO>();
            bookList = new List<BookVO>();
            user = new UserVO(null, null, null, null, null, null);  //현재 로그인한 계정
            userList.Add(user);

            user = new UserVO("hong1234", "hong1234", "홍영환", "23", "010-8791-4859", "서울시"); // 계정1
            userList.Add(user);
            user = new UserVO("abcd1234", "abcd1234", "피카츄", "21", "010-1234-1234", "서울시 오류동"); // 계정2
            userList.Add(user);

            //int id, string name, string author, string publisher, int bookCount, int price, string date
            bookVO = new BookVO(BookVO.totalBook, "자료구조 및 실습", "국형준", "세종대", 2, 14000, "2020-02-02");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "노래방가고싶다", "홍영환", "세종대", 1, 10000, "2020-04-08");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "너두? 나두", "황기태", "생능출판", 3, 20000, "2021-03-02");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "안드로이드 앱 프로그래밍", "정재곤", "이지스퍼블리싱", 5, 28000, "2021-10-08");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "해커스토익", "다비드초", "어학연구소", 1, 30000, "2022-01-04");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "아끼고 아낀 말", "정세운", "위즈덤하우스", 5, 20000, "2012-08-05");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "신 테니스의 왕자", "코노미 타케시", "대원씨아이", 1, 35000, "2017-05-22");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "꿈은 없고요, 그냥 성공하고 싶습니다.", "홍님지", "다산북스", 2, 18000, "2017-07-05");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "10배의 법칙", "그랜트 카돈", "유어마나", 9, 5000, "2022-04-05");
            bookList.Add(bookVO);
            bookVO = new BookVO(BookVO.totalBook, "LG가 사장을 만드는 법", "이웅범", "세이코리아", 1, 17700, "2017-06-05");
            bookList.Add(bookVO);


        }
        public void StartProgram()
        {
           


            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);

            while (Const.PROGRAM_ON)
            {
                menuNumber = mode.SelectMode(Const.USER_MANAGER); // 회원모드 . 유저모드 선택
                switch (menuNumber)
                {
                    case Const.USER_MODE: // 유저모드 일때
                        userMode.StartUserMode();
                        break;
                    case Const.MANAGE_MODE: // 관리자 모드
                        managerMode.StartManagerMode();
                        break;
                    case Const.STOP:
                        UI.PrintProgramStop(); // 종료
                        return;


                }

            }
        
        }


    }

}
