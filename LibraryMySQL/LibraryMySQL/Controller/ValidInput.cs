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
                    DeleteInput(124-x, 124, y); // 오류메시지 삭제

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

        public string EnterUserName(int x, int y) // 유저이름 입력
        {
            Console.CursorVisible = true;
            error = "영어,한글,숫자 1글자이상 입력해주세요!";   //예외조건 성립안할때 출력
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
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어, 한글, 숫자 1글자 이상
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterUserName(x, y);
            }

            return input;  

        }

        public string EnterUserAge(int x, int y) // 유저나이 입력
        {
            Console.CursorVisible = true;
            error = "0~199까지 수를 입력해주세요!";   //예외조건 성립안할때 출력
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
                check = Regex.IsMatch(input, @"^1?[0-9]?[0-9]$"); // 0~ 199
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterUserAge(x, y);
            }

            return input;

        }

        public string EnterUserPhoneNumber(int x, int y) // 유저나이 입력
        {
            Console.CursorVisible = true;
            error = "01x-xxxx-xxxx 형식에 맞게 입력해주세요!";  //예외조건 성립안할때 출력
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
                check = Regex.IsMatch(input, @"01([0-9]{1})-([0-9]{4})-([0-9]{4})$"); // 01로 시작0~9숫자중 한개 오고 0~9 숫자 4개-0~9 숫자4개
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterUserPhoneNumber(x, y);
            }

            return input;

        }

        public string EnterUserAddress(int x, int y) // 주소입력
        {
            Console.CursorVisible = true;
            error = "주소형식에 맞게 입력해주세요!";  //예외조건 성립안할때 출력
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
                check = Regex.IsMatch(input, @"[ㄱ-ㅎ가-힣]{3,5}\s{0,1}([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣0-9]{2,}\s{0,1}?-?[0-9]{0,}?[ㄱ-ㅎ가-힣]{0,})?([ㄱ-ㅎ가-힣0-9]{1,}\s{0,1}?-?[0-9]{0,})?$");
            // 광역지방자치단체{한글 3~5글자} + (기초지방자치단체){한글3~5글자} + (시 군 구){한글3~5글자) + (읍 면){한글3~5글자) + (도로명){한글2글자 이상,-숫자 + (건물번호){한글숫자 1개이상, -,숫자}
            // ex) 경기도 + 수원시 + 영통구 + " " + 영통로+124
            // ex) 서울특별시+ 강남구 +" "+ " "+ 남부순환로 + 지하2744
            // ex) 서울특별시 +" "+ 구로구+ " " +경인로248-29
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterUserAddress(x, y);
            }

            return input;

        }
        public string EnterBookName(int x, int y) // 책이름 입력
        {
            Console.CursorVisible = true;
            error = "영어,한글,숫자 중 1개이상 입력해주세요!";  //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                   return Constants.INPUT_EMPTY;

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
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"); // 영어,한글,숫자 1글자이상
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

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    return Constants.INPUT_EMPTY;

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
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$");  // 영어,한글 1글자이상
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

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    return Constants.INPUT_EMPTY;

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
                check = Regex.IsMatch(input, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$");  // 영어,한글 1글자이상
            if (check == false) //
            {
                DeleteInput(124 - x, 124, y); // 오류메시지 삭제
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterBookPublisher(x, y);
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
