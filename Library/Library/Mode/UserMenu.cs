using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserMenu
    {
        public UserMenu()
        {


        }
      
        /*
        LibraryUI UI = new LibraryUI();
        UserModeUI UserUI = new UserModeUI();
        SelectionMode mode = new SelectionMode();
        BookSearching book = new BookSearching();
        ValidInput validInput = new ValidInput();
        LoginedUser loginUser = new LoginedUser();
     */
        int userid;
        bool delete;
        int menuNumber;
        ConsoleKeyInfo keyInput;

        public void StartUserMenu()
        {
            VariableData.UI.PrintMainUI();
            Console.SetWindowSize(125, 40);

           // UI.PrintUserMenuUI(1);
            while (Const.PROGRAM_ON)
            {
                menuNumber = VariableData.mode.SelectUserOrManagerMenu("User",7); // 유저메뉴 위아래 화살표로 선택하기

                switch (menuNumber)
                {
                    case Const.BOOK_SEARCH: // 도서찾기                    
                        VariableData.book.SearchBook();
                        break;
                    case Const.BOOK_RENT: // 도서대여
                        VariableData.book.BorrowBook();
                        break;
                    case Const.BOOK_BORROW_LIST: //대여도서확인
                        VariableData.book.ConfirmRentedBook();
                        break;
                    case Const.BOOK_RETURN: // 도서 반납
                        VariableData.book.ReturnBook();
                        break;
                    case Const.BOOK_RETRUN_HISTORY:
                        VariableData.book.ConfirmReturnBook(); // 도서반납확인
                        break;
                    case Const.USER_EDIT: // 회원정보 수정
                        EditUserData();
                        break;
                    case Const.DELETE: // 계정삭제
                        delete=DeleteUserId();
                        if (delete)
                            return;
                        break;
                    case Const.EXIT:
                        return;
                    default:
                        return;


                }

            }
        }

        public void EditUserData()
        {
            Console.Clear();
            VariableData.UserUI.PrintUserDateEdit();
            VariableData.UserUI.PrintUserData(VariableData.loginUser.SearchLoginUser());


            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return; // 뒤로가기 
            else
            {            
               
                InputVO.id = VariableData.validInput.EnterId(38, 21);
                InputVO.password = VariableData.validInput.EnterIdOrPassword(38,22);
                InputVO.repassword = VariableData.validInput.EnterRepassword(InputVO.password, 38,23);
                InputVO.name = VariableData.validInput.EnterUserName(41,24);
                InputVO.age = VariableData.validInput.EnterUserAge(39,25);
                InputVO.phoneNumber = VariableData.validInput.EnterUserPhoneNumber(41,26);
                InputVO.address = VariableData.validInput.EnterUserAddress(39,27);
                userid = VariableData.loginUser.SearchLoginUser();
                LibraryStart.userList[userid].Id = InputVO.id;
                LibraryStart.userList[userid].Password = InputVO.password;
                LibraryStart.userList[userid].Name = InputVO.name;
                LibraryStart.userList[userid].Age = InputVO.age;
                LibraryStart.userList[userid].PhoneNumber = InputVO.phoneNumber;
                LibraryStart.userList[userid].Address = InputVO.address;

                VariableData.UserUI.PrintSuccessEditUserData();                     
                return; // 뒤로가기 
            }
           
        }
        public bool DeleteUserId()
        {
            Console.Clear();
            VariableData.UserUI.PrintDeleteUserId();

            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return false; // 뒤로가기 
            else if (keyInput.Key == ConsoleKey.Enter) {

                LibraryStart.userList.RemoveAt(VariableData.loginUser.SearchLoginUser()); // 로그인한 유저 삭제

                VariableData.UserUI.PrintDeleteUserIdSuccess();

                keyInput = Console.ReadKey(true);
              
                return true; // 뒤로가기 
            }
            return DeleteUserId();
        }
      

    }
}