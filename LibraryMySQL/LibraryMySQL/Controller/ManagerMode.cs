using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{
    internal class ManagerMode
    {

        LibraryUI UI = new LibraryUI();
        ConsoleKeyInfo keyInput;
        SelectionMode mode = new SelectionMode();
        BookSearching book = new BookSearching();
        ManagerModeUI ManagerUI = new ManagerModeUI();
        BookVO bookVO = new BookVO();
        ValidInput validInput = new ValidInput();
        int menuNumber;
        public void StartManagerMode()
        {
             UI.PrintMainUI();
            Console.SetWindowSize(125, 60);



             UI.PrintManagerMenuUI(1);
            while (Constants.PROGRAM_ON)
            {
                menuNumber =  mode.SelectUserOrManagerMenu("Manager",6);// 위아래 화살표 입력
                
                switch (menuNumber)
                {
                    case Constants.BOOK_REGISTRATION: // 도서 검색
                         book.SearchBook();                  
                        break;
                    case Constants.BOOK_UPDATE: // 도서 수량 수정
                        EditBookCount();
                        break;
                    case Constants.BOOK_DELETE: //도서 삭제
                        DeleteBook();
                        break;
                    case Constants.BOOK_SEARCH: // 도서 등록
                        RegisterBook();
                        break;
                    case Constants.BOOK_LIST: // 도서 출력                     
                        ShowBookList();
                        break;  
                    case Constants.USER_LIST: // 유저리스트
                        ShowUserList();
                        break;
                    case Constants.EXIT:
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
             ManagerUI.PrintRegisterBook();


             keyInput = Console.ReadKey(true);
            if ( keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                InputVO.name =  validInput.EnterBookName(37,8);  //책 이름
                InputVO.author =  validInput.EnterAuthor(29,9); // 책 저자
                InputVO.publisher =  validInput.EnterBookPublisher(34,10); // 책 출판사
                InputVO.bookCount = Convert.ToInt16( validInput.EnterBookCount(17,11)); // 책 수량
                InputVO.price = Convert.ToInt16( validInput.EnterBookPrice(20,12)); // 가격
                InputVO.date =  validInput.EnterBookDate(23, 13); // 출시날짜


                // 책 등록

                 bookVO = new BookVO(BookVO.totalBook, InputVO.name, InputVO.author, InputVO.publisher, InputVO.bookCount, InputVO.price, InputVO.date);             
                LibraryStart.bookList.Add( bookVO); // 책 리스트에 책 추가

                // 등록완료 UI
                Console.Clear();
                 ManagerUI.PrintRegisterBookSuccess();
                     
              
                return; // 아무키누르면 뒤로나감

            }              
        }
        public void EditBookCount() // 책의 수량을 설정
        {

            Console.Clear();
            Console.SetWindowSize(125, 60);

             ManagerUI.PrintEditBookCount(); // 책수량 선택 UI

             keyInput = Console.ReadKey(true);
            if ( keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
                InputVO.bookId = Convert.ToInt16( validInput.EnterBookId(17, 8)); // 책 id
                InputVO.bookCount = Convert.ToInt16( validInput.EnterBookCount(19, 9)); // 책 수량

              
                for (int index = 0; index < LibraryStart.bookList.Count; index++) // 책 id가 같은것을 찾아서 책의 수를 변경
                {
                    if (InputVO.bookId == LibraryStart.bookList[index].Id)
                    {
                        LibraryStart.bookList[index].BookCount = InputVO.bookCount;
                        Console.Clear();
                         ManagerUI.PrintEditBookCountSuccess();// 책 수량 변경 완                                // 
                        return;
                    }
                }
                Console.Clear();
                if (InputVO.bookId > LibraryStart.bookList.Count - 1)
                     ManagerUI.PrintEditBookCountIDFail();
                
                else
                     ManagerUI.PrintEditBookCountFail();

                
                return;



            }
          
        }
       

        public void DeleteBook() // 책 삭제
        {
            Console.Clear();
            Console.SetWindowSize(125, 60);

             ManagerUI.PrintDeleteBook(); // 책 삭제 UI

            if ( keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                InputVO.bookId = Convert.ToInt16( validInput.EnterBookId(17, 8)); // 책 id
                InputVO.bookCount = Convert.ToInt16( validInput.EnterBookCount(18, 9)); // 책 수량

                for (int index = 0; index < LibraryStart.bookList.Count; index++) // 
                {
                    if (InputVO.bookId == LibraryStart.bookList[index].Id)
                    {
                        if (LibraryStart.bookList[index].BookCount >= InputVO.bookCount) // 삭제하려는 책보다 수량이 많을때 
                        {
                            LibraryStart.bookList[index].BookCount -= InputVO.bookCount; // 책의 수량을 빼짐

                            if (LibraryStart.bookList[index].BookCount == 0) // 책 수량이 0이면 삭제
                            {
                                LibraryStart.bookList.RemoveAt(index);                              
                            }

                            Console.Clear();
                             ManagerUI.PrintDeleteBookSuccess(); // 책 삭제 완료 UI
                           
                            return;
                        }
                        else
                        {
                            Console.Clear();
                             ManagerUI.PrintEditBookCountFail(); // 삭제하려는 책의 수량이 더 커서 삭제실패
                           
                            return;
                            
                        }
                    }
                    
                }
                Console.Clear();
                 ManagerUI.PrintEditBookCountIDFail(); // 책의 id가 존재하지않아 삭제실패
              
                return;

            }

        }

        public void ShowUserList()
        {
            Console.Clear();
             ManagerUI.PrintUserList();
             keyInput = Console.ReadKey(true);
            return;
        

        }
    }
}
