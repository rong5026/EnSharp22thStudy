﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class AdminMenu
    {
        LibraryUI libraryUI;
        SelectionMode mode;
        BookSearching bookSearching;
        UserModeUI userModeUI;
        AdminModeUI adminModeUI;
        ValidInput validInput;
        MySQlData mySQlData;
        Login login;
     
        public AdminMenu(ValidInput validInput, UserModeUI userModeUI)
        {
            this.validInput = validInput;
            this.userModeUI = userModeUI;
            libraryUI = new LibraryUI();
            adminModeUI = new AdminModeUI();
            bookSearching = new BookSearching(validInput, libraryUI);        
            mode = new SelectionMode(libraryUI);
            mySQlData = MySQlData.Instance();
            login = new Login(userModeUI, validInput);
        }

        public void StartAdminMode()
        {
            int input;
            while (Constants.isPROGRAM_ON)
            {
                input = login.LoginUser("Admin");

                if (input == Constants.ADMIN_MODE)
                    StartAdminMenu();
                else if (input == Constants.BACK)               
                    return;
                   
                

            }
        }
        public void StartAdminMenu()
        {
            int menuNumber;

            libraryUI.PrintMainUI();
            while (Constants.isPROGRAM_ON)
            {

                menuNumber = mode.SelectUserManagerMenu("Admin", 6); // 유저메뉴 위아래 화살표로 선택하기

                switch (menuNumber)
                {
                    case Constants.BOOK_SEARCH: //도서찾기                  
                        bookSearching.SearchBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_ADD: // 도서추가             
                        AddBook();
                        Console.Clear();
                        break;
                    case Constants.BOOK_DELETE: //도서삭제         

                        break;
                    case Constants.BOOK_EDIT: // 도서수정                

                        break;
                    case Constants.USER_CARE: // 회원관리

                        break;
                    case Constants.TOTAL_USER_RENTBOOK: // 대여상황보기

                        break;
                    case Constants.EXIT:
                        Console.Clear();
                        return;
                    default:
                        return;


                }


            }

        }

        private void AddBook()
        {
            
            string name;
            string author;
            string publisher;
            string count;
            string price;
            string date;
            Console.Clear();
            while (Constants.isPROGRAM_ON)
            {
                adminModeUI.PrintAdminMenuMessage("도서찾기");
                adminModeUI.PrtinInputAddBook();
                Console.ReadLine();

                name = validInput.EnterBookName(71, 22); // 책 이름 입력           
                author = validInput.EnterInput(71, 22,ErrorMessage.BOOK_AUTHOR,RegularExpression.BOOK_AUTHOR); // 저자 입력
                publisher = validInput.EnterInput(71, 22,ErrorMessage.BOOK_PUBISHER,RegularExpression.BOOK_PUBISHER); // 출판사
                count = validInput.EnterInput(71, 22,ErrorMessage.BOOK_COUNT,RegularExpression.BOOK_PUBISHER); // 책 수량
                price = validInput.EnterInput(71, 22,ErrorMessage.BOOK_PRICE,RegularExpression.BOOK_PRICE); // 책 가격
                date = validInput.EnterInput(71, 22,ErrorMessage.BOOK_DATE,RegularExpression.BOOK_DATE); // 책 출판날짜


            }
        }
    }
}
