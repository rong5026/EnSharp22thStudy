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
                    DeleteInput(82, 179, y); // 오류메시지 삭제

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
                DeleteInput(82, 179, y);
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterLoginID(x, y);
            }

            return input;  // 문자형 id,password 리턴

        }
        public string EnterLoginPassWord(int x, int y) // id 입력
        {
            Console.CursorVisible = true;
            error = "숫자+영어 8~15글자를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = Constants.INPUT_EMPTY;

            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == Constants.INPUT_EMPTY)
                    DeleteInput(82, 179, y); // 오류메시지 삭제

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
                DeleteInput(82, 179, y);
                userModeUI.PrintErrorMessage(x, y, error);
                return EnterLoginID(x, y);
            }

            return input;  // 문자형 id,password 리턴

        }


        ///책 관련 입력
        ///
        public string EnterBookId(int x, int y) // 책번호
        {
            InputVO.error = "0~999범위 안의 수를 입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);

            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();

            if (InputVO.name != null)
                check = Regex.IsMatch(InputVO.name, @"^[1-9]?[0-9]?[0-9]$"); //0~999까지의 수
            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterBookId(x, y);
            }
            return InputVO.name;

        }
        public string EnterBookName(int x, int y) // 책이름 
        {
            InputVO.error = "영어,한글,숫자 중 1개이상 입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);

            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();
            if (InputVO.name == "?")
                return null;
            if (InputVO.name != null)
                check = Regex.IsMatch(InputVO.name, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"); // 영어,한글,숫자 1글자이상
            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterBookName(x, y);
            }
            return InputVO.name; // 방금 수정

        }
        public string EnterAuthor(int x, int y) // 저자이름
        {
            InputVO.error = "영어,한글 1글자 이상입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);

            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();

            if (InputVO.name == "?")
                return null;
            if (InputVO.name != null)
                check = Regex.IsMatch(InputVO.name, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어,한글 1글자이상
            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterAuthor(x, y);
            }
            return InputVO.name;

        }
        public string EnterBookPublisher(int x, int y)// 출판사
        {
            InputVO.error = "영어,한글,숫자 1글자 이상 입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();

            if (InputVO.name == "?")
                return null;
            if (InputVO.name != null)
                check = Regex.IsMatch(InputVO.name, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"); // 영어,한글,숫자 1글자이상

            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterBookPublisher(x, y);
            }
            return InputVO.name;
        }


        public string EnterBookCount(int x, int y) // 책 수량
        {
            InputVO.error = "1~999 범위 내에서 입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.id = Console.ReadLine();

            if (InputVO.id != null)
                check = Regex.IsMatch(InputVO.id, @"^[1-9][0-9]{0,2}$"); //  1~999
            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterBookCount(x, y);
            }
            return InputVO.id;
        }
        public string EnterBookPrice(int x, int y) // 책 가격
        {
            InputVO.error = "1~9999999 범위 내에서 입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);

            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.id = Console.ReadLine();

            if (InputVO.id != null)
                check = Regex.IsMatch(InputVO.id, @"^[1-9][0-9]{0,6}$"); //   1 ~9999999개
            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterBookPrice(x, y);
            }
            return InputVO.id;
        }
        public string EnterBookDate(int x, int y) // 책 출시 날짜
        {
            InputVO.error = "19xx or 20xx-02-03 범위 내에서 입력해주세요!";
            DeleteInput(InputVO.error.Length, x, y);

            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.id = Console.ReadLine();

            if (InputVO.id != null)
                check = Regex.IsMatch(InputVO.id, @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[1-2][0-9]|3[0-1])$"); //2010-04-23
            if (!check)
            {
                VariableData.UserUI.PrintMessage(x, y, InputVO.error);
                Thread.Sleep(1000);
                return EnterBookDate(x, y);
            }
            return InputVO.id;
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
