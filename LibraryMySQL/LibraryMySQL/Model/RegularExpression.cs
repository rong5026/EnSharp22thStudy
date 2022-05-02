using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class RegularExpression
    {
        public const string KOREAN = @"^[ㄱ-ㅎ가-힣]{1,}$";
        public const string ID = @"^[0-9a-zA-Z]{8,15}$";
        public const string PASSWORD = @"^[0-9a-zA-Z]{8,15}$";
        public const string USER_NAME = @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$";
        public const string USER_AGE = @"^1?[0-9]?[0-9]$";
        public const string USER_PHONE = @"01([0-9]{1})-([0-9]{4})-([0-9]{4})$";
        public const string USER_ADDRESS = @"[ㄱ-ㅎ가-힣]{3,5}\s{0,1}[ㄱ-ㅎ가-힣]{3,5}\s{0,1}?([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣0-9]{2,}\s{0,1}?-?[0-9]{0,}?[ㄱ-ㅎ가-힣]{0,})?([
ㄱ-ㅎ가-힣0-9]{1,}\s{0,1}?-?[0-9]{0,})?$";
        public const string USER_NOT_EXIST = @"^[0-9a-zA-Z]{8,15}$";
        public const string USER_NUMBER_NOT_EXIST = @"^[1-9][0-9]?[0-9]?$";// 1~ 999
        //책 검색
        public const string BOOK_SEARCH = @"^([a-zA-Zㄱ-ㅎ가-힣0-9?]{1,}\s{0,}){0,}[a-zA-Zㄱ-ㅎ가-힣0-9?]{1,}$"; // 영어 한글 ?1개 이상
        //관리자모드

        public const string BOOK_ID = @"^[1-9][0-9]?[0-9]?$"; // 1~ 999
        public const string BOOK_NAME = @"^([a-zA-Zㄱ-ㅎ가-힣0-9!?+-]{1,}\s{0,}){0,}[a-zA-Zㄱ-ㅎ가-힣0-9!?+-]{1,}$";  // 영어 , 한글, 숫자,?!+- 1글자 이상
        public const string BOOK_AUTHOR = @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"; // 영어,한글 1글자 이상
        public const string BOOK_PUBISHER = @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"; // 영어, 한글, 숫자 1글자 이상
        public const string BOOK_COUNT = @"^[1-9][0-9]?[0-9]?$"; // 1~999 
        public const string BOOK_PRICE = @"^[1-9][0-9]{0,6}?$";//   1 ~9999999개
        public const string BOOK_DATE = @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[1-2][0-9]|3[0-1])$"; 
        public const string BOOK_SEARCHING_COUNT = @"^[1-9]?[0-9]{1}$|^100$"; // 1~100 사이의 수

        public const string BOOK_ISBN = @"^[0-9]{9}[a-zA-Z0-9]{1}\s[0-9]{13}$";  //정수9 + 영어 or 정수1 + 공백 + 정수13
        public const string BOOK_INFORMATION = @"^[a-zA-Z0-9ㄱ-ㅎ가-힣\s@#$%^&~,.<>*!?+-]{1,}$";               //"최소1개의 문자(공백포함)";

        public const string LOG_ID = @"^[1-9][0-9]{0,4}?$"; // 1 ~ 99999번
    }
}
