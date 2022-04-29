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
        public const string USER_ADDRESS = @"[ㄱ-ㅎ가-힣]{3,5}\s{0,1}[ㄱ-ㅎ가-힣]{3,5}\s{0,1}?([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣]{3,5}\s{0,1})?([ㄱ-ㅎ가-힣0-9]{2,}\s{0,1}?-?[0-9]{0,}?[ㄱ-ㅎ가-힣]{0,})?([ㄱ-ㅎ가-힣0-9]{1,}\s{0,1}?-?[0-9]{0,})?$";

        //책 검색
        public const string BOOK_SEARCH = @"^[a-zA-Zㄱ-ㅎ가-힣0-9\s]{1,}?[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"; // 영어 한글 1개 이상
        //관리자모드

        public const string BOOK_ID = @"^[1-9][0-9]?[0-9]?$"; // 1~ 999
        public const string BOOK_NAME = @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$";  // 영어 , 한글, 숫자 1글자 이상
        public const string BOOK_AUTHOR = @"^[a-zA-Zㄱ-ㅎ가-힣]{1,}$"; // 영어,한글 1글자 이상
        public const string BOOK_PUBISHER = @"^[a-zA-Zㄱ-ㅎ가-힣0-9]{1,}$"; // 영어, 한글, 숫자 1글자 이상
        public const string BOOK_COUNT = @"^[1-9][0-9]?[0-9]?$"; // 1~999 
        public const string BOOK_PRICE = @"^[1-9][0-9]{0,6}?$";//   1 ~9999999개
        public const string BOOK_DATE = @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[1-2][0-9]|3[0-1])$"; 
    }
}
