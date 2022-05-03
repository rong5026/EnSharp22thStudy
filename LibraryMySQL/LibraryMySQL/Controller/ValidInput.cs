using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
namespace LibraryMySQL
{
    internal class ValidInput
    {
        UserModeUI userModeUI;
        MySQlDataConnection mySQlData;
        private bool check;
        private string error;
        private string input;
        ConsoleKeyInfo keyInput;

        public ValidInput()
        {
            userModeUI = new UserModeUI();
            mySQlData = MySQlDataConnection.Instance();
        }
        public ValidInput(UserModeUI userModeUI)
        {
            mySQlData = MySQlDataConnection.Instance();
            this.userModeUI = userModeUI;
        }

        public string EnterInput(int x, int y, string errorMessage, string regular)
        {
            Console.CursorVisible = true;        
            error = errorMessage;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY; //공백인 상태로

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제


                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, regular);
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterInput(x, y, errorMessage, regular);
            }

            return input;  // 문자형 id,password 리턴
        }


        public string EnterLoginPassWord(int x, int y) // 로그인 비밀번호입력
        {
            Console.CursorVisible = true;

            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                    
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, RegularExpression.PASSWORD); // 숫자 영어 8~15글자
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.PASSWORD);
                return EnterLoginPassWord(x, y);
            }

            return input;  
        }

        public string EnterRegisterID(int x, int y) // 회원가입 ID 입력
        {
            Console.CursorVisible = true;
            error = ErrorMessage.ID;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)                   
                        break;                    
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, RegularExpression.ID); // 숫자 영어 8~15글자
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRegisterID(x, y);
            }
            if (CheckUserId(input) == Constants.LOGIN_FAIL)
            {               
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.ID_EXIST);
                return EnterRegisterID(x, y);
            }

            return input; 

        }
        private int CheckUserId(string id) // 회원가입시 이미 가입한 회원과 ID가 겹치는지 확인
        {
            List<UserVO> userList = new List<UserVO>();
            mySQlData.GetUserList(userList);

            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id)
                    return Constants.LOGIN_FAIL;
            }
            return Constants.LOGIN_SUCCESS;

        }
        public string EnterRePassWord(string password, int x, int y) // password 다시입력 후 확인
        {
            Console.CursorVisible = true;
            error = ErrorMessage.PASSWORD;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK; // "-1" 리턴

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)                   
                        break;
                    
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, RegularExpression.PASSWORD); // 숫자 영어 8~15글자
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRePassWord(password, x, y);
            }
            if (password != input)// 비밀번호가 같지않다면
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                error = ErrorMessage.PASSWORD_NO_CORRECT;
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRePassWord(password, x, y);
            }

            return input;  

        }



        // 책

        public string EnterBookName(int x, int y) // 책추가 기능 -이름 입력
        {
            Console.CursorVisible = true;
            error = ErrorMessage.BOOK_NAME;  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);


                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));


                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, RegularExpression.BOOK_NAME); // 영어,한글 1글자이상
          
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookName(x, y);
            }
            if (CheckBookName(input) == Constants.BOOK_EXIST)
            {
                error = ErrorMessage.BOOK_EXIST;
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookName(x, y);
            }

            return input;

        }
        private int CheckBookName(string bookName) // 책 이미 등록되어있는지 확인
        {
            List<BookVO> bookList;
            bookList = mySQlData.GetBookList();

            for (int index = 0; index < bookList.Count; index++)
            {
                if (bookList[index].Name == bookName)
                    return Constants.BOOK_EXIST;
            }
            return Constants.BOOK_NOT_EXIST;

        }
        public string EnterBookSearch(int x, int y, string errorMessage, string regular) // 책 찾기 할때 입력
        {
            Console.CursorVisible = true;
            error = ErrorMessage.BOOK_SEARCH;  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);


                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACKMENU;

                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(),RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;

                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, RegularExpression.BOOK_SEARCH);  // 영어,한글 1글자이상
            if (input == Constants.INPUT_EMPTY)
                return Constants.INPUT_EMPTY;
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookSearch(x, y, errorMessage, regular);
            }

            return input;

        }


        public string EnterDeleteBookID(int x, int y, string errorMessage, string regular,List<int> bookInedex, List<BookVO> bookList) // 삭제할 책 ID
        {
            Console.CursorVisible = true;
            error = errorMessage;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제


                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, regular);
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterDeleteBookID(x, y, errorMessage, regular, bookInedex, bookList);
            }
            if (CheckBookId(input) == Constants.BOOK_NOT_EXIST) // 책이 존재하지 않을 때
            {            
                DeleteInput(124 - x, 124, y); 
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.BOOK_NOT_EXIST);
                return EnterDeleteBookID(x, y, errorMessage, regular, bookInedex, bookList);
            }
            else if(CheckBookListID(input, bookInedex, bookList )==Constants.BOOK_NOT_EXIST){
                DeleteInput(124 - x, 124, y);
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.BOOK_NOT_EXIST_IN_LIST);
                return EnterDeleteBookID(x, y, errorMessage, regular, bookInedex, bookList);
            }


            return input;  // 문자형 id,password 리턴
        }

        private int CheckBookId(string bookId) // 책 이미 등록되어있는지 확인
        {
            List<BookVO> bookList;
            bookList = mySQlData.GetBookList();

            for (int index = 0; index < bookList.Count; index++)
            {
                if (bookList[index].Id == Convert.ToInt32( bookId))
                    return Constants.BOOK_EXIST;
            }
            return Constants.BOOK_NOT_EXIST;

        }
        private int CheckBookListID(string bookId,List<int> bookInedex, List<BookVO> bookList) // 검색한 책리스트에 있는 책인지
        {

          
            for (int index = 0; index < bookInedex.Count; index++)
            {
              
                if(Convert.ToInt32( bookId) == bookList[bookInedex[index]].Id)
                {
                    return Constants.BOOK_EXIST;
                }
              
            }
            return Constants.BOOK_NOT_EXIST;
        }
      
        public string EnterDeleteUserID(int x, int y, string errorMessage, string regular)  // 삭제할 유저ID 입력
        {
            Console.CursorVisible = true;
            error = errorMessage;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제


                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)                  
                        break;
                    
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, regular);
            if (check == Constants.NON_INPUT || CheckUserNumber(input) == Constants.USER_NOT_EXIST ) //유저가 존재하지않을때
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterDeleteUserID(x, y, errorMessage, regular);
            }
            if(mySQlData.LoginedUserRentBookCount( mySQlData.GetUserIdFromNumber( Convert.ToInt32(input))))// 대출한책이 있을 
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.USER_EXIST_RENT_BOOK);
                return EnterDeleteUserID(x, y, errorMessage, regular);
            }
            

            return input;  // 문자형 id,password 리턴
        }
        private int CheckUserNumber(string userNumber) // 존재하는 유저Number인지 확인
        {
            List<UserVO> userList=new List<UserVO>();
            mySQlData.GetUserList(userList); // 유저 리스트 

            for (int index = 0; index < userList.Count; index++)
            {             

                if (userList[index].Number == Convert.ToInt32( userNumber))
                    return Constants.USER_EXIST;
            }
            return Constants.USER_NOT_EXIST;
        }
        

        public string EnterLogId(int x, int y, string errorMessage, string regular) // Log ID입력
        {
            Console.CursorVisible = true;
            error = errorMessage;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제


                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;

                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, regular);
            if (check == Constants.NON_INPUT) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterLogId(x, y, errorMessage, regular);
            }
            if (CheckLogID(Convert.ToInt32( input)) == Constants.LOG_NOT_EXISTS)
            {
                DeleteInput(124 - x, 124, y);
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.LOG_NOT_EXIST);
                return EnterLogId(x, y, errorMessage, regular);
            }

            return input;  // 문자형 id,password 리턴
        }

        private int CheckLogID(int logId) // 존재하는 로그ID인지 확인
        {
            List<LogVO> logList = mySQlData.GetLogList();
         
            for (int index = 0; index < logList.Count; index++)
            {
                if (logList[index].Id == logId)
                    return Constants.LOG_EXISTS;
            }
            return Constants.LOG_NOT_EXISTS;
        }

        public string EnterBookISBN(int x, int y,List<BookVO> list) // 책 ISBN입력
        {
            Console.CursorVisible = true;
         
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), RegularExpression.KOREAN))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, RegularExpression.BOOK_ISBN); 
            if (check == Constants.NON_INPUT) // 정규식에 어긋날때
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.BOOK_ISBN);
                return EnterBookISBN(x, y, list);
            }
            if (CheckISBNInBookList(input) == Constants.BOOK_EXIST) // 이미 등록된 책일때
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.BOOK_EXIST);
                return EnterBookISBN(x, y, list);
            }
            if (CheckISBNInSearchingList(list,input)==Constants.BOOK_NOT_EXIST) // 검색된 list에 없는 isbn일때
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, ErrorMessage.BOOK_NOT_EXIST_IN_LIST);
                return EnterBookISBN(x, y, list);
            }
          

            return input;

        }
        private int CheckISBNInBookList(string isbn) // 책 리스트에 이미있는 ISBN인지
        {
            List<BookVO> bookList;
            bookList = mySQlData.GetBookList();

            for (int index = 0; index < bookList.Count; index++)
            {
                if (bookList[index].Isbn == isbn || bookList[index].Isbn.Contains(isbn))
                    return Constants.BOOK_EXIST;
            }
            return Constants.BOOK_NOT_EXIST;
        }
        private int CheckISBNInSearchingList(List<BookVO> list,string isbn)// 검색된 리스트에 있는 ISBN인지
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].Isbn == isbn || list[index].Isbn.Contains(isbn))
                    return Constants.BOOK_EXIST;
            }
            return Constants.BOOK_NOT_EXIST;
        }
        private void DeleteInput(int count, int x, int y) // 입력값 삭제
        {
            Console.SetCursorPosition(x, y);
            for (int index = 0; index < count; index++)         
                Console.Write("\b \b");
            
        }



    }
}
