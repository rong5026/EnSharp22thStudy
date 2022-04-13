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
        string passWord;
        public void UserLogin()
        {
            
            UI.PrintLoginUI();

            id = exceuption.EnterId(62,16);
            passWord = exceuption.EnterPassword(63, 18);

           
        }
    }
}
