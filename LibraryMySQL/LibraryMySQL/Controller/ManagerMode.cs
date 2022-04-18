using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class ManagerMode
    {

   

        int menuNumber;
        public void StartManagerMode()
        {
            VariableData.UI.PrintMainUI();
            Console.SetWindowSize(125, 60);



            VariableData.UI.PrintManagerMenuUI(1);
            while (Const.PROGRAM_ON)
            {
                menuNumber = VariableData.mode.SelectUserOrManagerMenu("Manager",6);// 위아래 화살표 입력
                
                switch (menuNumber)
                {
                    case Const.BOOK_REGISTRATION: // 도서 검색
                        VariableData.book.SearchBook();                  
                        break;
                    case Const.BOOK_UPDATE: // 도서 수량 수정
                        EditBookCount();
                        break;
                    case Const.BOOK_DELETE: //도서 삭제
                        DeleteBook();
                        break;
                    case Const.BOOK_SEARCH: // 도서 등록
                        RegisterBook();
                        break;
                    case Const.BOOK_LIST: // 도서 출력                     
                        ShowBookList();
                        break;  
                    case Const.USER_LIST: // 유저리스트
                        ShowUserList();
                        break;
                    case Const.EXIT:
                        return;
                    default:
                        return;


                }

            }
        }

        
        public void ShowBookList()
        {
           

            Console.Clear();
            VariableData.UI.PrintBookList();
            VariableData.UI.PrintBookList(null, null, null);

            VariableData.keyInput = Console.ReadKey(true);
            return;  // 아무키 입력시 뒤로가기
        }

        public void RegisterBook() //책등록
        {
            Console.Clear();
            VariableData.ManagerUI.PrintRegisterBook();


            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                InputVO.name = VariableData.validInput.EnterBookName(37,8);  //책 이름
                InputVO.author = VariableData.validInput.EnterAuthor(29,9); // 책 저자
                InputVO.publisher = VariableData.validInput.EnterBookPublisher(34,10); // 책 출판사
                InputVO.bookCount = Convert.ToInt16(VariableData.validInput.EnterBookCount(17,11)); // 책 수량
                InputVO.price = Convert.ToInt16(VariableData.validInput.EnterBookPrice(20,12)); // 가격
                InputVO.date = VariableData.validInput.EnterBookDate(23, 13); // 출시날짜


                // 책 등록

                VariableData.bookVO = new BookVO(BookVO.totalBook, InputVO.name, InputVO.author, InputVO.publisher, InputVO.bookCount, InputVO.price, InputVO.date);             
                LibraryStart.bookList.Add(VariableData.bookVO); // 책 리스트에 책 추가

                // 등록완료 UI
                Console.Clear();
                VariableData.ManagerUI.PrintRegisterBookSuccess();
                Thread.Sleep(1000);         
              
                return; // 아무키누르면 뒤로나감

            }              
        }
        public void EditBookCount() // 책의 수량을 설정
        {

            Console.Clear();
            Console.SetWindowSize(125, 60);

            VariableData.ManagerUI.PrintEditBookCount(); // 책수량 선택 UI

            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
                InputVO.bookId = Convert.ToInt16(VariableData.validInput.EnterBookId(17, 8)); // 책 id
                InputVO.bookCount = Convert.ToInt16(VariableData.validInput.EnterBookCount(19, 9)); // 책 수량

              
                for (int index = 0; index < LibraryStart.bookList.Count; index++) // 책 id가 같은것을 찾아서 책의 수를 변경
                {
                    if (InputVO.bookId == LibraryStart.bookList[index].Id)
                    {
                        LibraryStart.bookList[index].BookCount = InputVO.bookCount;
                        Console.Clear();
                        VariableData.ManagerUI.PrintEditBookCountSuccess();// 책 수량 변경 완료 UI
                        Thread.Sleep(1000);                                      // 
                        return;
                    }
                }
                Console.Clear();
                if (InputVO.bookId > LibraryStart.bookList.Count - 1)
                    VariableData.ManagerUI.PrintEditBookCountIDFail();
                
                else
                    VariableData.ManagerUI.PrintEditBookCountFail();

                Thread.Sleep(1000);
                return;



            }
          
        }
       

        public void DeleteBook() // 책 삭제
        {
            Console.Clear();
            Console.SetWindowSize(125, 60);

            VariableData.ManagerUI.PrintDeleteBook(); // 책 삭제 UI

            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                InputVO.bookId = Convert.ToInt16(VariableData.validInput.EnterBookId(17, 8)); // 책 id
                InputVO.bookCount = Convert.ToInt16(VariableData.validInput.EnterBookCount(18, 9)); // 책 수량

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
                            VariableData.ManagerUI.PrintDeleteBookSuccess(); // 책 삭제 완료 UI
                            Thread.Sleep(1000);
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            VariableData.ManagerUI.PrintEditBookCountFail(); // 삭제하려는 책의 수량이 더 커서 삭제실패
                            Thread.Sleep(1000);
                            return;
                            
                        }
                    }
                    
                }
                Console.Clear();
                VariableData.ManagerUI.PrintEditBookCountIDFail(); // 책의 id가 존재하지않아 삭제실패
                Thread.Sleep(1000);
                return;

            }

        }

        public void ShowUserList()
        {
            Console.Clear();
            VariableData.ManagerUI.PrintUserList();
            VariableData.keyInput = Console.ReadKey(true);
            return;
        

        }
    }
}
