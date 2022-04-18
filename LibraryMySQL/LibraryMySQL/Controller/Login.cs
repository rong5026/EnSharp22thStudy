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
       

         
        public int UserLogin() 
        {
            Console.Clear();
            VariableData.UserModeUI.PrintRealLogin(); // 로그인 할건지 묻는 UI
          
            Console.SetCursorPosition(17, 6);
            VariableData.keyInput = Console.ReadKey(true);

            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return Const.BACK; // ESC 누르면 뒤로가기 
            else 
            {
                Console.Clear();
                VariableData.UserModeUI.PrintLogin(); // 위에 로그인 화면 
                InputVO.id = VariableData.validInput.EnterIdOrPassword(17,6); // id 입력
                InputVO.password = VariableData.validInput.EnterIdOrPassword(17,7); // password입력

                for (int index = 1; index < LibraryStart.userList.Count; index++) // userList의 0인덱스는 현재 로그인한 사람의 정보
                {
                   
         
                    if (LibraryStart.userList[index].Id == InputVO.id && LibraryStart.userList[index].Password == InputVO.password)
                    {
                    
                        LibraryStart.userList[Const.LOGIN_INDEX] = LibraryStart.userList[index]; // 0인덱스에 로그인한 사람의 정보를 넣음

                        Console.Clear();
                        VariableData.UserModeUI.PrintSuccessLogin();  // 로그인 성공 UI출력
                        Thread.Sleep(1000);

                        return Const.LOGIN_SUCCESS; // 로그인 성공
                    }
                   
                    
                }
                return Const.LOGIN_FAIL;

            }
            
            
        }
    }
}
