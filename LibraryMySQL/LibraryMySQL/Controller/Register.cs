using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class Register

    {

        ConsoleKeyInfo keyInput;
        UserModeUI userModeUI = new UserModeUI();
        
        ValidInput validInput;
        private string[] userData = new string[7];
        MySQlData mySQlData;


        string id;
        string password;
        string repassword;
        string name;
        string age;
        string phoneNumber;
        string address;


        public Register( MySQlData mySQlData)
        {                
            validInput = new ValidInput(userModeUI);
            this.mySQlData = mySQlData;
        }
        public bool RegistUser()
        {

            Console.Clear();
            userModeUI.PrintRegister();
            Console.SetCursorPosition(38, 7);

            //user정보 입력.
            userData[0] = EnterUserData("", "id", mySQlData); // 가입된 사람의 id와 중복되면 안됨.
            if (userData[0] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;
            userData[1] = EnterUserData("", "password", mySQlData);
            if (userData[1] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;
            userData[2] = EnterUserData(userData[1], "repassword", mySQlData); // 입력한 비밀번호가 같은지 확인
            if (userData[2] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;
            userData[3] = EnterUserData("", "name", mySQlData); // 유저이름 : 영어 또는 한글 1글자 이상
            if (userData[3] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;
            userData[4] = EnterUserData("", "age", mySQlData); // 0~ 199세 까지 입력
            if (userData[4] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;
            userData[5] = EnterUserData("", "phonenumber", mySQlData); // 전화번호 01x-xxxx-xxxx
            if (userData[5] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;
            userData[6] = EnterUserData("", "address", mySQlData);// 주소  
            if (userData[6] == Constants.INPUT_EMPTY)
                return Constants.REGISTER_FAIL;

            // 광역지방자치단체 + (기초지방자치단체) + (시 군 구) + (읍 면) + (도로명) + (건물번호)
            // ex) 경기도 + 수원시 + 영통구 + " " + 영통로+124
            // ex) 서울특별시+ 강남구 +" "+ " "+ 남부순환로 + 지하2744
            // ex) 서울특별시 +" "+ 구로구+ " " +경인로248-29

            mySQlData.InsertUserData(userData[0], userData[1], userData[3], userData[4], userData[5], userData[6]); // 회원Data에 추가


            Console.Clear();
            userModeUI.PrintSuccessRegister(); // 회원가입성공 UI


            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                    return Constants.REGISTER_SUCCESS;
            }

          
            

         




        }
        private string EnterUserData(string password, string type, MySQlData mySQlData) // 유저의 정보를 입력받음
        {
            switch (type)
            {
                case "id":
                  id =  validInput.EnterRegisterID(38, 7, mySQlData);
                    return id;
                case "password":
                    repassword =  validInput.EnterLoginPassWord(38, 8);
                    return repassword;
                case "repassword":
                  repassword =  validInput.EnterRePassWord(password, 38, 9, mySQlData);
                    return repassword;
                case "name":
                    name =  validInput.EnterUserName(41, 10);
                    return name;
                case "age":
                   age =  validInput.EnterUserAge(39, 11);
                    return age;
                case "phonenumber":
                    phoneNumber =  validInput.EnterUserPhoneNumber(41, 12);
                    return phoneNumber;
                case "address":
                   address =  validInput.EnterUserAddress(39, 13);
                    return address;
                default:
                    return "EIXT";
            }
        }

       

    }
        
}

