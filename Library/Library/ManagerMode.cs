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
        const bool PROGRAM_ON = true;
        const int BOOK_REGISTRATION = 1;
        const int BOOK_UPDATE = 2;
        const int BOOK_DELETE = 3;
        const int BOOK_SEARCH = 4;
        const int BOOK_LIST = 5;
        const int EXIT = -1;
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

                switch (menuNumber)
                {
                    case BOOK_REGISTRATION: // 도서 등록        
                        
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
            Console.SetWindowSize(125, 60);

            Console.Clear();
            UI.PrintBookList();
            UI.PrintBookList(null, null, null);

            keyInput = Console.ReadKey(true);
            return;  // 아무키 입력시 뒤로가기
        }
        
    }
}
