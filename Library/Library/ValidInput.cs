using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library
{
    internal class ValidInput
    {
 
        string stringInput;
        int integerInput;
        bool check;

        string id;
        string passoword;
        string repassword;
        string idPassword;
        string name;
        string age;
        string phoneNumber;
        string address;

        public string EnterIdOrPassword(int x,int y) // 좌표
        {
           
            Console.SetCursorPosition(x, y);
            idPassword = Console.ReadLine();
            if (idPassword != null)
                check = Regex.IsMatch(idPassword, @"^[0-9a-zA-Z]{8,15}$"); // 숫자 영어 8~15글자
            if (!check)             
                return EnterIdOrPassword(x, y);           
                          
            return idPassword;
            
        }
       
        public string EnterId(List<UserVO> list,int x, int y)
        {
            id = EnterIdOrPassword(x, y);

            for(int index = 0; index < list.Count; index++)
            {
                if(list[index].Id == id)
                    return EnterId(list,x,y);
            }

            return id;

        }
        public string EnterRepassword(string password,int x,int y)
        {
            repassword = EnterIdOrPassword(x, y);

            if(repassword != password)
                return EnterRepassword(password,x,y);
            else
                return repassword;
        }


        public string EnterUserName() // user이름 예외검사
        {
            Console.SetCursorPosition(41, 10);
            name = Console.ReadLine();
            if (name != null)
                check = Regex.IsMatch(name, @"^[a-zA-Zㄱ-ㅎ가-힣]{2,}$"); // 영어,한글 2글자이상
            if (!check)
                return EnterUserName();
            return name;

        }
        public string EnterUserAge() // 나이 예외검사
        {
            Console.SetCursorPosition(39, 11);
            age = Console.ReadLine();
            if (age != null)
                check = Regex.IsMatch(age, @"^1?[0-9]?[0-9]$"); // 0~ 199
            if (!check)
                return EnterUserAge();
            return age;

           
        }
        public string EnterUserPhoneNumber() // 휴대폰번호 예외검사
        {
            Console.SetCursorPosition(41, 12);
            phoneNumber = Console.ReadLine();
            if (phoneNumber != null)
                check = Regex.IsMatch(phoneNumber, @"01([0-9]{1})-([0-9]{4})-([0-9]{4})$"); // 01로 시작0~9숫자중 한개 오고 0~9 숫자 4개-0~9 숫자4개
            if (!check)
                return EnterUserPhoneNumber();
            return phoneNumber;
           
        }
        public string EnterUserAddress() // 주소 예외검사.
        {
            Console.SetCursorPosition(38, 13);
            address = Console.ReadLine();
            if (address != null)
                check = Regex.IsMatch(address, @"[ㄱ-ㅎ가-힣]{3,}$"); //한글+숫자 주소 최소 3단어 이상
            if (!check)
                return EnterUserAddress();
            return phoneNumber;
        }
        
        /////////////////////////////////////// 책 관련 입력
        public string EnterBookName() // 책이름 
        {
            Console.SetCursorPosition(18, 1);
            name = Console.ReadLine();
            if (name == "p")
                return null;
           // if (name != null)
              //  check = Regex.IsMatch(name, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어,한글 1글자이상
           // if (!check)
                //return EnterUserName();
            return name;

        }
        public string EnterAuthor() // 저자이름
        {
            Console.SetCursorPosition(19, 2);
            name = Console.ReadLine();
            if (name == "p")
                return null;
           //if (name != null)
              //  check = Regex.IsMatch(name, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어,한글 1글자이상
           // if (!check)
               // return EnterUserName();
            return name;

        }
        public string EnterBookPublisher()// 출판사
        {
            Console.SetCursorPosition(18, 3);
            name = Console.ReadLine();
            if (name == "p")
                return null;
          //  if (name != null)
               // check = Regex.IsMatch(name, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어,한글 2글자이상
           // if (!check)
               // return EnterUserName();
            return name;
        }
        
    }
}
