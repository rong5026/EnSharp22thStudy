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
            bookSearching = new BookSearching(validInput, libraryUI, userModeUI);        
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

                menuNumber = mode.SelectUserManagerMenu("Admin", 6); //메뉴선택

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
                        EditBook();
                        Console.Clear();
                        break;
                    case Constants.USER_CARE: // 회원관리
                        ControlUsers();
                        Console.Clear();
                        break;
                    case Constants.TOTAL_USER_RENTBOOK: // 대여상황보기
                        ShowTotalRentUser();
                        Console.Clear();
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

            
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                adminModeUI.PrintAdminMenuMessage("도서추가","확인");
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
                adminModeUI.PrintAdminMenuMessage("도서추가","다시추가");
                adminModeUI.PrintAddBookSuccess();
                Console.CursorVisible = Constants.isNONVISIBLE;

                while (Constants.isPROGRAM_ON)
                {
                    keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                    if (keyInput.Key == ConsoleKey.Escape)
                        return;
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }

            }
        }

        private void DeleteBook() // 책 삭제
        {
            string name;
            string author;
            string publisher;
            string bookId;
            List<BookVO> bookList;
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                bookList = mySQlData.CheckBookList();
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, bookList); //  전체 북리스트 출력.
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
                adminModeUI.PrintAdminMenuMessage("삭제할 책 ID :","확인");
               
                libraryUI.ShowBookList(name, author, publisher, bookList); // 검색한 책 리스트 출력

                bookId = validInput.EnterDeleteBookID(73, 3, ErrorMessage.BOOK_ID, RegularExpression.BOOK_ID);// 삭제할 책 ID 입력
                if (bookId == Constants.INPUT_BACK)
                    break;

                mySQlData.DeleteBook(Convert.ToInt32(bookId)); // 데이터베이스에서 책 삭제
                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("책 삭제 완료!","다시삭제");
                Console.CursorVisible = Constants.isNONVISIBLE;

                while (Constants.isPROGRAM_ON)
                {
                    keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                    if (keyInput.Key == ConsoleKey.Escape)
                        return;
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }

            }
        }

        private void EditBook() // 책 수정
        {
            string name;
            string author;
            string publisher;
            string bookId;
            List<BookVO> bookList;
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                bookList = mySQlData.CheckBookList();
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, bookList); //  전체 북리스트 출력.
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
                adminModeUI.PrintAdminMenuMessage("수정할 책 ID :", "확인");
                libraryUI.ShowBookList(name, author, publisher, bookList); // 검색한 책 리스트 출력

                bookId = validInput.EnterDeleteBookID(73, 3, ErrorMessage.BOOK_ID, RegularExpression.BOOK_ID);// 삭제할 책 ID 입력
                if (bookId == Constants.INPUT_BACK)
                    break;


                Console.Clear();               
                SelectEditBookUnit(Convert.ToInt32( bookId));

            }
        }
        private void SelectEditBookUnit(int bookId) // 수정하고자하는 책 옵션 선택
        {
            int menuNumber;
            string name;
            string author;
            string publisher;
            string count;
            string price;
            string date;

            BookVO bookVO = new BookVO();

            Console.Clear();

            mySQlData.CheckSelectedBook(bookVO, bookId); // 수정하고자하는 책 정보 가져옮
            name = bookVO.Name;
            author = bookVO.Author;
            publisher = bookVO.Publisher;
            count = Convert.ToString(bookVO.BookCount);
            price = Convert.ToString(bookVO.Price);
            date = bookVO.Date;

            while (Constants.isPROGRAM_ON)
            {
                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("책 수정", "확인");
                mySQlData.CheckSelectedBook(bookVO, bookId); // 수정하고자하는 책 정보 가져옮
                adminModeUI.PrintRegisteredBook(bookVO); // 기존 책정보 프린트

                

                menuNumber = mode.SelectUserManagerMenu("BookEdit", 7);

                switch (menuNumber)
                {
                    case Constants.BOOK_NAME: // 책 이름                  
                        name = validInput.EnterBookName(72, 27);
                        if (name == Constants.INPUT_BACK)
                            name = bookVO.Name;
                        break;
                    case Constants.BOOK_AUTHOR: // 책 저자
                        author = validInput.EnterInput(72, 28, ErrorMessage.BOOK_AUTHOR, RegularExpression.BOOK_AUTHOR);
                        if (author == Constants.INPUT_BACK)
                            author = bookVO.Author;
                        break;
                    case Constants.BOOK_PUBLISHER: // 출판사
                        publisher = validInput.EnterInput(72, 29, ErrorMessage.BOOK_PUBISHER, RegularExpression.BOOK_PUBISHER);
                        if(publisher == Constants.INPUT_BACK)
                            publisher = bookVO.Publisher;
                        break;
                    case Constants.BOOK_COUNT: // 책 수량
                        count = validInput.EnterInput(72, 30, ErrorMessage.BOOK_COUNT, RegularExpression.BOOK_COUNT);
                        if (count == Constants.INPUT_BACK)
                            count = Convert.ToString(bookVO.BookCount);
                        break;
                    case Constants.BOOK_PRICE: // 책 가격
                        price = validInput.EnterInput(72, 31, ErrorMessage.BOOK_PRICE, RegularExpression.BOOK_PRICE);
                        if (price == Constants.INPUT_BACK)
                            price = Convert.ToString(bookVO.Price);
                        break;
                    case Constants.BOOK_DATE: // 출판날짜
                        date = validInput.EnterInput(72, 32, ErrorMessage.BOOK_DATE, RegularExpression.BOOK_DATE);
                        if (date == Constants.INPUT_BACK)
                            date = bookVO.Date;
                        break;
                    case Constants.EDIT: // 변경하기 버튼                                         
                        mySQlData.UpdateBookDate(name, author, publisher, Convert.ToInt32(count), Convert.ToInt32(price), date, bookId);
                        Console.Clear();
                        break;
                    case Constants.EXIT:
                        return;
                    default:
                        return;


                }


            }
        }
        private void ShowTotalRentUser() // 대여상황
        {
            List<UserVO> userList = new List<UserVO>();
            List<BookVO> bookList = new List<BookVO>();

            Console.Clear();
            mySQlData.SendUserList(userList); // 유저들 리스트 
            adminModeUI.PrintAdminMenuMessage("전체회원 대여상황", "확인");

            for(int index = 0; index < userList.Count; index++)
            {
                adminModeUI.PrintUserName(userList[index].Id); // 유저ID 출력
                mySQlData.CheckRentBook(bookList, userList[index].Id);  // 유저가 빌린 책 리스트 
                libraryUI.ShowBorrowedBookList(bookList, "빌린");

            }
            Console.SetCursorPosition(0, 0);

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                if (keyInput.Key == ConsoleKey.Escape)
                    return;
               
            }

        }
        private void ControlUsers() // 회원관리
        {
            string id;
            
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                List<UserVO> userList = new List<UserVO>();
                mySQlData.SendUserList(userList); // 유저들 리스트 

                adminModeUI.PrintAdminMenuMessage("삭제할 유저ID 입력 :", "확인");

                for (int index = 0; index < userList.Count; index++)
                {
                    adminModeUI.PrintUserData(userList[index]);
                }

                id = validInput.EnterDeleteUserID(79, 3, ErrorMessage.USER_NOT_EXIST, RegularExpression.USER_NOT_EXIST);
                if (id == Constants.INPUT_BACK)
                    break;

                mySQlData.DeleteUserID(id);

                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("ID삭제완료!", "다른 ID 지우기");
                while (Constants.isPROGRAM_ON)
                {
                  
                    keyInput = Console.ReadKey(Constants.KEY_INPUT);
                    if (keyInput.Key == ConsoleKey.Escape)
                        return;
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }
            }

        }
    }
}
