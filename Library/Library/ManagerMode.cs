using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class ManagerMode
    {
        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        BookListAndSearch book = new BookListAndSearch();
        ValidInput validInput = new ValidInput();
        BookVO bookVO = new BookVO();
        const bool PROGRAM_ON = true;
        const int BOOK_REGISTRATION = 1;
        const int BOOK_UPDATE = 2;
        const int BOOK_DELETE = 3;
        const int BOOK_SEARCH = 4;
        const int BOOK_LIST = 5;
        const int EXIT = -1;

        string name;
        string author;
        string publisher;
        int bookCount;
        int price;
        string date;
        ConsoleKeyInfo keyInput;

        int menuNumber;
        public void StartManagerMode()
        {
            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);



            UI.PrintManagerMenuUI(1);
            while (PROGRAM_ON)
            {
                menuNumber = mode.SelectUserOrManagerMenu("Manager",5);// 위아래 화살표 입력
                Console.SetWindowSize(125, 60);
                switch (menuNumber)
                {
                    case BOOK_REGISTRATION: // 도서 등록        
                        RegisterBook();
                        break;
                    case BOOK_UPDATE: // 도서 수량 수정
                     
                        break;
                    case BOOK_DELETE: //도서 삭제
                     
                        break;
                    case BOOK_SEARCH: // 도서 검색
                        book.SearchBook();
                        break;
                    case BOOK_LIST: // 도서 출력
                       

                        ShowBookList();
                        break;              
                    case EXIT:
                        return;
                    default:
                        return;


                }

            }
        }

        
        public void ShowBookList()
        {
           

            Console.Clear();
            UI.PrintBookList();
            UI.PrintBookList(null, null, null);

            keyInput = Console.ReadKey(true);
            return;  // 아무키 입력시 뒤로가기
        }

        public void RegisterBook() //책등록
        {
            Console.Clear();
            UI.PrintRegisterBook();


            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                name = validInput.EnterBookName(11,8);  //책 이름
                author = validInput.EnterAuthor(8,9); // 책 저자
                publisher = validInput.EnterBookPublisher(10,10); // 책 출판사
                bookCount = Convert.ToInt16( validInput.EnterBookCount(8,11)); // 책 수량
                price = Convert.ToInt16(validInput.EnterBookPrice(8,12)); // 가격
                date = validInput.EnterBookDate(10, 13); // 출시날짜


                // 책 등록

                bookVO = new BookVO(BookVO.totalBook, name, author, publisher, bookCount, price, date);
                BookVO.totalBook++;  // 도서관 책 1개 증가
                LibraryStart.bookList.Add(bookVO); // 책 리스트에 책 추가

                // 등록완료 UI
                Console.Clear();
                UI.PrintRegisterBookSuccess();             

                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 

            }              
        }
        
    }
}
