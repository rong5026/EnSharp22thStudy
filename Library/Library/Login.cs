using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library
{

    internal class Login
    {
        
        const int LOGIN_INDEX = 0;
        const bool BACK = false;
        const bool LOGIN_FAIL = false;
        const bool LOGIN_SUCCESS = true;
        ValidInput validInput =  new ValidInput();
        LibraryUI UI = new LibraryUI();
        ConsoleKeyInfo keyInput;
      
        string id;
        string password;


         
        public bool UserLogin(List<UserVO> list) 
        {
            Console.Clear();
            UI.PrintLogin(); // 위에 로그인 화면 

            Console.SetCursorPosition(17, 6);
            keyInput = Console.ReadKey(true);

            if (keyInput.Key == ConsoleKey.Escape)
                return BACK; // ESC 누르면 뒤로가기 
            else
            {
                id = validInput.EnterIdOrPassword(17,6); // id 입력
                password = validInput.EnterIdOrPassword(17,7); // password입력

                for (int index = 1; index < list.Count; index++) // userList의 0인덱스는 현재 로그인한 사람의 정보
                {
                    if (list[index].Id == id && list[index].Password == password)
                    {
                        list[LOGIN_INDEX] = list[index]; // 0인덱스에 로그인한 사람의 정보를 넣음

                        Console.Clear();
                        UI.PrintSuccessLogin();  // 로그인 성공 UI출력
                        return LOGIN_SUCCESS; // 로그인 성공
                    }
                    else           
                        return LOGIN_FAIL; // 로그인 실패
                    
                }
                return LOGIN_FAIL;

            }
        }
    }
}
