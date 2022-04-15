using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


namespace LectureTimeTable
{
    internal class Exception
    {
      
     
       
        LoginUI LoginUI =new LoginUI();
        ConsoleKeyInfo keyInput;
        string error;
        string id;
        string password;
        string input;
        bool check;
   
   

      
        public string EnterId(int x, int y ) // id 입력
        {
            Console.CursorVisible = true;
            error = "숫자8자리를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);
            
            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if(input=="")
                    DeleteInput(82, 179, 16); // 오류메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                check = Regex.IsMatch(input, @"^[0-9]{8}$"); // 숫자 6개
            if (check==false) //
            {
                DeleteInput(82, 179, 16);
                LoginUI.PrintErrorMessage(x, y, error);               
                return EnterId(x, y);
            }
           
            return input;  // 정수형 id 리턴

        }

        public string EnterPassword(int x, int y) // password입력
        {
            error = "영어+숫자 8~14자리를 입력해주세요!"; // 에러문자 출력

     
            Console.SetCursorPosition(x, y);
            input = "";
           
            while (Constant.PROGRAM_ON)
            {
              
                keyInput = Console.ReadKey(true);
                if (input == "")
                    DeleteInput(81, 179, 18); // 에러메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write("*"); // 입력값을 *로 출력
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {
               
                        break;
                    }
                }
            }

            // 정규식 예외처리

            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Z0-9]{8,14}$"); // 영어 + 숫자 8~14자리

            if (check == false) //
            {
                DeleteInput(81, 179, 18); // 입력했던거 삭제
                
                LoginUI.PrintErrorMessage(x, y, error);
               
                return EnterPassword(x, y);
            }
           
            return input;  //  password 리턴

        }

        public string EnterLectureName(int x, int y) // 수업이름
        {
            Console.CursorVisible = true;
            error = "영어+한글+숫자+특수기호(:,#,+,(, ) 1개이상 입력해주세요!"; // 에러문자 출력
          
            Console.SetCursorPosition(x, y);
            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if(input =="")
                    DeleteInput(Constant.WIDTH-1 -82, Constant.WIDTH-1, 14); // 오류메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                        Console.Write("\b \b");
                    }
                    else if (keyInput.Key == ConsoleKey.Enter)                   
                        break;
                    
                }
            }

            // 정규식 예외처리

            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Z0-9가-힣:+#()]{1,}$"); // 영어, 한글, 숫자, 특수문자 :,+,#,(,)

            if (check == false) //
            {
                DeleteInput(Constant.WIDTH - 1 - 82, Constant.WIDTH-1, 14); // 입력했던거 삭제

                LoginUI.PrintErrorMessage(x, y , error);

                return EnterLectureName(x, y);
            }
            return input;  //  password 리턴
        }

        public string EnterProfessorfeName(int x, int y) // 교수님이름
        {
            Console.CursorVisible = true;
            error = "영어+한글 1개이상 입력해주세요!"; // 에러문자 출력

            Console.SetCursorPosition(x, y);
            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == "")
                    DeleteInput(Constant.WIDTH - 1 - 80, Constant.WIDTH - 1, 16); // 오류메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                        Console.Write("\b \b");
                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;

                }
            }

            // 정규식 예외처리

            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Z가-힣]{1,}$"); // 영어, 한글, 숫자, 특수문자 :,+,#,(,)

            if (check == false) //
            {
                DeleteInput(Constant.WIDTH - 1 - 80, Constant.WIDTH - 1, 16); // 입력했던거 삭제

                LoginUI.PrintErrorMessage(x, y, error);

                return EnterProfessorfeName(x, y);
            }
            return input;  //  password 리턴
        }


        public string EnterLectureNO(int x, int y) {  // 과목NO

            Console.CursorVisible = true;
            error = "1~184 사이 자연수를 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == "")
                    DeleteInput(Constant.WIDTH-x-1, Constant.WIDTH-1, y); // 오류메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                check = Regex.IsMatch(input, @"^1?[0-9]?[1-9]$"); // 숫자 최대3개
            if (check == false || ( Convert.ToInt16(input)<1 || Convert.ToInt16(input) >184)) //
            {
                DeleteInput(Constant.WIDTH - x-1, Constant.WIDTH - 1, y); // 오류메시지 삭제
                LoginUI.PrintErrorMessage(x, y, error);
                return EnterLectureNO(x, y);
            }

            return input;  // 정수형 id 리턴

        }

        public string EnterStudyNumber(int x, int y) // 학수번호 입력
        {
            Console.CursorVisible = true;
            error = "숫자6글자 (0xxxxx)을 입력해주세요!";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == "")
                    DeleteInput(Constant.WIDTH - 1 - 80, Constant.WIDTH - 1, 12); // 오류메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                check = Regex.IsMatch(input, @"^0[0-9]{5}$"); // 숫자 6, 앞에 0개
            if (check == false) //
            {
                DeleteInput(Constant.WIDTH - 1 - 80, Constant.WIDTH - 1, 12); // 오류메시지 삭제
                LoginUI.PrintErrorMessage(x, y, error);
                return EnterStudyNumber(x, y);
            }

            return input;  // 정수형 id 리턴

        }
        public string EnterDivisionNumber(int x, int y) // 분반 입력
        {
            Console.CursorVisible = true;
            error = "숫자3자리 입력";   //예외조건 성립안할때 출력
            Console.SetCursorPosition(x, y);

            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (input == "")
                    DeleteInput(Constant.WIDTH - 1 - 76, Constant.WIDTH - 1, 13); // 오류메시지 삭제
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                check = Regex.IsMatch(input, @"^[0-9]{3}$"); // 숫자 3
            if (check == false) //
            {
                DeleteInput(Constant.WIDTH - 1 - 76, Constant.WIDTH - 1, 13); // 오류메시지 삭제
                LoginUI.PrintErrorMessage(x, y, error);
                return EnterDivisionNumber(x, y);
            }

            return input;  // 정수형 id 리턴

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
