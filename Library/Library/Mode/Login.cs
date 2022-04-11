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
        
        
        ValidInput validInput =  new ValidInput();
        UserModeUI UserModeUI = new UserModeUI();      
        ConsoleKeyInfo keyInput;
      
        string id;
        string password;
        

         
        public int UserLogin(List<UserVO> list) 
        {
            Console.Clear();
            UserModeUI.PrintRealLogin(); // 로그인 할건지 묻는 UI
          
            Console.SetCursorPosition(17, 6);
            keyInput = Console.ReadKey(true);

            if (keyInput.Key == ConsoleKey.Escape)
                return Const.BACK; // ESC 누르면 뒤로가기 
            else 
            {
                Console.Clear();
                UserModeUI.PrintLogin(); // 위에 로그인 화면 
                id = validInput.EnterIdOrPassword(17,6); // id 입력
                password = validInput.EnterIdOrPassword(17,7); // password입력

                for (int index = 1; index < list.Count; index++) // userList의 0인덱스는 현재 로그인한 사람의 정보
                {
                    if (list[index].Id == id && list[index].Password == password)
                    {
                        list[Const.LOGIN_INDEX] = list[index]; // 0인덱스에 로그인한 사람의 정보를 넣음

                        Console.Clear();
                        UserModeUI.PrintSuccessLogin();  // 로그인 성공 UI출력
                        keyInput = Console.ReadKey(true);

                        
                            
                        return Const.LOGIN_SUCCESS; // 로그인 성공
                    }
                    else           
                        return Const.LOGIN_FAIL; // 로그인 실패
                    
                }
                return Const.LOGIN_FAIL;

            }
            
            
        }
    }
}
