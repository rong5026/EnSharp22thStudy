using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Register

    {
 
        LibraryUI UI = new LibraryUI();
        ValidInput validInput = new ValidInput();
        UserVO user = new UserVO();
        ConsoleKeyInfo keyInput;
        string id;
        string repassword;
        string name;
        string age;
        string phoneNumber;
        string address;
       
        string[] userData = new string[7];

        public bool RegistUser(List<UserVO> list)
        {

            Console.Clear();
            UI.PrintRegister();
            Console.SetCursorPosition(38, 7);

            //user정보 입력.
            userData[0] = EnterUserDate(null,"id");
            userData[1] = EnterUserDate( null, "password");
            userData[2] = EnterUserDate( userData[1],"repassword");
            userData[3] = EnterUserDate( null, "name");
            userData[4] = EnterUserDate( null, "age");
            userData[5] = EnterUserDate( null, "phonenumber");
            userData[6] = EnterUserDate( null, "address");

            user.Id = userData[0];
            user.Password = userData[1];
            user.Name = userData[3];
            user.Age = userData[4];
            user.PhoneNumber = userData[5];
            user.Address = userData[6];

            for (int index = 0; index < 7; index++)
            {
                if(userData[index] == "EIXT")
                    return false;
                else
                {
                    list.Add(user);
                    Console.Clear();
                    UI.PrintSuccessRegister(); // 회원가입성공 UI
                   
                    keyInput = Console.ReadKey(true);
                    if (keyInput.Key == ConsoleKey.Enter)
                        return true;
                }
            }




            return true;
        }

        public string EnterUserDate(string password,string type)
        {
           
            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return "EIXT"; // ESC 누르면 뒤로가기 
            else
            {
                switch (type) 
                {
                    case "id":
                        id = validInput.EnterId(38, 7);
                        return id; 
                    case "password":
                        repassword = validInput.EnterIdOrPassword(38, 8);
                        return repassword;
                    case "repassword":
                        repassword = validInput.EnterRepassword(password,38, 9);
                        return password;
                    case "name":
                        name = validInput.EnterUserName(41,10);
                        return name;
                    case "age":
                        age = validInput.EnterUserAge(39,11);
                        return age;
                    case "phonenumber":
                        phoneNumber = validInput.EnterUserPhoneNumber(41,12);
                        return phoneNumber;
                    case "address":
                        address = validInput.EnterUserAddress(38,13);
                        return address;
                    default:
                        return "EIXT";
                }

            }
        }
    }
}

