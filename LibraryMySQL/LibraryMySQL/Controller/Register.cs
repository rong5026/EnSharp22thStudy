using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class Register

    {

 
        string[] userData = new string[7];

        public bool RegistUser()
        {

            Console.Clear();
            VariableData.UserUI.PrintRegister();
            Console.SetCursorPosition(38, 7);

            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
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
                userData[6] = EnterUserDate(null, "address");// 주소  
                // 광역지방자치단체 + (기초지방자치단체) + (시 군 구) + (읍 면) + (도로명) + (건물번호)
                // ex) 경기도 + 수원시 + 영통구 + " " + 영통로+124
                // ex) 서울특별시+ 강남구 +" "+ " "+ 남부순환로 + 지하2744
                // ex) 서울특별시 +" "+ 구로구+ " " +경인로248-29

                VariableData.user.Id = userData[0];
                VariableData.user.Password = userData[1];
                VariableData.user.Name = userData[3];
                VariableData.user.Age = userData[4];
                VariableData.user.PhoneNumber = userData[5];
                VariableData.user.Address = userData[6];

                LibraryStart.userList.Add(VariableData.user); // UserList에 유저정보 추가
                Console.Clear();
                VariableData.UserUI.PrintSuccessRegister(); // 회원가입성공 UI

                Thread.Sleep(1000);

                return true;

               
            }

        }
        public string EnterUserDate(string password, string type) // 유저의 정보를 입력받음
        {
            switch (type)
            {
                case "id":
                    InputVO.id = VariableData.validInput.EnterId(38, 7);
                    return InputVO.id;
                case "password":
                    InputVO.repassword = VariableData.validInput.EnterIdOrPassword(38, 8);
                    return InputVO.repassword;
                case "repassword":
                    InputVO.repassword = VariableData.validInput.EnterRepassword(password, 38, 9);
                    return password;
                case "name":
                    InputVO.name = VariableData.validInput.EnterUserName(41, 10);
                    return InputVO.name;
                case "age":
                    InputVO.age = VariableData.validInput.EnterUserAge(39, 11);
                    return InputVO.age;
                case "phonenumber":
                    InputVO.phoneNumber = VariableData.validInput.EnterUserPhoneNumber(41, 12);
                    return InputVO.phoneNumber;
                case "address":
                    InputVO.address = VariableData.validInput.EnterUserAddress(39, 13);
                    return InputVO.address;
                default:
                    return "EIXT";
            }
        }

    }
        
}

