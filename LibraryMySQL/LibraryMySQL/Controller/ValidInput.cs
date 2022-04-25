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
        MySQlData mySQlData;
        private bool check;     
        private string error;
        private string input;
        ConsoleKeyInfo keyInput;

        public ValidInput()
        {
            userModeUI = new UserModeUI();
            mySQlData = MySQlData.Instance();
        }
        public ValidInput(UserModeUI userModeUI)
        {
             mySQlData = MySQlData.Instance();
            this.userModeUI = userModeUI;
        }

        public string EnterInput(int x,int y,string errorMessage,string regular)
        {
            Console.CursorVisible = true;
            Console.CursorVisible = true;
            error = errorMessage;   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
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
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, regular); 
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterInput(x, y, errorMessage, regular);
            }

            return input;  // 문자형 id,password 리턴
        }


        public string EnterLoginPassWprd(int x, int y) // 로그인 비밀번호입력
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
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
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[0-9a-zA-Z]{8,15}$"); // 숫자 영어 8~15글자
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRegisterID(x, y);
            }
          

            return input;  // 문자형 id,password 리턴

        }

        public string EnterRegisterID(int x, int y) // 회원가입 ID 입력
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124-x, 124, y); // 오류메시지 삭제

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
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[0-9a-zA-Z]{8,15}$"); // 숫자 영어 8~15글자
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRegisterID(x, y);
            }
            if(CheckUserId(input) == Constants.LOGIN_FAIL)
            {
                error = "기존 회원과 중복되는 ID입니다!";
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRegisterID(x, y);
            }
            
            return input;  // 문자형 id,password 리턴

        }
        private int CheckUserId(string id) // 회원가입시 이미 가입한 회원과 ID가 겹치는지 확인
        {
            List<UserVO> userList = new List<UserVO>();
            mySQlData.SendUserList(userList);

            for(int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id)
                    return Constants.LOGIN_FAIL;
            }
            return Constants.LOGIN_SUCCESS;

        }
        public string EnterRePassWord(string password, int x, int y) // password 다시입력 후 확인
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_BACK; // "-1" 리턴

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar);                 
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[0-9a-zA-Z]{8,15}$"); // 숫자 영어 8~15글자
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRePassWord(password,x, y);
            }
            if (password != input)// 비밀번호가 같지않다면
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                error = "입력하신 비밀번호와 일치하지 않습니다! 다시입력해주세요";
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRePassWord(password, x, y);
            }

            return input;  // 문자형 id,password 리턴

        }

      


        public string EnterBookName(int x, int y) // 책이름 입력
        {
            Console.CursorVisible = true;
            error = "영어,한글,숫자 중 1개이상 입력해주세요!";  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
               

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACKMENU;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(   input[input.Length-1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$")) 
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                       
                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"); // 영어,한글,숫자 1글자이상
            if (input == Constants.INPUT_EMPTY)
                return Constants.INPUT_EMPTY;
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookName(x, y);
            }

            return input;

        }

        public string EnterAuthor(int x, int y) // 저자 입력
        {
            Console.CursorVisible = true;
            error = "영어,한글 1글자 이상입력해주세요!";  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
             

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACKMENU;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$");  // 영어,한글 1글자이상
            if (input == Constants.INPUT_EMPTY)
                return Constants.INPUT_EMPTY;
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterAuthor(x, y);
            }

            return input;

        }

        public string EnterBookPublisher(int x, int y) // 출판사 입력
        {
            Console.CursorVisible = true;
            error = "영어,한글,숫자 1글자 이상 입력해주세요!";  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
              

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.BACKMENU;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$");  // 영어,한글 1글자이상
            if (input == Constants.INPUT_EMPTY)
                return Constants.INPUT_EMPTY;
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookPublisher(x, y);
            }

            return input;

        }

        public string EnterBookId(int x, int y) // 유저나이 입력
        {
            Console.CursorVisible = true;
            error = "0~999범위 안의 수를 입력해주세요!";  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_EMPTY;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar); // 입력값을 그대로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (Regex.IsMatch(input[input.Length - 1].ToString(), @"^[ㄱ-ㅎ가-힣]{1,}$"))
                            Console.Write("\b \b\b \b");  // 지우기
                        else
                            Console.Write("\b \b");  // 지우기
                        input = input.Substring(0, (input.Length - 1));

                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {

                        break;
                    }
                }
            }

            // 정규식 예외처리
            if (input != null)
                check = Regex.IsMatch(input, @"^[1-9]?[0-9]?[0-9]$");  //0~999까지의 수
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookId(x, y);
            }

            return input;

        }
        private void DeleteInput(int count, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            for (int index = 0; index < count; index++)
            {

                Console.Write("\b \b");
            }
        }



    }
}
