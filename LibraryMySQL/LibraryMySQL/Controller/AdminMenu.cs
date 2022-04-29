using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminMenu
    {
        LibraryUI libraryUI;
        SelectionMode mode;
        BookSearching bookSearching;
        UserModeUI userModeUI;
        AdminModeUI adminModeUI;
        ValidInput validInput;
        MySQlData mySQlData;
        Login login;
        ConsoleKeyInfo keyInput;

        public AdminMenu(ValidInput validInput, UserModeUI userModeUI)
        {
            this.validInput = validInput;
            this.userModeUI = userModeUI;
            libraryUI = new LibraryUI();
            adminModeUI = new AdminModeUI();
            bookSearching = new BookSearching(validInput, libraryUI);        
            mode = new SelectionMode(libraryUI);
            mySQlData = MySQlData.Instance();
            login = new Login(userModeUI, validInput);
        }

        public void StartAdminMode()
        {
            int input;
            while (Constants.isPROGRAM_ON)
            {
                input = login.LoginUser("Admin");

                if (input == Constants.ADMIN_MODE)
                    StartAdminMenu();
                else if (input == Constants.BACK)               
                    return;
                   
                

            }
        }
        public void StartAdminMenu()
        {
            int menuNumber;

            libraryUI.PrintMainUI();
            while (Constants.isPROGRAM_ON)
            {

                menuNumber = mode.SelectUserManagerMenu("Admin", 6); // 유저메뉴 위아래 화살표로 선택하기

                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: //도서찾기                  
                        bookSearching.SearchBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_ADD: // 도서추가             
                        AddBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_DELETE: //도서삭제         
                        DeleteBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_EDIT: // 도서수정                

                        break;
                    case Constants.USER_CARE: // 회원관리

                        break;
                    case Constants.TOTAL_USER_RENTBOOK: // 대여상황보기

                        break;
                    case Constants.EXIT:
                        Console.Clear();
                        return;
                    default:
                        return;


                }


            }

        }

        private void AddBook() // 도서 추가
        {
            
            string name;
            string author;
            string publisher;
            string count;
            string price;
            string date;
            BookVO bookVO;

            Console.Clear();
            while (Constants.isPROGRAM_ON)
            {
                adminModeUI.PrintAdminMenuMessage("도서추가");
                adminModeUI.PrtinInputAddBook();
              

                name = validInput.EnterBookName(44, 15); // 책 이름 입력
                if (name == Constants.INPUT_BACK)
                    break;
                author = validInput.EnterInput(44, 16,ErrorMessage.BOOK_AUTHOR,RegularExpression.BOOK_AUTHOR); // 저자 입력
                if (author == Constants.INPUT_BACK)
                    break;
                publisher = validInput.EnterInput(44, 17,ErrorMessage.BOOK_PUBISHER,RegularExpression.BOOK_PUBISHER); // 출판사
                if (publisher == Constants.INPUT_BACK)
                    break;
                count = validInput.EnterInput(44, 18,ErrorMessage.BOOK_COUNT,RegularExpression.BOOK_COUNT); // 책 수량
                if (count == Constants.INPUT_BACK)
                    break;
                price = validInput.EnterInput(44, 19,ErrorMessage.BOOK_PRICE,RegularExpression.BOOK_PRICE); // 책 가격
                if (price == Constants.INPUT_BACK)
                    break;
                date = validInput.EnterInput(44, 20,ErrorMessage.BOOK_DATE,RegularExpression.BOOK_DATE); // 책 출판날짜
                if (date == Constants.INPUT_BACK)
                    break;
                bookVO =new BookVO();

                bookVO.Name = name;
                bookVO.Author = author;
                bookVO.Publisher = publisher;
                bookVO.BookCount = Convert.ToInt16( count);
                bookVO.Price = Convert.ToInt32( price );
                bookVO.Date = date;

                mySQlData.InsertBook(bookVO); // 데이터베이스에 책 추가

                Console.Clear();
                adminModeUI.PrintAdminMenuMessage("도서추가");
                adminModeUI.PrintAddBookSuccess();

                while (Constants.isPROGRAM_ON)
                {
                    keyInput = Console.ReadKey(true); // ESC 뒤로가기
                    if (keyInput.Key == ConsoleKey.Escape)
                        return;
                }

            }
        }

        private void DeleteBook()
        {
            string name;
            string author;
            string publisher;

            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
                Console.SetCursorPosition(18, 1); // 커서이동

                name = validInput.EnterBookSearch(18, 1, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 영어,한글 1글자이상
                if (name == Constants.BACKMENU)
                    return;
                author = validInput.EnterBookSearch(19, 2, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 영어,한글 1글자 이상
                if (author == Constants.BACKMENU)
                    return;
                publisher = validInput.EnterBookSearch(18, 3, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // // 영어,한글  1글자 이상
                if (publisher == Constants.BACKMENU)
                    return;


                Console.Clear();
                adminModeUI.PrintAdminMenuMessage("삭제할 책 ID : ");
                libraryUI.ShowBookList(name, author, publisher); // 검색리스트 출력

              
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
    }
}
