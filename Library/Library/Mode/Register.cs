using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Register

    {

       
        UserModeUI UserUI = new UserModeUI();
        ValidInput validInput = new ValidInput();
        UserVO user = new UserVO();
        ConsoleKeyInfo keyInput;
      

        string[] userData = new string[7];

        public bool RegistUser()
        {

            Console.Clear();
            UserUI.PrintRegister();
            Console.SetCursorPosition(38, 7);

            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return false; // ESC 누르면 뒤로가기 
            else
            {
                //user정보 입력.
                userData[0] = EnterUserDate(null, "id"); // 가입된 사람의 id와 중복되면 안됨.
                userData[1] = EnterUserDate(null, "password");
                userData[2] = EnterUserDate(userData[1], "repassword"); // 입력한 비밀번호가 같은지 확인
                userData[3] = EnterUserDate(null, "name"); // 유저이름 : 영어 또는 한글 1글자 이상
                userData[4] = EnterUserDate(null, "age"); // 0~ 199세 까지 입력
                userData[5] = EnterUserDate(null, "phonenumber"); // 전화번호 01x-xxxx-xxxx
                userData[6] = EnterUserDate(null, "address");// 주소 : 한글 + 숫자 최소 3단어 이상

                user.Id = userData[0];
                user.Password = userData[1];
                user.Name = userData[3];
                user.Age = userData[4];
                user.PhoneNumber = userData[5];
                user.Address = userData[6];

                LibraryStart.userList.Add(user); // UserList에 유저정보 추가
                Console.Clear();
                UserUI.PrintSuccessRegister(); // 회원가입성공 UI

                keyInput = Console.ReadKey(true);
                
                return true;

               
            }

        }
        public string EnterUserDate(string password, string type) // 유저의 정보를 입력받음
        {
            switch (type)
            {
                case "id":
                    InputVO.id = validInput.EnterId(38, 7);
                    return InputVO.id;
                case "password":
                    InputVO.repassword = validInput.EnterIdOrPassword(38, 8);
                    return InputVO.repassword;
                case "repassword":
                    InputVO.repassword = validInput.EnterRepassword(password, 38, 9);
                    return password;
                case "name":
                    InputVO.name = validInput.EnterUserName(41, 10);
                    return InputVO.name;
                case "age":
                    InputVO.age = validInput.EnterUserAge(39, 11);
                    return InputVO.age;
                case "phonenumber":
                    InputVO.phoneNumber = validInput.EnterUserPhoneNumber(41, 12);
                    return InputVO.phoneNumber;
                case "address":
                    InputVO.address = validInput.EnterUserAddress(46, 13);
                    return InputVO.address;
                default:
                    return "EIXT";
            }
        }

    }
        
}

