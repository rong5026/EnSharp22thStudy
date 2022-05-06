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
        UserModeUI userModeUI;
        ValidInput validInput;     
        MySQlDataConnection mySQlData;
        UserDAO userDAO;


        private string id;
        private string password;
        private string repassword;
        private string name;
        private string age;
        private string phoneNumber;
        private string address;


        public Register( UserModeUI userModeUI, ValidInput validInput)
        {
            this.userModeUI = userModeUI;       
            this.validInput = validInput;
            mySQlData = MySQlDataConnection.Instance();
            userDAO = new UserDAO();
        }
        public bool RegistUser()
        {

            Console.Clear();
            userModeUI.PrintRegister();
            Console.SetCursorPosition(38, 7);

            //user정보 입력.
            id = validInput.EnterRegisterID(74, 35); // 가입된 사람의 id와 중복되면 안됨.
            if (id == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;

            password = validInput.EnterLoginPassWord(74, 36);
            if (password == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;

            repassword = validInput.EnterRePassWord(password, 74, 37); // 입력한 비밀번호가 같은지 확인
            if (repassword == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;

            name = validInput.EnterInput(77, 38, ErrorMessage.USER_NAME, RegularExpression.USER_NAME);  // 유저이름 : 영어 또는 한글 1글자 이상      
            if (name == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;

            age = validInput.EnterInput(75, 39, ErrorMessage.USER_AGE, RegularExpression.USER_AGE); // 0~ 199세 까지 입력
            if (age == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;

            phoneNumber= validInput.EnterInput(77, 40, ErrorMessage.USER_PHONE, RegularExpression.USER_PHONE); // 전화번호 01x-xxxx-xxxx
            if (phoneNumber == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;
            address = validInput.EnterInput(82, 41, ErrorMessage.USER_ADDRESS, RegularExpression.USER_ADDRESS);// 주소  
            if (address == Constants.INPUT_BACK)
                return Constants.isREGISTER_FAIL;

            // 광역지방자치단체 + (기초지방자치단체) + (시 군 구) + (읍 면) + (도로명) + (건물번호)
            // ex) 경기도 + 수원시 + 영통구 + " " + 영통로+124
            // ex) 서울특별시+ 강남구 +" "+ " "+ 남부순환로 + 지하2744
            // ex) 서울특별시 +" "+ 구로구+ " " +경인로248-29

            userDAO.InsertUserData(id, password, name, age, phoneNumber, address); // 회원Data에 추가

            mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "유저", id, "회원가입"); // 로그기록
            Console.Clear();
            userModeUI.PrintSuccessRegister(); // 회원가입성공 UI

            while (Constants.isPROGRAM_ON)
            {
                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (keyInput.Key == ConsoleKey.Enter)
                    return Constants.isREGISTER_SUCCESS; // 엔터누르면 이제 뒤로돌아가짐
            }        
        }
           
    }
        
}

