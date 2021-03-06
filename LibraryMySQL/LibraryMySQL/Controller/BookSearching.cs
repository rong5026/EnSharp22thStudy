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
        BookDAO mySQlData;
        UserModeUI userModeUI;
        private string name;
        private string author;
        private string publisher;
        private string bookId;
        public BookSearching(ValidInput validInput, LibraryUI libraryUI,UserModeUI userModeUI)
        {
          
            this.validInput = validInput;
            this.libraryUI = libraryUI;
            this.userModeUI = userModeUI;
            mySQlData = BookDAO.Instance();
        }
        public void SearchBook() // 책 검색
        {
            List<BookDTO> bookList;
            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                bookList = mySQlData.GetBookList();
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, bookList); //  전체 북리스트 출력.
                Console.SetCursorPosition(18, 1); // 커서이동

                // 책 조건 입력
                name = validInput.EnterBookSearch(18, 1,ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 영어,한글 1글자이상
                if (name == Constants.BACKMENU)
                    return;
                author = validInput.EnterBookSearch(19, 2, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 영어,한글 1글자 이상
                if (author == Constants.BACKMENU)
                    return;
                publisher = validInput.EnterBookSearch(18, 3, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // // 영어,한글  1글자 이상
                if (publisher == Constants.BACKMENU)
                    return;


                Console.Clear();
                libraryUI.PrintSearchBook("Return");
                libraryUI.ShowBookList(name, author, publisher, bookList);

                Console.CursorVisible = Constants.isNONVISIBLE;
                while (Constants.isPROGRAM_ON)
                {
                    keyInput = Console.ReadKey(Constants.KEY_INPUT);
                    if (keyInput.Key == ConsoleKey.Escape)
                        return; // ESC 누르면 뒤로가기 
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }

            }


        }

        public int BorrowBook() // 책 대여
        {
            List<BookDTO> bookList;
            List<int> bookIndex;
            Console.SetWindowSize(125, 50);
            Console.SetCursorPosition(0, 0);
      
            while (Constants.isPROGRAM_ON)
            {

                Console.Clear();
                libraryUI.PrintSearchBook("Start");
                bookList = mySQlData.GetBookList();
                libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, bookList); //  전체 북리스트 출력.
                Console.SetCursorPosition(18, 1); // 커서이동


                // 책이름, 저자, 출판사 검색
                name = validInput.EnterBookSearch(18, 1, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 영어,한글 1글자이상
                if (name == Constants.BACKMENU)
                    return Constants.BACK;
                author = validInput.EnterBookSearch(19, 2, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 영어,한글 1글자 이상
                if (author == Constants.BACKMENU)
                    return Constants.BACK;
                publisher = validInput.EnterBookSearch(18, 3, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // // 영어,한글  1글자 이상
                if (publisher == Constants.BACKMENU)
                    return Constants.BACK;


                //빌릴책 입력
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                userModeUI.PrintReturnRentBook("빌릴", "입력하기");
                bookIndex = libraryUI.ShowBookList(name, author, publisher, bookList); // 검색한 책 리스트 출력
     
                bookId = validInput.EnterDeleteBookID(35, 2,ErrorMessage.BOOK_ID, RegularExpression.BOOK_ID,bookIndex,bookList); // 책Id 1~999수

                if (bookId == Constants.INPUT_BACK)//ESC 누르면 뒤로가기
                    return Constants.BACK;

                for(int index = 0; index < bookList.Count; index++)
                {
                    if(bookList[index].Id == Convert.ToInt16(bookId)  &&  mySQlData.ConfrimUserRentBook(Convert.ToInt16(bookId))== Constants.BOOK_NOT_EXIST )// 책의 id가 같을때, 이미 빌린책이 아닐때
                    {
                        if (bookList[index].BookCount >= 1)// 책이 1개 이상있을때
                        {
                            // 책 수량1개감소 
                            mySQlData.UpdateBookCount(bookList[index].BookCount - 1, bookList[index].Id);   
                            // 빌린 유저에 책정보 저장
                            mySQlData.InsertRentBook(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss"), bookList[index]);

                            //대여 성공 메시지 출력
                            Console.SetCursorPosition(0, 0);
                            Console.CursorVisible = Constants.isNONVISIBLE;
                            userModeUI.PrintBorrowBookMessage("책 빌리기 성공!","다시 입력하기");

                            mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LibraryStart.loginedUser, bookList[index].Name, "도서대여"); // 로그기록
                            if (EnterBack() == Constants.RESTART)
                                return BorrowBook();         
                               
                            return Constants.BACK;

                        }
                    }
                }
                // 책 빌리기 실패
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = Constants.isNONVISIBLE;
                userModeUI.PrintBorrowBookMessage("실패! 수량이 없거나 유효하지 않은 책 ID 또는 이미 빌린 책 입니다!","다시 입력하기");

                if (EnterBack() == Constants.RESTART)
                    return BorrowBook();

                return Constants.BACK;
            }

            return Constants.BACK;
        }
        public int ReturnBook()// 도서반납
        {
            List<BookDTO> bookList = new List<BookDTO>();

            Console.Clear();
            userModeUI.PrintReturnRentBook("반납","입력하기");
            mySQlData.GetRentBook(bookList,LibraryStart.loginedUser);
            libraryUI.ShowBorrowedBookList(bookList,"빌린");

            while (Constants.isPROGRAM_ON)
            {
                bookId = validInput.EnterInput(35, 2, ErrorMessage.BOOK_ID, RegularExpression.BOOK_ID); // 책Id 1~999수

                if (bookId == Constants.INPUT_BACK)//ESC 누르면 뒤로가기
                    return Constants.BACK;

                for (int index = 0; index < bookList.Count; index++)
                {
                    if (bookList[index].Id == Convert.ToInt16(bookId)) // 책의 id가 같을때
                    {
                        // 빌린책 목록에서 삭제
                        mySQlData.DeleteRentBook(Convert.ToInt16 (bookId));
                        // 도서관 책 수량 1개 증가
                        mySQlData.UpdateBookCount(mySQlData.GetBookCount(Convert.ToInt16(bookId))+1 , bookList[index].Id);
                        //반납 리스트에 추가
                        mySQlData.InsertReturnBook(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), bookList[index]);

                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LibraryStart.loginedUser, bookList[index].Name, "도서반납"); // 로그저장
                        //반납 성공 메시지 출력
                        Console.SetCursorPosition(0, 0);
                        Console.CursorVisible = Constants.isNONVISIBLE;
                        userModeUI.PrintBorrowBookMessage("책 반납 성공!","다시 입력하기");

                        if (EnterBack() == Constants.RESTART)
                            return ReturnBook();

                        return Constants.BACK;
                    }
                }
                // 책 빌리기 실패
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = Constants.isNONVISIBLE;
                userModeUI.PrintBorrowBookMessage("책 반납 실패! 대여하지 않은 책 ID 입니다!","다시 입력하기");

                if (EnterBack() == Constants.RESTART)
                    return ReturnBook();

                return Constants.BACK;
            }
        }

        private int EnterBack() // 다시 할지 뒤로갈지 선택
        {
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);

                if (keyInput.Key == ConsoleKey.Enter) // 다시하기                                               
                    return Constants.RESTART;
                
                else if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACK;

            }
        }
        public void ConfirmReturnAndRentBook(string type,string message) // 빌린, 반납책 확인
        {
            Console.Clear();
            userModeUI.PrintReturnRentBookList(type); // 빌린책 UI 출력

            List<BookDTO> list = new List<BookDTO>();

            mySQlData.GetRentBook(list, LibraryStart.loginedUser); //로그인된 사람의 빌린책

            libraryUI.ShowBorrowedBookList(list, type);

            mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "유저", LibraryStart.loginedUser, message); // 로그저장

            Console.SetCursorPosition(0, 0);
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기           
                    return;

            }
        }
     






    }

}
