using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class Constants
    {
        //UserMode
        public const int LOGIN_REGISTER = 2;
        public const int LOGIN_MODE = 1;
        public const int REGISTER_MODE = 2;
        public const int STOP = -1;
        public const int RESTART = 1;
        public const int BACK = -1;
        public const int LOGIN_FAIL = 0;
        public const int LOGIN_SUCCESS = 1;

        //UserMenu
        public const bool isPROGRAM_ON = true;
        public const int BOOK_SEARCH = 1;
        public const int BOOK_RENT = 2;
        public const int BOOK_BORROW_LIST = 3;
        public const int BOOK_RETURN = 4;
        public const int BOOK_RETRUN_HISTORY = 5;
        public const int USER_EDIT = 6;
        public const int DELETE = 7;
        public const int EXIT = -1;

        //SelectionMode
        public const int FIND_BOOK = 1;
        public const int USER_MODE = 1;
        public const int ADMIN_MODE = 2;
      


        //AdminMode  
        public const int BOOK_ADD = 2;
        public const int BOOK_DELETE = 3;
        public const int BOOK_EDIT = 4;    
        public const int USER_CARE = 5;
        public const int TOTAL_USER_RENTBOOK = 6;

        //Login
        public const int LOGIN_INDEX = 0;

        //LibraryUI      
        public const int FIRST_TYPE = 1;

        //LibraryStart
        public const int USER_MANAGER = 1;


        public const string INPUT_EMPTY = "";
        public const string INPUT_BACK = "-1";
        public const bool isREGISTER_FAIL = false;
        public const bool isREGISTER_SUCCESS = true;
        public const bool isDELETE_ID_SUCCESS = true;
        public const bool isDELETE_ID_FAIL = false;
        public const bool isRENTBOOK_EXIST = true;
        public const bool isRENTBOOK_NOT_EXIST = false;


        public const string BACKMENU = "back";


        //EditUserData
        public const int USER_ID = 1;
        public const int USER_PW = 2;
        public const int USER_NAME = 3;
        public const int USER_AGE = 4;
        public const int USER_PHONE = 5;
        public const int USER_ADDRESS = 6;
        public const int EDIT = 7;


        public const int BOOK_EXIST = 1;
        public const int BOOK_NOT_EXIST = 0;


        //EditBookData
        public const int BOOK_NAME = 1;
        public const int BOOK_AUTHOR = 2;
        public const int BOOK_PUBLISHER = 3;
        public const int BOOK_COUNT = 4;
        public const int BOOK_PRICE = 5;
        public const int BOOK_DATE = 6;

        public const int USER_EXIST = 1;
        public const int USER_NOT_EXIST = 0;


        public const bool isNONVISIBLE = false;
        public const bool KEY_INPUT = true;
        public const bool NON_INPUT = false;

    }
}
