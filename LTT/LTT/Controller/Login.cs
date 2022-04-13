using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    internal class Login
    {
        LoginUI UI = new LoginUI();
        Exception exceuption =new Exception();
        ConsoleKeyInfo keyInput;

        string id;
        string password;
        public void UserLogin()
        {
            
            UI.PrintLoginUI();

        
            id = exceuption.EnterId(62,16);
            if (id == "")    //ESC 누르면 프로그램 종료     
                return;
            password = exceuption.EnterPassword(63, 18);
            if (password == "") // 비밀번호 누르는곳에서 ESC누르면 프로그램 종료
                return;




        }
    }
}
