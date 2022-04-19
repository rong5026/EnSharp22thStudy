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
        public const int BACK = -1;
        public const int LOGIN_FAIL = 0;
        public const int LOGIN_SUCCESS = 1;

        //UserMenu
        public const bool PROGRAM_ON = true;
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
        public const int MANAGE_MODE = 2;
      


        //ManagerMode  
        public const int BOOK_REGISTRATION = 4;
        public const int BOOK_UPDATE = 2;
        public const int BOOK_DELETE = 3;    
        public const int BOOK_LIST = 5;
        public const int USER_LIST = 6;

        //Login
        public const int LOGIN_INDEX = 0;

        //LibraryUI      
        public const int FIRST_TYPE = 1;

        //LibraryStart
        public const int USER_MANAGER = 1;


        public const string INPUT_EMPTY = "";
        public const bool REGISTER_FAIL = false;
        public const bool REGISTER_SUCCESS = true;

        public const bool BOOK_EXIST = true;
        public const bool BOOK_NOT_EXIST = false;
        public const string BACKMENU = "back";



    }
}
