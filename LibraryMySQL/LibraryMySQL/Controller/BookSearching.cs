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
        ValidInput validInput = new ValidInput();
        MySQlData mySQlData;
        UserModeUI userModeUI = new UserModeUI();
        private string name;
        private string author;
        private string publisher;
        private string bookId;
        public BookSearching(MySQlData mySQlData)
        {
            this.mySQlData = mySQlData;
            libraryUI = new LibraryUI(mySQlData);
        }
        public void SearchBook() // 책 검색
        {

            
            Console.Clear();
            libraryUI.PrintSearchBook();
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
            libraryUI.PrintSearchBook();
            libraryUI.ShowBookList(name, author, publisher);

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 
            }
            



        }

        public void BorrowBook() // 책 대여
        {
            List<BookVO> bookList = new List<BookVO>();
            Console.SetWindowSize(125, 60);

            Console.Clear();
            userModeUI.BorrowBook();
            libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
            Console.SetCursorPosition(35, 2); // 커서이동

            mySQlData.CheckBookList(bookList);
            while (Constants.PROGRAM_ON)
            {
                bookId = validInput.EnterBookId(35, 2); // 책Id 1~999수
                if (bookId == Constants.INPUT_EMPTY)
                    return;
                /*for (int index = 0; index < bookList.Count; index++)
                {
                    if (bookList[index].Id == Convert.ToInt16(bookId)) // 책의 id가 같으면
                    {
                        if (bookList[index].BookCount >= 1) ; // 책이 1개이상 있을때
                        {
                            bookList[index].BookCount--; // 해당책의 보유양 1개 감소
                            BookVO.totalBook--;  //도서관에 있는 도서수 1개 감소

                            LibraryStart.userList[loginUser.SearchLoginUser()].RendtedBookId.Add(index);// Book의 index를 userList의 RentedBookid리스트에 추가

                            Console.SetCursorPosition(0, 0);
                            userModeUI.PrintSuccessRentBook();
                           keyInput = Console.ReadKey(true);
                            return; // 뒤로가기 
                        }
                    }

                    Console.SetCursorPosition(0, 0);
                    userModeUI.PrintFailRentBook();
                    keyInput = Console.ReadKey(true);
                    return; // 뒤로가기 



                }*/
            }
        }

    }
}
