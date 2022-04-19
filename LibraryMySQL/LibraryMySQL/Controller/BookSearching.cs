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
        private string name;
        private string author;
        private string publisher;

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
        

    }
}
