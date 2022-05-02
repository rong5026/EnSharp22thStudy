using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class ErrorMessage
    {
       
        // 에러메시지
        public const string ID = "숫자+영어 8~15글자를 입력해주세요!";
        public const string ID_EXIST = "기존 회원과 중복되는 ID입니다!";
        public const string PASSWORD= "숫자+영어 8~15글자를 입력해주세요!";
        public const string PASSWORD_NO_CORRECT = "입력하신 비밀번호와 일치하지 않습니다!";
        public const string USER_NAME = "영어, 한글 1글자 이상 입력해주세요!";
        public const string USER_AGE = "0~199까지 수를 입력해주세요!";
        public const string USER_PHONE = "01x-xxxx-xxxx 형식에 맞게 입력해주세요!";
        public const string USER_ADDRESS = "주소형식에 맞게 입력해주세요!";
        public const string USER_NOT_EXIST = "존재하지 않는 유저ID 입니다!";
        public const string USER_EXIST_RENT_BOOK = "대출 중인 도서가 있어 삭제가 불가능합니다!";
        //책검색
        public const string BOOK_SEARCH = "영어,한글,숫자,?,!,+,- 중 1개이상 입력해주세요!";

        //책이름 에러
        public const string BOOK_ID = "1~999범위 안의 수를 입력해주세요!";
        public const string BOOK_EXIST = "이미 등록되어 있는 책 이름입니다!";
        public const string BOOK_NOT_EXIST = "등록되어 있지 않은 책ID 입니다!";
        public const string BOOK_NOT_EXIST_IN_LIST = "검색된 리스트에 존재하지 않는 ID입니다";
        public const string BOOK_NAME = "영어,한글,숫자,?,!,+,- 중 1개이상 입력해주세요!";    
        public const string BOOK_AUTHOR = "영어,한글 1글자 이상입력해주세요!";
        public const string BOOK_PUBISHER = "영어,한글,숫자 1글자 이상 입력해주세요!";
        public const string BOOK_COUNT = "1~999 범위 내에서 입력해주세요!";
        public const string BOOK_PRICE = "1~9999999 범위 내에서 입력해주세요!";
        public const string BOOK_DATE = "19xx or 20xx-xx-xx 형식으로 입력해주세요!";

        //naver
        public const string BOOK_SEARCHING_COUNT = "1~100사이의 수를 입력해주세요!";
    }
}
