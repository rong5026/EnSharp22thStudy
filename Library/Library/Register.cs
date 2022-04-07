using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Register

    {
        const int EIXT = -1;
        const int ID =1;
        const int PASSWORD =2;
        const int REPASSWORD =3;
        const int NAME = 4;
        const int AGE=5;
        const int PHONE_NUMBER=6;
        const int ADDRESS =7;

        LibraryUI UI = new LibraryUI();
        ValidInput validInput = new ValidInput();
        UserVO user = new UserVO();
        ConsoleKeyInfo keyInput;
        string id;
        string password;
        string repassword;
        string name;
        string age;
        string phoneNumber;
        string address;
       
        string[] userDate = new string[7];

        public bool RegistUser(List<UserVO> list)
        {

            Console.Clear();
            UI.PrintRegister();
            Console.SetCursorPosition(38, 7);

            //user정보 입력.
            userDate[0] = EnterUserDate(list,null,"id");
            userDate[1] = EnterUserDate(list, null, "password");
            userDate[2] = EnterUserDate(list, userDate[1],"repassword");
            userDate[3] = EnterUserDate(list, null, "name");
            userDate[4] = EnterUserDate(list, null, "age");
            userDate[5] = EnterUserDate(list, null, "phonenumber");
            userDate[6] = EnterUserDate(list, null, "address");

            user.Id = userDate[0];
            user.Password = password;
            for (int index = 0; index < 7; index++)
            {
                if(userDate[index] == "EIXT")
                    return false;
                else
                {
                    for(int listindex = 0; listindex < list.Count; listindex++)
                    {
                        if(list[listindex].Id == userDate[0])
                        {
                            UI.PrintIdOverlap(); // 이미 존재하는 id 출력
                            return false;
                        }
                    }

                    


                }
            }




            return true;
        }

        public string EnterUserDate(List<UserVO> list,string password,string type)
        {
           
            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return "EIXT"; // ESC 누르면 뒤로가기 
            else
            {
                switch (type)
                {
                    case "id":
                        id = validInput.EnterId(list,38, 7);
                        return id; 
                    case "password":
                        password = validInput.EnterIdOrPassword(38, 8);
                        return password;
                    case "repassword":
                        repassword = validInput.EnterRepassword(password,38, 9);
                        return password;
                    case "name":
                        name = validInput.EnterUserName();
                        return name;
                    case "age":
                        age = validInput.EnterUserAge();
                        return age;
                    case "phonenumber":
                        phoneNumber = validInput.EnterUserPhoneNumber();
                        return phoneNumber;
                    case "address":
                        address = validInput.EnterUserAddress();
                        return address;
                    default:
                        return "EIXT";
                }

            }
        }
    }
}

