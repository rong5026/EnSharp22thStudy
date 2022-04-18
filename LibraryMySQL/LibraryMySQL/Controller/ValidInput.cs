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

        private bool check;     
        private string idPassword;
        private string error;
        private string input;
        ConsoleKeyInfo keyInput;

        public ValidInput()
        {
            userModeUI = new UserModeUI();
        }
        public ValidInput(UserModeUI userModeUI)
        {
            this.userModeUI = userModeUI;
        }


        
        public string EnterLoginID(int x, int y) // id 입력
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(107, 124, y); // 오류메시지 삭제

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
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");  // 지우기
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
                DeleteInput(107, 124, y);
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterLoginID(x, y);
            }

            return input;  // 문자형 id,password 리턴

        }
        public string EnterLoginPassWord(int x, int y) // password 입력
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(107, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_EMPTY;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");  // 지우기
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
                DeleteInput(107, 124, y);
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterLoginPassWord(x, y);
            }

            return input;  // 문자형 id,password 리턴

        }

        public string EnterRegisterID(int x, int y, MySQlData mySQlData) // 회원가입 ID 입력
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124-x, 124, y); // 오류메시지 삭제

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
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");  // 지우기
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
                return EnterRegisterID(x, y, mySQlData);
            }
            if(mySQlData.CheckUserId(input) == Constants.LOGIN_FAIL)
            {
                error = "기존 회원과 중복되는 ID입니다! 다른 ID를 입력해주세요.";
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRegisterID(x, y, mySQlData);
            }
            
            return input;  // 문자형 id,password 리턴

        }

        public string EnterRePassWord(string password, int x, int y, MySQlData mySQlData) // password 다시입력 후 확인
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(124 - x, 124, y); // 오류메시지 삭제

                if (keyInput.Key == ConsoleKey.Escape) // 뒤로가기
                    return Constants.INPUT_EMPTY;

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");  // 지우기
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
                return EnterRePassWord(password,x, y, mySQlData);
            }
            if (password != input)// 비밀번호가 같지않다면
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                error = "입력하신 비밀번호와 일치하지 않습니다! 다시입력해주세요";
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterRePassWord(password, x, y, mySQlData);
            }

            return input;  // 문자형 id,password 리턴

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
