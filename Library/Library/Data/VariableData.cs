using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class VariableData
    {
        public static ConsoleKeyInfo keyInput;
        static public LibraryUI UI = new LibraryUI();
        static public UserModeUI UserModeUI = new UserModeUI();
        static public ValidInput validInput = new ValidInput();
        static public LoginedUser loginUser = new LoginedUser();
        static public SelectionMode mode = new SelectionMode();
        static public UserMode userMode = new UserMode();
        static public ManagerMode managerMode = new ManagerMode();
        static public UserVO user = new UserVO();
        static public BookVO bookVO = new BookVO();
        static public ManagerModeUI ManagerUI = new ManagerModeUI();
        static public BookSearching book = new BookSearching();
        static public UserModeUI UserUI = new UserModeUI();
        static public UserMenu userMenu = new UserMenu();
        static public Login login = new Login();
        static public Register register = new Register();


        
        
    }
}
