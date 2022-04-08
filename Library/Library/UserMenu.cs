using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserMenu
    {
        const bool PROGRAM_ON = true;
        const int BOOK_SEARCH = 1;
        const int BOOK_RENT = 2;
        const int BOOK_BORROW_LIST = 3;
        const int BOOK_RETURN = 4;
        const int BOOK_RETRUN_HISTORY =5;
        const int USER_EDIT = 6;
        const int DELETE = 7;
        const int EXIT = -1;
        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        BookListAndSearch book = new BookListAndSearch();
        ValidInput validInput = new ValidInput();
        LoginUser loginUser = new LoginUser();
        string id;
        string password;
        string repassword;
        string name;
        string age;
        string phonenumber;
        string address;
        int userid;
        bool delete;
        int menuNumber;
        ConsoleKeyInfo keyInput;

        public void StartUserMenu()
        {
            UI.PrintMainUI();
            Console.SetWindowSize(125, 40);

            UI.PrintUserMenuUI(1);
            while (PROGRAM_ON)
            {
                menuNumber = mode.SelectUserMenu();// 도서찾기, 도서대여,대여도서확인,회원정보수정

                switch (menuNumber)
                {
                    case BOOK_SEARCH: // 도서찾기                    
                        book.SearchBook();
                        break;
                    case BOOK_RENT: // 도서대여
                        book.BorrowBook();
                        break;
                    case BOOK_BORROW_LIST: //대여도서확인
                        book.ConfirmRentedBook();
                        break;
                    case BOOK_RETURN: // 도서 반납
                        book.ReturnBook();
                        break;
                    case BOOK_RETRUN_HISTORY:
                        book.ConfirmReturnBook(); // 도서반납확인
                        break;
                    case USER_EDIT: // 회원정보 수정
                        EditUserData();
                        break;
                    case DELETE: // 계정삭제
                        delete=DeleteUserId();
                        if (delete)
                            return;
                        break;
                    case EXIT:
                        return;
                    default:
                        return;


                }

            }
        }

        public void EditUserData()
        {
            Console.Clear();
            UI.PrintUserDateEdit();
            UI.PrintUserData(loginUser.SearchLoginUser());


            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return; // 뒤로가기 
            else
            {            
                id = validInput.EnterId(38, 21);
                password = validInput.EnterIdOrPassword(38,22);
                repassword = validInput.EnterRepassword(password, 38,23);
                name = validInput.EnterUserName(41,24);
                age = validInput.EnterUserAge(39,25);
                phonenumber = validInput.EnterUserPhoneNumber(41,26);
                address = validInput.EnterUserAddress(38,27);

                userid = loginUser.SearchLoginUser();

                LibraryStart.userList[userid].Id = id;
                LibraryStart.userList[userid].Password = password;
                LibraryStart.userList[userid].Name = name;
                LibraryStart.userList[userid].Age =age;
                LibraryStart.userList[userid].PhoneNumber = phonenumber;
                LibraryStart.userList[userid].Address = address;

                UI.PrintSuccessEditUserData();

                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Enter)
                    return; // 뒤로가기 
            }
           
        }
        public bool DeleteUserId()
        {
            Console.Clear();
            UI.PrintDeleteUserId();

            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return false; // 뒤로가기 
            else if (keyInput.Key == ConsoleKey.Enter) {

                LibraryStart.userList.RemoveAt(loginUser.SearchLoginUser()); // 로그인한 유저 삭제

                UI.PrintDeleteUserIdSuccess();

                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Enter)
                    return true; // 뒤로가기 
            }
            return false;
        }
      

    }
}