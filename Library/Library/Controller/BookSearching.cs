using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BookSearching
    {
        
 
        string name;
        string author;
        string publisher;

        string bookId;
        public BookSearching()
        {
            name = null;
            author = null;
            publisher = null;
            
        }

        public void SearchBook() // 책 검색
        {
            Console.Clear();
            VariableData.UI.PrintSearchBook();
            VariableData.UI.PrintBookList(null,null,null); //  전체 북리스트 출력.
            Console.SetCursorPosition(18, 1); // 커서이동

            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                name = VariableData.validInput.EnterBookName(18,1); // 영어,한글 1글자이상
                author = VariableData.validInput.EnterAuthor(19,2); // 영어,한글 1글자 이상
                publisher = VariableData.validInput.EnterBookPublisher(18,3); // // 영어,한글, 숫자 1글자 이상

                Console.Clear();
                VariableData.UI.PrintSearchBook();
                VariableData.UI.PrintBookList(name, author, publisher);

                VariableData.keyInput = Console.ReadKey(true);
                if (VariableData.keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 
            }
        }

        public void BorrowBook() // 책 대여
        {
            Console.SetWindowSize(125, 60);

            Console.Clear();
            VariableData.UserModeUI.BorrowBook();
            VariableData.UI.PrintBookList(null, null, null); //  전체 북리스트 출력.
            Console.SetCursorPosition(35, 2); // 커서이동


            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
                bookId = VariableData.validInput.EnterBookId(35,2); // 책Id 1~999수

                for(int index = 0; index < LibraryStart.bookList.Count; index++)
                {
                    if(LibraryStart.bookList[index].Id == Convert.ToInt16(bookId)) // 책의 id가 같으면
                    {
                        if (LibraryStart.bookList[index].BookCount >= 1) ; // 책이 1개이상 있을때
                        {
                            LibraryStart.bookList[index].BookCount--; // 해당책의 보유양 1개 감소
                            BookVO.totalBook--;  //도서관에 있는 도서수 1개 감소
                        
                            LibraryStart.userList[VariableData.loginUser.SearchLoginUser()].RendtedBookId.Add(index);// Book의 index를 userList의 RentedBookid리스트에 추가

                            Console.SetCursorPosition(0, 0);
                            VariableData.UserModeUI.PrintSuccessRentBook();
                            VariableData.keyInput = Console.ReadKey(true);                      
                            return; // 뒤로가기 
                        }
                    }
                }
                Console.SetCursorPosition(0, 0);
                VariableData.UserModeUI.PrintFailRentBook();
                VariableData.keyInput = Console.ReadKey(true);
                return; // 뒤로가기 



            }
        }
        public void ReturnBook() // 책반납
        {
            Console.Clear();
            VariableData.UserModeUI.ReturnBook();
            VariableData.UserModeUI.PrintRentedBookList(VariableData.loginUser.SearchLoginUser());
            Console.SetCursorPosition(39, 2);


            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
                bookId = VariableData.validInput.EnterBookId(41,2);
               
                LibraryStart.userList[VariableData.loginUser.SearchLoginUser()].RendtedBookId.Remove(Convert.ToInt16(bookId)); // userlist에서 bookid와 같은 책을 가지고 있으면 삭제

                BookVO.totalBook++;  // 도서관 전체 책의 수 +1

                LibraryStart.bookList[Convert.ToInt16(bookId)].BookCount++; // 해당책의 보유양 1개 증가


                LibraryStart.userList[VariableData.loginUser.SearchLoginUser()].ReturnBookId.Add(Convert.ToInt16(bookId)); // 반납 책 id 저장
                LibraryStart.userList[VariableData.loginUser.SearchLoginUser()].ReturnBookTime.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // 반납 책 시간 저장


                Console.Clear();
                VariableData.UserModeUI.ReturnBookSuccess();
                VariableData.keyInput = Console.ReadKey(true);           
                return; // 뒤로가기 

            }
        }
        public void ConfirmRentedBook() //현재 로그인한 사람의 대여목록 출력
        {
            Console.Clear();
            Console.SetWindowSize(125, 60);


            VariableData.UserModeUI.PrintRentedBookList(VariableData.loginUser.SearchLoginUser());
            VariableData.keyInput = Console.ReadKey(true);        
            return; // 뒤로가기 

        }

        public void ConfirmReturnBook() // 반납한 시간, 책 출력
        {
            Console.Clear();
            Console.SetWindowSize(125, 60);


            VariableData.UserModeUI.PrintReturnBookTime();

            VariableData.keyInput = Console.ReadKey(true);
     
            return; // 뒤로가기 


        }
        
         





    }
}
