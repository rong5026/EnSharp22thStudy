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

        Login login = new Login();
        List<UserVO> userList = new List<UserVO>();

        bool loginStatus;

       

        public bool UserLogin()
        {
            UserVO user = new UserVO("19011617", "hong5026");
            userList.Add(user); // 나중에고쳐야함

            Console.Clear();
            UI.PrintLoginUI(); // 로그인 UI출력

            while (Constant.PROGRAM_ON)
            {

                id = exceuption.EnterId(62, 16);
                if (id == "")    //ESC 누르면 프로그램 종료     
                    return Constant.PROGRAM_OFF;
                password = exceuption.EnterPassword(63, 18);
                if (password == "") // 비밀번호 누르는곳에서 ESC누르면 프로그램 종료
                    return Constant.PROGRAM_OFF;

                for (int index = 0; index < userList.Count; index++)
                {
                    if (userList[index].Id == id && userList[index].Password == password)
                    {
                        return true;
                    }
                }


                return false;

            }

        }
    }
}
