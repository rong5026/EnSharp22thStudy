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

        public void BorrowBook() // 책 대여
        {
            List<BookVO> bookList = new List<BookVO>();
            Console.SetWindowSize(125, 60);

            Console.Clear();
            userModeUI.BorrowBook();
            libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
            Console.SetCursorPosition(35, 2); // 커서이동

            mySQlData.CheckBookList(bookList);
            while (Constants.isPROGRAM_ON)
            {
                bookId = validInput.EnterBookId(35, 2); // 책Id 1~999수
                if (bookId == Constants.INPUT_EMPTY)
                    return;
               
            }
        }

    }
}
