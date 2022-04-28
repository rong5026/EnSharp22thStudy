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
        public const string PASSWORD_NO_CORRECT = "입력하신 비밀번호와 일치하지 않습니다! 다시입력해주세요";
        public const string USER_NAME = "영어, 한글 1글자 이상 입력해주세요!";
        public const string USER_AGE = "0~199까지 수를 입력해주세요!";
        public const string USER_PHONE = "01x-xxxx-xxxx 형식에 맞게 입력해주세요!";
        public const string USER_ADDRESS = "주소형식에 맞게 입력해주세요!";
      
    }
}
