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
            mySQlData = MySQlData.Instance();
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

        public int BorrowBook() // 책 대여
        {
            List<BookVO> bookList = new List<BookVO>();
   
            Console.SetWindowSize(125, 50);

            Console.Clear();
            userModeUI.PrintReturnRentBook("빌릴");
            libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
           

            mySQlData.CheckBookList(bookList); // 저장된 책 list받아옴

            while (Constants.isPROGRAM_ON)
            {
                bookId = validInput.EnterBookId(35, 2); // 책Id 1~999수

                if (bookId == Constants.INPUT_EMPTY)//ESC 누르면 뒤로가기
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
                            mySQlData.InsertRentBook(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), bookList[index]);

                            //대여 성공 메시지 출력
                            Console.SetCursorPosition(0, 0);
                            Console.CursorVisible = false;
                            userModeUI.PrintBorrowBookMessage("책 빌리기 성공!");

                            if (EnterBack() == Constants.RESTART)
                                return BorrowBook();         
                               
                            return Constants.BACK;

                        }
                    }
                }
                // 책 빌리기 실패
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                userModeUI.PrintBorrowBookMessage("실패! 수량이 없거나 유효하지 않은 책 ID 또는 이미 빌린 책 입니다!");

                if (EnterBack() == Constants.RESTART)
                    return BorrowBook();

                return Constants.BACK;
            }
        }
        public int ReturnBook()// 도서반납
        {
            List<BookVO> bookList = new List<BookVO>();

            Console.Clear();
            userModeUI.PrintReturnRentBook("반납");
            mySQlData.CheckRentBook(bookList);
            libraryUI.ShowBorrowedBookList(bookList,"반납책");

            while (Constants.isPROGRAM_ON)
            {
                bookId = validInput.EnterBookId(35, 2); // 책Id 1~999수

                if (bookId == Constants.INPUT_EMPTY)//ESC 누르면 뒤로가기
                    return Constants.BACK;

                for (int index = 0; index < bookList.Count; index++)
                {
                    if (bookList[index].Id == Convert.ToInt16(bookId)) // 책의 id가 같을때
                    {
                        // 빌린책 목록에서 삭제
                        mySQlData.DeleteRentBook(Convert.ToInt16 (bookId));
                        // 도서관 책 수량 1개 증가
                        mySQlData.UpdateBookCount(mySQlData.CheckBookCount(Convert.ToInt16(bookId))+1 , bookList[index].Id);
                        //반납 리스트에 추가
                        mySQlData.InsertReturnBook(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), bookList[index]);

                        //반납 성공 메시지 출력
                        Console.SetCursorPosition(0, 0);
                        Console.CursorVisible = false;
                        userModeUI.PrintBorrowBookMessage("책 반납 성공!");

                        if (EnterBack() == Constants.RESTART)
                            return ReturnBook();

                        return Constants.BACK;
                    }
                }
                // 책 빌리기 실패
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                userModeUI.PrintBorrowBookMessage("책 반납 실패! 대여하지 않은 책 ID 입니다!");

                if (EnterBack() == Constants.RESTART)
                    return ReturnBook();

                return Constants.BACK;
            }
        }

        private int EnterBack() // 반납다시 할지 뒤로갈지 선택
        {
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Enter) // 대여 다시하기
                {
                    Console.SetCursorPosition(0, 0);
                    userModeUI.PrintReturnRentBook("반납");
                    libraryUI.ShowBookList(Constants.INPUT_EMPTY, Constants.INPUT_EMPTY, Constants.INPUT_EMPTY); //  전체 북리스트 출력.
                    return Constants.RESTART;
                }
                else if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACK;

            }
        }

        public void ConfirmRentedBook() // 빌린책 확인
        {
            Console.Clear();
            userModeUI.PrintReturnRentBookList("빌린"); // 빌린책 UI 출력

            List<BookVO> list = new List<BookVO>();

            mySQlData.CheckRentBook(list); //로그인된 사람의 빌린책

            libraryUI.ShowBorrowedBookList(list,"빌린");
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기           
                    return;
                
            }
        }
        public void ConfirmReturnBook()  //반납책 확인
        {
            Console.Clear();
            userModeUI.PrintReturnRentBookList("반납"); // 반납책 UI 출력

            List<BookVO> list = new List<BookVO>();

            mySQlData.CheckReturnedBook(list); //로그인된 사람의 빌린책

            libraryUI.ShowBorrowedBookList(list,"반납");
            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기           
                    return;

            }
        }






    }

}
