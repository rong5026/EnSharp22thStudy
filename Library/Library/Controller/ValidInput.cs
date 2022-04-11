﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library
{
    internal class ValidInput
    {

        UserModeUI UserUI = new UserModeUI();
        bool check;
      
        string idPassword;
      

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
       
        public string EnterId(int x, int y) // 회원가입할때 id가 같은게 있으면 안됨
        {
            InputVO.id = EnterIdOrPassword(x, y);

            for(int index = 0; index <LibraryStart.userList.Count ; index++)
            {
                if (LibraryStart.userList[index].Id == InputVO.id)
                {
                    UserUI.PrintMessage(x, y, "기존 회원과 중복되는 ID입니다! 다른 ID를 입력해주세요.");
                   
                    return EnterId(x, y);
                }
            }

            return InputVO.id;

        }
        public string EnterRepassword(string password,int x,int y)
        {
            InputVO.repassword = EnterIdOrPassword(x, y);

            if (InputVO.repassword != password)
            {
                UserUI.PrintMessage(x, y, "입력하신 비밀번호와 일치하지 않습니다! 다시입력해주세요");
              
                return EnterRepassword(password, x, y);
            }
            else
                return InputVO.repassword;
        }


        public string EnterUserName(int x, int y) // user이름 예외검사
        {
            Console.SetCursorPosition(x, y);
            InputVO.name = Console.ReadLine();
            if (InputVO.name != null)
                check = Regex.IsMatch(InputVO.name, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어,한글,숫자 1글자이상
            if (!check)
            {
                UserUI.PrintMessage(x, y, "영어,한글,숫자 1글자이상 입력해주세요!");
                return EnterUserName(x, y);
            }
            return InputVO.name;

        }
        public string EnterUserAge(int x, int y) // 나이 예외검사
        {
            Console.SetCursorPosition(x, y);
            InputVO.age = Console.ReadLine();
            if (InputVO.age != null)             
                   check = Regex.IsMatch(InputVO.age, @"^1?[0-9]?[0-9]$"); // 0~ 199
            if (!check)
            {
                UserUI.PrintMessage(x, y, "0~199까지 수를 입력해주세요!");
                return EnterUserAge(x, y);

            }
            return InputVO.age;

           
        }
        public string EnterUserPhoneNumber(int x, int y) // 휴대폰번호 예외검사
        {
            Console.SetCursorPosition(x, y);
            InputVO.phoneNumber = Console.ReadLine();
            if (InputVO.phoneNumber != null)
                check = Regex.IsMatch(InputVO.phoneNumber, @"01([0-9]{1})-([0-9]{4})-([0-9]{4})$"); // 01로 시작0~9숫자중 한개 오고 0~9 숫자 4개-0~9 숫자4개
            if (!check)
            {
                UserUI.PrintMessage(x, y, "01x-xxxx-xxxx 형식에 맞게 입력해주세요!");
                return EnterUserPhoneNumber(x, y);
            }
            return InputVO.phoneNumber;
           
        }
        public string EnterUserAddress(int x, int y) // 주소 예외검사.
        {
            Console.SetCursorPosition(x, y);
            InputVO.address = Console.ReadLine();
            if (InputVO.address != null)
                check = Regex.IsMatch(InputVO.address, @"[ㄱ-ㅎ가-힣]{3,5}\s[ㄱ-ㅎ가-힣]{3,5}?[ㄱ-ㅎ가-힣]{3,5}?
[ㄱ-ㅎ가-힣]{3,5}?[ㄱ-ㅎ가-힣0-9]{3,}[ㄱ-ㅎ가-힣0-9]{0,}?-?[0-9]{0,}?[ㄱ-ㅎ가-힣]{0,}?[0-9]{0,}?[ㄱ-ㅎ가-힣]?$"); //한글+숫자 주소 최소 3단어 이상
            if (!check)
                return EnterUserAddress(x,y);
            return InputVO.address;
        }



        ///책 관련 입력
        ///
        public string EnterBookId(int x, int y) // 책번호
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();
            if (InputVO.name == "p")
                return null;
            if (InputVO.name != null) 
                check = Regex.IsMatch(InputVO.name, @"^[1-9]?[0-9]?[0-9]$"); //0~999까지의 수
            if (!check)
            {
                UserUI.PrintMessage(x, y, "0~999범위 안의 수를 입력해주세요!");
                return EnterBookId(x, y);
            }
            return InputVO.name;

        }
        public string EnterBookName(int x,int y) // 책이름 
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();
            if (InputVO.name == "p")
                return null;
            if (InputVO.name != null)
                return InputVO.name;
            else
                return null;

        }
        public string EnterAuthor(int x, int y) // 저자이름
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();
            if (InputVO.name == "p")
                return null;
            if (InputVO.name != null)
              check = Regex.IsMatch(InputVO.name, @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"); // 영어,한글 1글자이상
            if (!check)
            {
                UserUI.PrintMessage(x, y, "영어,한글 1글자 이상입력해주세요!");
                return EnterAuthor(x, y);
            }
            return InputVO.name;

        }
        public string EnterBookPublisher(int x, int y)// 출판사
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.name = Console.ReadLine();
            if (InputVO.name == "p")
                return null;
            if (InputVO.name != null)

                check = Regex.IsMatch(InputVO.name, @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"); // 영어,한글,숫자 1글자이상
            if (!check)
            {
                UserUI.PrintMessage(x, y, "영어,한글,숫자 1글자 이상 입력해주세요!");
                return EnterBookPublisher(x, y);
            }
            return InputVO.name;
        }

 
        public string EnterBookCount(int x, int y) // 책 수량
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.id = Console.ReadLine();
            if (InputVO.id != null)
                check = Regex.IsMatch(InputVO.id, @"^[1-9]+[0-9]?[0-9]?$"); //  1~999
            if (!check)
            {
                UserUI.PrintMessage(x, y, "1~999 범위 내에서 입력해주세요!");
                return EnterBookCount(x, y);
            }
            return InputVO.id;
        }
        public string EnterBookPrice(int x, int y) // 책 가격
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.id = Console.ReadLine();
            if (InputVO.id != null)
                check = Regex.IsMatch(InputVO.id, @"^[1-9]+[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?$"); //   1 ~999개
            if (!check)
            {
                UserUI.PrintMessage(x, y, "1~9999999 범위 내에서 입력해주세요!");
                return EnterBookCount(x, y);
            }
            return InputVO.id;
        }
        public string EnterBookDate(int x, int y) // 책 출시 날짜
        {
            Console.SetCursorPosition(x, y); // 커서이동
            InputVO.id = Console.ReadLine();
            if (InputVO.id != null)
                check = Regex.IsMatch(InputVO.id, @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[1-2][0-9]|3[0-1])$"); //2010-04-23
            if (!check)
            {
                UserUI.PrintMessage(x, y, "19xx or 20xx-02-03 범위 내에서 입력해주세요!");
                return EnterBookCount(x, y);
            }
            return InputVO.id;
        }

    }
}
