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
        LibraryUI UI = new LibraryUI();
        string id;
        string password;
      
        public bool UserManagerLogin(List<UserVO> list)
        {
            Console.Clear();
            UI.PrintLogin(); // 위에 로그인 화면 

          
            id = validInput.EnterId();

            return true;


        }
    }
}
