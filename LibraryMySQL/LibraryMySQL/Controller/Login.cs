using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{

    internal class Login
    {

        UserModeUI userModeUI;
        ConsoleKeyInfo keyInput;
        ValidInput validInput ;

        public Login(UserModeUI userModeUI)
        {
            this.userModeUI = userModeUI;
            validInput = new ValidInput(userModeUI);
            
        }
        public int UserLogin() 
        {
            Console.Clear();
             userModeUI.PrintRealLogin(); // 로그인 할건지 묻는 UI
          
            Console.SetCursorPosition(17, 6);
             keyInput = Console.ReadKey(true);

            if ( keyInput.Key == ConsoleKey.Escape)
                return Constants.BACK; // ESC 누르면 뒤로가기 
            else 
            {
                Console.Clear();
                 userModeUI.PrintLogin(); // 위에 로그인 화면 
                InputVO.id =  validInput.EnterIdOrPassword(17,6); // id 입력
                InputVO.password =  validInput.EnterIdOrPassword(17,7); // password입력

                for (int index = 1; index < LibraryStart.userList.Count; index++) // userList의 0인덱스는 현재 로그인한 사람의 정보
                {
                   
         
                    if (LibraryStart.userList[index].Id == InputVO.id && LibraryStart.userList[index].Password == InputVO.password)
                    {
                    
                        LibraryStart.userList[Constants.LOGIN_INDEX] = LibraryStart.userList[index]; // 0인덱스에 로그인한 사람의 정보를 넣음

                        Console.Clear();
                         userModeUI.PrintSuccessLogin();  // 로그인 성공 UI출력
                      

                        return Constants.LOGIN_SUCCESS; // 로그인 성공
                    }
                   
                    
                }
                return Constants.LOGIN_FAIL;

            }
            
            
        }
      
    }
}
