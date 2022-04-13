using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LTT
{
    internal class Exception
    {

        LoginUI LoginUI =new LoginUI();
        ConsoleKeyInfo keyInput;
        string error;
        string success = "예외처리 조건에 적합합니다 !!!";
        string id;
        string password;
        string input;
        bool check;
        int xPosition;
        int yPosition;

        public string EnterId(int x, int y) // id 입력
        {
            error = "숫자8자리를 입력해주세요!";
            Console.SetCursorPosition(x, y);
            
            input = "";

            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

                if (keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Enter)
                {
                    input += keyInput.KeyChar;
                    Console.Write(keyInput.KeyChar);
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
                        xPosition = Console.GetCursorPosition().Left;
                        yPosition = Console.GetCursorPosition().Top;
                        break;
                    }
                }                
            }

            /////////////////////////////////////
            if (input != null)
                check = Regex.IsMatch(input, @"^[0-9]{8}$"); // 숫자 6개
            if (check==false) //
            {
                DeleteInput(input.Length, xPosition, yPosition);
                LoginUI.PrintErrorMessage(x, y+1, error);               
                return EnterId(x, y);
            }
            LoginUI.PrintSuccessMessage(x, y + 1, success);
            return input;  // 정수형 id 리턴

        }

        public string EnterPassword(int x, int y) // password입력
        {
            error = "영어+숫자 8~14자리를 입력해주세요!";

     
            Console.SetCursorPosition(x, y);
            input = "";
           
            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return "";

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
                        Console.Write("\b \b");
                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {
                        xPosition = Console.GetCursorPosition().Left;
                        yPosition = Console.GetCursorPosition().Top;
                        break;
                    }
                }
            }

          
            if (input != null)
                check = Regex.IsMatch(input, @"^[a-zA-Z0-9]{8,14}$"); // 영어 + 숫자 8~14자리

            if (check == false) //
            {
                DeleteInput(input.Length, xPosition, yPosition);
                
                LoginUI.PrintErrorMessage(x, y+1, error);
               
                return EnterPassword(x, y);
            }
            LoginUI.PrintSuccessMessage(x-1, y + 1, success);
            return input;  //  password 리턴

        }


        public void DeleteInput(int count, int x, int y)
        {
            Console.SetCursorPosition(x, y);        
            for (int index = 0; index < count; index++)
            {
             
                Console.Write("\b \b");
            }
        }
    }
}
