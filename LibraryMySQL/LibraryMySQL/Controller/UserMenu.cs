using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class UserMenu
    {

        LibraryUI libraryUI;
        SelectionMode mode;
        BookSearching bookSearching;    
        UserModeUI userModeUI;
        MySQlData mySQlData;
        ValidInput validInput;
        private bool delete;
        

        public UserMenu()
        {
            validInput = new ValidInput();
            userModeUI = new UserModeUI();
            bookSearching = new BookSearching();
            libraryUI = new LibraryUI( );
            mode = new SelectionMode(libraryUI);
            mySQlData = MySQlData.Instance();
        }
        public void StartUserMenu()
        {
            int menuNumber;

            libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 40);

            while (Constants.isPROGRAM_ON)
            {
               
               menuNumber = mode.SelectUserManagerMenu("User", 7); // 유저메뉴 위아래 화살표로 선택하기
                
                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: // 도서찾기                    
                        bookSearching.SearchBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_RENT: // 도서대여
                      
                        bookSearching.BorrowBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_BORROW_LIST: //대여도서확인
                        //VariableData.book.ConfirmRentedBook();
                        break;
                    case Constants.BOOK_RETURN: // 도서 반납
                       // VariableData.book.ReturnBook();
                        break;
                    case Constants.BOOK_RETRUN_HISTORY:
                       // VariableData.book.ConfirmReturnBook(); // 도서반납확인
                        break;
                    case Constants.USER_EDIT: // 회원정보 수정
                        EditUserData();
                        Console.Clear();
                        break;
                    case Constants.DELETE: // 계정삭제
                        //delete = DeleteUserId();
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

        private void EditUserData() // 회원정보 변경
        {
            int menuNumber;
           

            UserVO userVO = new UserVO();
           
            Console.Clear();


     
            while (Constants.isPROGRAM_ON)
            {
                Console.SetCursorPosition(0, 0);    
                userModeUI.PrintUserDataEdit();  //유저 정보 변경 UI
                mySQlData.CheckLoginedUser(userVO, LibraryStart.loginedUser); // 로그인 된 회원정보를 다가져옴
                userModeUI.PrintLoginedUserData(userVO); // 기존 회원정보 프린트


                menuNumber = mode.SelectUserManagerMenu("Edit", 7);

                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: // 유저 ID                 
                        userVO.Id = validInput.EnterRegisterID(71, 22);                      
                        break;
                    case Constants.BOOK_RENT: // 유저 PW
                        userVO.Password = validInput.EnterInput(71, 23, ErrorMessage.PASSWORD, RegularExpression.PASSWORD);
                        break;
                    case Constants.BOOK_BORROW_LIST: //유저 이름
                        userVO.Name = validInput.EnterInput(74, 24, ErrorMessage.USER_NAME, RegularExpression.USER_NAME);
                        break;
                    case Constants.BOOK_RETURN: // 유저 나이
                        userVO.Age = validInput.EnterInput(73, 25, ErrorMessage.USER_AGE, RegularExpression.USER_AGE);
                        break;
                    case Constants.BOOK_RETRUN_HISTORY: // 유저 휴대폰
                        userVO.PhoneNumber = validInput.EnterInput(74, 26, ErrorMessage.USER_PHONE, RegularExpression.USER_PHONE);
                        break;
                    case Constants.USER_EDIT: // 유저 주소
                        userVO.Address = validInput.EnterInput(69, 27, ErrorMessage.USER_ADDRESS, RegularExpression.USER_ADDRESS);// 주소  
                        break;
                    case Constants.EDIT: // 변경하기 버튼
                        mySQlData.UpdateUserData(userVO.Id, userVO.Password, userVO.Name, userVO.Age, userVO.PhoneNumber, userVO.Address);
                        break;
                    case Constants.EXIT:
                        return;
                    default:
                        return;


                }


            }
        }

       
    }
}
