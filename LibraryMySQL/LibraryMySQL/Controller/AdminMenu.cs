using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
        BookDAO mySQlData;
        Login login;
        NaverSearching naver;
        UserDAO userDAO;
        ConsoleKeyInfo keyInput;

        public AdminMenu(ValidInput validInput, UserModeUI userModeUI)
        {
            this.validInput = validInput;
            this.userModeUI = userModeUI;
            libraryUI = new LibraryUI();
            adminModeUI = new AdminModeUI();
            bookSearching = new BookSearching(validInput, libraryUI, userModeUI);        
            mode = new SelectionMode(libraryUI);
            mySQlData = BookDAO.Instance();
            login = new Login(userModeUI, validInput);
            naver = new NaverSearching();
            userDAO= new UserDAO();
        }

        public void StartAdminMode() // 관리자 모드 시작
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
        public void StartAdminMenu() // 관리자 메뉴
        {
            int menuNumber;

            libraryUI.PrintMainUI();
            while (Constants.isPROGRAM_ON)
            {

                menuNumber = mode.SelectUserManagerMenu("Admin", 8); //메뉴선택

                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: //도서찾기                  
                        bookSearching.SearchBook();
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", "관리자", "도서찾기"); // 로그저장
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
                    case Constants.NAVER_SEARCHING: // 네이버 검색
                        naver.SearchInNaver("AddAdminBook");
                        Console.Clear();
                        break;
                    case Constants.LOG: // 로그관리
                        ControlLog();
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
            string isbn;
            string information;
            BookDTO bookVO;

            
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                adminModeUI.PrintAdminMenuMessage("                       도서추가", "확인");
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

                isbn = validInput.EnterInput(44, 21, ErrorMessage.BOOK_ISBN, RegularExpression.BOOK_ISBN); // 책 isbn
                if (isbn == Constants.INPUT_BACK)
                    break;
                information = validInput.EnterInput(44, 22, ErrorMessage.BOOK_INFORMATION, RegularExpression.BOOK_INFORMATION); // 책 정보
                if (information == Constants.INPUT_BACK)
                    break;

                bookVO =new BookDTO(0, name, author, publisher, Convert.ToInt16(count), Convert.ToInt32(price), date,null,null, isbn, information);
             


                mySQlData.InsertBook(bookVO); // 데이터베이스에 책 추가
                mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", name, "도서추가"); // 로그저장
                Console.Clear();
                adminModeUI.PrintAdminMenuMessage("                      추가완료!", "다시추가");
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
            List<int> bookIndex;
            List<BookDTO> bookList;
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                bookList = mySQlData.GetBookList();
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, bookList); //  전체 북리스트 출력.
                Console.SetCursorPosition(18, 1); // 커서이동


                // 책이름, 저자, 출판사 입력
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
                adminModeUI.PrintAdminMenuMessage("                      삭제할 책 ID :", "확인");

                bookIndex =libraryUI.ShowBookList(name, author, publisher, bookList); // 검색한 책 리스트 출력

                bookId = validInput.EnterDeleteBookID(73, 3, ErrorMessage.BOOK_ID, RegularExpression.BOOK_ID,bookIndex,bookList);// 삭제할 책 ID 입력
                if (bookId == Constants.INPUT_BACK)
                    break;

                mySQlData.DeleteBook(Convert.ToInt32(bookId)); // 데이터베이스에서 책 삭제
                mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", bookId, "도서삭제"); // 로그저장

                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("                      책 삭제 완료!           ", "다시삭제");
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
            List<int> bookIndex;
            List<BookDTO> bookList;
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                bookList = mySQlData.GetBookList();
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
                adminModeUI.PrintAdminMenuMessage("                     수정할 책 ID :", "확인");
                bookIndex = libraryUI.ShowBookList(name, author, publisher, bookList); // 검색한 책 리스트 출력

                bookId = validInput.EnterDeleteBookID(73, 3, ErrorMessage.BOOK_ID, RegularExpression.BOOK_ID, bookIndex, bookList);// 수정할 책 ID 입력            
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

            BookDTO bookVO;

            Console.Clear();

            bookVO = mySQlData.GetSelectedBook(bookId); // 수정하고자하는 책 정보 가져옮
            name = bookVO.Name;
            author = bookVO.Author;
            publisher = bookVO.Publisher;
            count = Convert.ToString(bookVO.BookCount);
            price = Convert.ToString(bookVO.Price);
            date = bookVO.Date;

            while (Constants.isPROGRAM_ON)
            {
                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("                         책 수정", "확인");
                bookVO = mySQlData.GetSelectedBook(bookId); // 수정하고자하는 책 정보 가져옮
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
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", name, "도서수정"); // 로그저장
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
            List<UserDTO> userList = new List<UserDTO>();
            List<BookDTO> bookList = new List<BookDTO>();

            Console.Clear();
            userDAO.GetUserList(userList); // 유저들 리스트 
            adminModeUI.PrintAdminMenuMessage("                    전체회원 대여상황", "확인");

            for(int index = 0; index < userList.Count; index++)
            {
                adminModeUI.PrintUserName(userList[index].Id); // 유저ID 출력
                mySQlData.GetRentBook(bookList, userList[index].Id);  // 유저가 빌린 책 리스트 
                libraryUI.ShowBorrowedBookList(bookList, "빌린");

            }
            Console.SetCursorPosition(0, 0);
            mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", "관리자", "대여상황"); // 로그저장
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
                List<UserDTO> userList = new List<UserDTO>();
                userDAO.GetUserList(userList); // 유저들 리스트 
              
                adminModeUI.PrintAdminMenuMessage("              삭제할 유저Number 입력 :", "확인");

                for (int index = 0; index < userList.Count; index++)
                {
                    adminModeUI.PrintUserData(userList[index]);
                }
                Console.SetCursorPosition(0, 0);

                id = validInput.EnterDeleteUserID(77, 3, ErrorMessage.USER_NOT_EXIST, RegularExpression.USER_NUMBER_NOT_EXIST);  // 삭제할 유저 Number입력
                if (id == Constants.INPUT_BACK)
                    break;

                userDAO.DeleteUserNumber(id);


                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("                     ID삭제완료!                 ", "다른ID지우기");
                mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", id, "회원삭제"); // 로그저장
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
        private void ControlLog() // 로그관리
        {
            int menuNumber;
            Console.Clear();
            libraryUI.PrintMainUI();

            while (Constants.isPROGRAM_ON)
            {

                menuNumber = mode.SelectUserManagerMenu("Log", Constants.LOG_MENU_COUNT); //메뉴선택

                switch (menuNumber)
                {
                    case Constants.LOG_EDIT: //로그수정            
                        EditLog();
                        Console.Clear();
                        break;
                    case Constants.LOG_SAVE_FILE: // 로그파일저장             
                        SaveLog();
                        Console.Clear();
                        break;
                    case Constants.LOG_DELETE_FILE: //로그파일삭제        
                        DeleteLogFile();
                        Console.Clear();
                        break;
                    case Constants.LOG_RESET: // 로그초기화               
                        ResetLogData();
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
        private void DeleteLogFile() // 로그텍스트파일 삭제
        {
            Console.Clear();

            adminModeUI.PrintAdminMenuMessage("                   로그 텍스트파일 삭제", "삭제하기");

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                if (keyInput.Key == ConsoleKey.Escape)
                    return;
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Library로그기록.txt";
                    if (File.Exists(path))
                    {
                        File.Delete(path); // 로그파일 삭제
                        Console.SetCursorPosition(0, 0);
                        adminModeUI.PrintAdminMenuMessage("                로그파일이 삭제되었습니다", "확인하기");
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", "Librart로그기록.txt ", "로그파일삭제"); // 로그저장
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        adminModeUI.PrintAdminMenuMessage("            삭제할 파일이 존재하지 않습니다", "확인하기"); // 로그파일 삭제 실패
                    }
                    while (Constants.isPROGRAM_ON)
                    {
                        keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                        if (keyInput.Key == ConsoleKey.Escape)
                            return;

                    }
                }
            }
        }
        private void SaveLog() // 로그 text파일로 저장
        {
            List<LogDTO> list;
            string log = "";
            Console.Clear();


            adminModeUI.PrintAdminMenuMessage("                text파일에 저장하시겠습니까?", "저장하기");

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                if (keyInput.Key == ConsoleKey.Escape)
                    return;
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    list = mySQlData.GetLogList(); //로그데이터 가져옴

                    for (int index = 0; index < list.Count; index++)
                    {
                        log += "순서: " + list[index].Id.ToString() + " / 시간: " + list[index].Time + " / 사용자 :" + list[index].User + " / 내용 :" + list[index].Information + " / 명령 :" + list[index].Action + "\n";
                    }
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Library로그기록.txt", log); // 로그text파일 생성

                    Console.SetCursorPosition(0, 0);
                    adminModeUI.PrintAdminMenuMessage("                로그파일로 저장되었습니다", "확인하기");
                    mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", "Librart로그기록.txt ", "로그파일저장"); // 로그저장
                    while (Constants.isPROGRAM_ON)
                    {
                        keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                        if (keyInput.Key == ConsoleKey.Escape)
                            return;

                    }
                }
            }
        }
        private void EditLog() // 로그수정
        {
            string logId;


            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();

                adminModeUI.PrintAdminMenuMessage("                삭제하려는 로그ID :", "확인하기");
                List<LogDTO> list = mySQlData.GetLogList(); // 전체 로그 가져옴


                adminModeUI.PrintLogData(list);// 전체로그 출력

                logId = validInput.EnterLogId(73, 3, ErrorMessage.LOG_ID, RegularExpression.LOG_ID); // 수정할 로그 Id입력

                if (logId == Constants.INPUT_BACK)
                    return;

                mySQlData.DeleteLogData(Convert.ToInt32(logId)); // 로그정보 삭제
                mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", logId, "로그삭제"); // 로그저장

                Console.SetCursorPosition(0, 0);
                adminModeUI.PrintAdminMenuMessage("                     로그 삭제 완료!                          ", "다시삭제");
                mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", logId, "선택로그삭제"); // 로그저장

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

        private void ResetLogData() // 모든 로그정보 삭제
        {
            Console.Clear();

            adminModeUI.PrintAdminMenuMessage("                로그를 초기화 시키겠습니까?", "초기화하기");

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                if (keyInput.Key == ConsoleKey.Escape)
                    return;
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    mySQlData.DeleteALlLog();
                    Console.SetCursorPosition(0, 0);
                    adminModeUI.PrintAdminMenuMessage("                로그정보가 초기화되었습니다", "확인하기");
                    mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", "초기화", "로그초기화"); // 로그저장
                    while (Constants.isPROGRAM_ON)
                    {
                        keyInput = Console.ReadKey(Constants.KEY_INPUT); // ESC 뒤로가기
                        if (keyInput.Key == ConsoleKey.Escape)
                            return;

                    }
                }
            }

        }
    }
}
