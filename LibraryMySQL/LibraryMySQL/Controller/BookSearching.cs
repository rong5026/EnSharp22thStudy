using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL { 
    internal class BookSearching
    {
        ConsoleKeyInfo keyInput;
        LibraryUI libraryUI;
        ValidInput validInput;
        MySQlData mySQlData;
        UserModeUI userModeUI;
        private string name;
        private string author;
        private string publisher;
        private string bookId;
        public BookSearching()
        {
          
            libraryUI = new LibraryUI();
            userModeUI = new UserModeUI();
            validInput = new ValidInput();
            mySQlData = MySQlData.Instance();
        }
        public void SearchBook() // 책 검색
        {

            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
                Console.SetCursorPosition(18, 1); // 커서이동

                name = validInput.EnterBookName(18, 1); // 영어,한글 1글자이상
                if (name == Constants.BACKMENU)
                    return;
                author = validInput.EnterAuthor(19, 2); // 영어,한글 1글자 이상
                if (author == Constants.BACKMENU)
                    return;
                publisher = validInput.EnterBookPublisher(18, 3); // // 영어,한글, 숫자 1글자 이상
                if (publisher == Constants.BACKMENU)
                    return;


                Console.Clear();
                libraryUI.PrintSearchBook("Return");
                libraryUI.ShowBookList(name, author, publisher);

                Console.CursorVisible = false;
                while (Constants.isPROGRAM_ON)
                {
                    keyInput = Console.ReadKey(true);
                    if (keyInput.Key == ConsoleKey.Escape)
                        return; // ESC 누르면 뒤로가기 
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }

            }


        }

        public int BorrowBook() // 책 대여
        {
            List<BookVO> bookList = new List<BookVO>();
            Console.SetWindowSize(125, 50);

            Console.Clear();
            userModeUI.PrintBorrowBook();
            libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
           

            mySQlData.CheckBookList(bookList); // 저장된 책 list받아옴

            while (Constants.isPROGRAM_ON)
            {
                bookId = validInput.EnterBookId(35, 2); // 책Id 1~999수

                if (bookId == Constants.INPUT_EMPTY)//ESC 누르면 뒤로가기
                    return Constants.BACK;

                for(int index = 0; index < bookList.Count; index++)
                {
                    if(bookList[index].Id == Convert.ToInt16(bookId))// 책의 id가 같을때
                    {
                        if (bookList[index].BookCount >= 1)// 책이 1개 이상있을때
                        {
                            // 책 수량1개감소 
                            mySQlData.UpdateBookCount(bookList[index].BookCount - 1, bookList[index].Id);   
                            // 빌린 유저에 책정보 저장
                            mySQlData.InsertRentBook(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), bookList[index]);

                            //대여 성공 메시지 출력
                            Console.SetCursorPosition(0, 0);
                            Console.CursorVisible = false;
                            userModeUI.PrintBorrowBookMessage("책 빌리기 성공!");

                            if (EnterBack() == Constants.RESTART)
                                return BorrowBook();         
                               
                            return Constants.BACK;

                        }
                    }
                }
                // 책 빌리기 실패
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                userModeUI.PrintBorrowBookMessage("책 빌리기 실패! 수량이 없거나 유효하지 않은 책 ID 입니다!");

                if (EnterBack() == Constants.RESTART)
                    return BorrowBook();

                return Constants.BACK;
            }
        }


        private int EnterBack() // 다시 할지 뒤로갈지 선택
        {
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Enter) // 대여 다시하기
                {
                    Console.SetCursorPosition(0, 0);
                    userModeUI.PrintBorrowBook();
                    libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
                    return Constants.RESTART;
                }
                else if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACK;

            }
        }

        public void ConfirmRentedBook() // 빌린책 확인
        {
            Console.Clear();
            userModeUI.PrintRentedBook(); // 빌린책 UI 출력

            List<BookVO> list = new List<BookVO>();

            mySQlData.CheckRentBook(list); //로그인된 사람의 빌린책

            libraryUI.ShowRentedBookList(list);
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape) // 대여 다시하기           
                    return;
                
            }
        }
    }
}
