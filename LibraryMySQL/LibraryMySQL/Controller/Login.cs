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
        MySQlData mySQlData;

        private string id;
        private string passWord;
        public Login(UserModeUI userModeUI, MySQlData mySQlData)
        {
            this.userModeUI = userModeUI;
            this.mySQlData = mySQlData;
            validInput = new ValidInput(userModeUI);
            
        }
        public int LoginUser() 
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
                id =  validInput.EnterIdOrPassword(17,6); // id 입력
                passWord =  validInput.EnterIdOrPassword(17,7); // password입력

                Console.WriteLine(id);
                Console.WriteLine(passWord);
                Console.ReadLine();
                return mySQlData.CheckLogin(id, passWord);
              

             

              

            }
            
            
        }
      
    }
}
