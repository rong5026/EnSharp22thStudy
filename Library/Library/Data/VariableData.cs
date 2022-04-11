using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class VariableData
    {
        ConsoleKeyInfo keyInput;
        public LibraryUI UI;
        public UserModeUI UserModeUI;
        public ValidInput validInput;
        public LoginedUser loginUser;
        public SelectionMode mode;
        public UserMode userMode;
        public ManagerMode managerMode;
        public UserVO user;
        public BookVO bookVO;
        public ManagerModeUI ManagerUI;
        public BookSearching book;
        public UserModeUI UserUI;
        public UserMenu userMenu;
        public Login login;
        public Register register;

        
        public VariableData()
        {
           UI = new LibraryUI();
           UserModeUI = new UserModeUI();          
           validInput = new ValidInput();
           loginUser = new LoginedUser();
           mode = new SelectionMode();
           userMode = new UserMode();
           managerMode = new ManagerMode();
           user = new UserVO();
           bookVO = new BookVO();
           ManagerUI = new ManagerModeUI();
           book = new BookSearching();
           UserUI = new UserModeUI();
           userMenu = new UserMenu();
           login = new Login();
           register = new Register();
        }
        
    }
}
