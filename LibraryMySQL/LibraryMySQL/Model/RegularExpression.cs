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


    }
}
