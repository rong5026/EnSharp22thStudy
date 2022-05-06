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
        ValidInput validInput;
        BookDAO mySQlData;
        UserDAO userDAO;
        NaverSearching naverSearching;
        public UserMenu(ValidInput validInput, UserModeUI userModeUI,LibraryUI libraryUI,SelectionMode mode)
        {
            this.validInput = validInput;
            this.userModeUI = userModeUI;
            this.libraryUI = libraryUI;        
            this.mode = mode;
            bookSearching = new BookSearching(validInput, libraryUI, userModeUI);          
            mySQlData = BookDAO.Instance();
            userDAO= new UserDAO();
            naverSearching = new NaverSearching();
        }
        public void StartUserMenu()
        {
            int menuNumber;
            libraryUI.PrintMainUI();
            Console.SetWindowSize(125, 40);

            while (Constants.isPROGRAM_ON)
            {              
               menuNumber = mode.SelectUserManagerMenu("User", 8); // 유저메뉴 위아래 화살표로 선택하기
                
                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: // 도서찾기                    
                        bookSearching.SearchBook();
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LibraryStart.loginedUser, "도서찾기", "도서찾기");
                        Console.Clear();
                        break;
                    case Constants.BOOK_RENT: // 도서대여                   
                        Console.Clear();
                        bookSearching.BorrowBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_BORROW_LIST: //대여도서확인                  
                        bookSearching.ConfirmReturnAndRentBook("빌린", "대여도서확인");
                        Console.Clear();
                        break;
                    case Constants.BOOK_RETURN: // 도서 반납                      
                        bookSearching.ReturnBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_RETRUN_HISTORY:
                        bookSearching.ConfirmReturnAndRentBook("반납", "반납도서확인"); // 도서반납확인
                        Console.Clear();
                        break;
                    case Constants.USER_EDIT: // 회원정보 수정
                        EditUserData();
                        Console.Clear();
                        break;
                    case Constants.DELETE: // 계정삭제
                        if(DeleteUserId())
                            return;
                        break;
                    case Constants.NAVER_SEARCH_AND_ADDBOOK: // 네이버검색 후 도서추가
                        naverSearching.SearchInNaver();
                        Console.Clear();
                        break;
                    case Constants.EXIT:
                        return;
                    default:
                        return;

                }                
            }
        }
        private bool DeleteUserId() // 회원탈퇴
        {
            ConsoleKeyInfo keyInput;

            libraryUI.PrintMainUI();
            userModeUI.PrintDeleteID();

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (keyInput.Key == ConsoleKey.Escape)
                    return Constants.isDELETE_ID_FAIL; // ESC 누르면 뒤로가기 
                else if (keyInput.Key == ConsoleKey.Enter)
                {

                    if (mySQlData.LoginedUserRentBookCount(LibraryStart.loginedUser))
                    {
                        while (Constants.isPROGRAM_ON)
                        {
                            libraryUI.PrintMainUI();
                            userModeUI.PrintDeleteIDFail();
                            keyInput = Console.ReadKey(Constants.KEY_INPUT);
                            if (keyInput.Key == ConsoleKey.Escape)
                                return Constants.isDELETE_ID_FAIL; ; // ESC 누르면 뒤로가기 
                        }                      
                    }
                    userDAO.DeleteUserID(LibraryStart.loginedUser);
                    mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "유저", LibraryStart.loginedUser, "회원탈퇴"); // 로그저장
                    return Constants.isDELETE_ID_SUCCESS;
                }
                    
            }
        }
        private void EditUserData() // 회원정보 변경
        {
            int menuNumber;
            string id;
            string password;
            string name;
            string age;
            string phonenumber;
            string address;

            UserDTO userDTO = new UserDTO();
           
            Console.Clear();

            userDAO.GetLoginedUserLogList(userDTO, LibraryStart.loginedUser); // 로그인 된 회원정보를 다가져옴
            id = userDTO.Id;
            password = userDTO.Password;
            name = userDTO.Name;
            age = userDTO.Age;
            phonenumber = userDTO.PhoneNumber;
            address = userDTO.Address;

            while (Constants.isPROGRAM_ON)
            {
                Console.SetCursorPosition(0, 0);    
                userModeUI.PrintUserDataEdit();  //유저 정보 변경 UI
                userDAO.GetLoginedUserLogList(userDTO, LibraryStart.loginedUser); // 로그인 된 회원정보를 다가져옴
                userModeUI.PrintLoginedUserData(userDTO); // 기존 회원정보 프린트

                
                menuNumber = mode.SelectUserManagerMenu("Edit", 7);

                switch (menuNumber)
                {
                    case Constants.USER_ID: // 유저 ID                 
                        id = validInput.EnterRegisterID(71, 22);
                        if (id == Constants.INPUT_BACK)
                            id = userDTO.Id;
                        break;
                    case Constants.USER_PW: // 유저 PW
                        password = validInput.EnterInput(71, 23, ErrorMessage.PASSWORD, RegularExpression.PASSWORD);
                        if (password == Constants.INPUT_BACK)
                            password = userDTO.Password;
                        break;
                    case Constants.USER_NAME: //유저 이름
                        name = validInput.EnterInput(74, 24, ErrorMessage.USER_NAME, RegularExpression.USER_NAME);
                        if(name == Constants.INPUT_BACK)
                            name = userDTO.Name;
                        break;
                    case Constants.USER_AGE: // 유저 나이
                        age = validInput.EnterInput(73, 25, ErrorMessage.USER_AGE, RegularExpression.USER_AGE);
                        if (age == Constants.INPUT_BACK)
                            age = userDTO.Age;
                        break;
                    case Constants.USER_PHONE: // 유저 휴대폰
                        phonenumber = validInput.EnterInput(74, 26, ErrorMessage.USER_PHONE, RegularExpression.USER_PHONE);
                        if (phonenumber == Constants.INPUT_BACK)
                            phonenumber = userDTO.PhoneNumber;
                        break;
                    case Constants.USER_ADDRESS: // 유저 주소
                        address = validInput.EnterInput(69, 27, ErrorMessage.USER_ADDRESS, RegularExpression.USER_ADDRESS);// 주소
                        if(address == Constants.INPUT_BACK)
                            address = userDTO.Address;
                        break;
                    case Constants.EDIT: // 변경하기 버튼                    
                        userDAO.UpdateUserData(id, password, name, age, phonenumber, address);
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "유저", LibraryStart.loginedUser, "회원정보변경"); // 로그저장
                        Console.Clear();
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
