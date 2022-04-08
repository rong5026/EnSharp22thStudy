using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BookListAndSearch
    {

   
        LibraryUI UI = new LibraryUI();
        ConsoleKeyInfo keyInput;
        ValidInput validInput = new ValidInput();
        string name=null;
        string author=null;
        string publisher=null;
        string bookId;
       

        public void SearchBook()
        {
            Console.Clear();
            UI.PrintSearchBook();
            UI.PrintBookList(null,null,null); //  전체 북리스트 출력.
            Console.SetCursorPosition(18, 1); // 커서이동
       
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
                UI.PrintBookList( name, author, publisher);

                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 
            }
        }

        public void BorrowBook()
        {
            Console.SetWindowSize(125, 50);
            Console.Clear();
            UI.BorrowBook();
            UI.PrintBookList(null, null, null); //  전체 북리스트 출력.
            Console.SetCursorPosition(35, 2); // 커서이동

 
            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
                bookId = validInput.EnterBookId();

                for(int index = 0; index < LibraryStart.bookList.Count; index++)
                {
                    if(LibraryStart.bookList[index].Id == Convert.ToInt16(bookId)) // 책의 id가 같으면
                    {
                        if (LibraryStart.bookList[index].BookCount >= 1) ; // 책이 1개이상 있을때
                        {
                            LibraryStart.bookList[index].BookCount--; // 해당책의 보유양 1개 감소
                            BookVO.totalBook--;  //도서관에 있는 도서수 1개 감소

                            LibraryStart.userList[SearchLoginUserIndex()].RendtedBookId.Add(index);// Book의 index를 userList의 RentedBookid리스트에 추가
                            break;                        

                        }
                    }
                }

                Console.SetCursorPosition(0, 0);
                UI.PrintSuccessRentBook();
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Enter)
                    return; // 뒤로가기 

            }
        }

        public void ConfirmRentedBook()
        {
            Console.SetWindowSize(125, 50);
            Console.Clear();
            UI.PrintRentedBookList(SearchLoginUserIndex());
            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Enter)
                return; // 뒤로가기 

        }
        public int SearchLoginUserIndex() // 로그인한 사람의 index를 return함
        {

            for(int index = 1; index < LibraryStart.userList.Count; index++)
            {
                if (LibraryStart.userList[0].Id == LibraryStart.userList[index].Id)
                    return index;
            }
            return -1;
        }


       
       



    }
}
