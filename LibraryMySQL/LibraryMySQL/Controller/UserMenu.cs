using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class UserMenu
    {
        ConsoleKeyInfo keyInput;
        SelectionMode mode;
        LibraryUI UI;
        UserModeUI userModeUI;

        BookSearching book;
        LoginedUser loginedUser;
        ValidInput validInput;


        int userid;
        bool delete;
        int menuNumber;
        public UserMenu(LibraryUI UI ,SelectionMode mode, UserModeUI userModeUI)
        {
            this.UI = UI;  
            this.userModeUI = userModeUI;
            this.mode = mode;
            validInput = new ValidInput(userModeUI);
            loginedUser = new LoginedUser();
            book = new BookSearching(validInput,UI);

        }

        public void StartUserMenu()
        {
             UI.PrintMainUI();
            Console.SetWindowSize(125, 40);

           
            while (Constants.PROGRAM_ON)
            {
                menuNumber =  mode.SelectUserOrManagerMenu("User",7); // 유저메뉴 위아래 화살표로 선택하기

                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: // 도서찾기                    
                         book.SearchBook();
                        break;
                    case Constants.BOOK_RENT: // 도서대여
                         book.BorrowBook();
                        break;
                    case Constants.BOOK_BORROW_LIST: //대여도서확인
                         book.ConfirmRentedBook();
                        break;
                    case Constants.BOOK_RETURN: // 도서 반납
                         book.ReturnBook();
                        break;
                    case Constants.BOOK_RETRUN_HISTORY:
                         book.ConfirmReturnBook(); // 도서반납확인
                        break;
                    case Constants.USER_EDIT: // 회원정보 수정
                        EditUserData();
                        break;
                    case Constants.DELETE: // 계정삭제
                        delete=DeleteUserId();
                        if (delete)
                            return;
                        break;
                    case Constants.EXIT:
                        return;
                    default:
                        return;


                }

            }
        }

        public void EditUserData()
        {
            Console.Clear();
            userModeUI.PrintUserDateEdit();
            userModeUI.PrintUserData(loginedUser.SearchLoginUser());


             keyInput = Console.ReadKey(true);
            if ( keyInput.Key == ConsoleKey.Escape)
                return; // 뒤로가기 
            else
            {            
               
                InputVO.id =  validInput.EnterId(38, 21);
                InputVO.password =  validInput.EnterIdOrPassword(38,22);
                InputVO.repassword =  validInput.EnterRepassword(InputVO.password, 38,23);
                InputVO.name =  validInput.EnterUserName(41,24);
                InputVO.age =  validInput.EnterUserAge(39,25);
                InputVO.phoneNumber =  validInput.EnterUserPhoneNumber(41,26);
                InputVO.address =  validInput.EnterUserAddress(39,27);
                userid = loginedUser.SearchLoginUser();
                LibraryStart.userList[userid].Id = InputVO.id;
                LibraryStart.userList[userid].Password = InputVO.password;
                LibraryStart.userList[userid].Name = InputVO.name;
                LibraryStart.userList[userid].Age = InputVO.age;
                LibraryStart.userList[userid].PhoneNumber = InputVO.phoneNumber;
                LibraryStart.userList[userid].Address = InputVO.address;

                userModeUI.PrintSuccessEditUserData();                     
                return; // 뒤로가기 
            }
           
        }
        public bool DeleteUserId()
        {
            Console.Clear();
            userModeUI.PrintDeleteUserId();

             keyInput = Console.ReadKey(true);
            if ( keyInput.Key == ConsoleKey.Escape)
                return false; // 뒤로가기 
            else if ( keyInput.Key == ConsoleKey.Enter) {

                LibraryStart.userList.RemoveAt(loginedUser.SearchLoginUser()); // 로그인한 유저 삭제

                userModeUI.PrintDeleteUserIdSuccess();

                     
                return true; // 뒤로가기 
            }
            return DeleteUserId();
        }
      

    }
}