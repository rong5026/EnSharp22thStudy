using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BookListAndSearch
    {

        const int BOOK_LIST = 1;
        LibraryUI UI = new LibraryUI();
        ConsoleKeyInfo keyInput;
        ValidInput validInput = new ValidInput();
        string name=null;
        string author=null;
        string publisher=null;
       

        public void SearchBook()
        {
            Console.Clear();
            UI.PrintSearchBook();
            UI.PrintBookList(BOOK_LIST,null,null,null); //  type이 1일때 전체 북리스트 출력.
            Console.SetCursorPosition(18, 1);
            //18,1
            //19,2
            //18,3
            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
              
                name = validInput.EnterBookName();
                author = validInput.EnterAuthor();
                publisher = validInput.EnterBookPublisher();
                
                Console.Clear();
                UI.PrintSearchBook();
                UI.PrintBookList(BOOK_LIST, name, author, publisher);

                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 
            }
        }

        public void BorrowBook()
        {

        }


       
       



    }
}
