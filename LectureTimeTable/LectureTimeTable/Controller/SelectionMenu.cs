using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
 
    internal class SelectionMenu
    {
        int menuNumber;
        int menu;
        int input;
        UserMenuUI userMenuUI = new UserMenuUI();
        LectureTimeUI lectureTimeUI = new LectureTimeUI();
        //LoginUI loginUI = new LoginUI();
        //Exception exceuption = new Exception();
        ConsoleKeyInfo keyInput;

        public int SelectVerticalMenu( int menuCount,string menuType) // 메뉴 선택
        {
            menuNumber = 0;
          
            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow: // 위로가기 키
                        menuNumber=SetMenuNumber(menuNumber, menuCount, "UP", menuType);
                        break;
                    case ConsoleKey.DownArrow: // 아래로가기 키
                        menuNumber=SetMenuNumber(menuNumber, menuCount, "DOWN", menuType);
                        break;
                    case ConsoleKey.Enter: // 메뉴선택
                        return (menuNumber % menuCount) + 1;
                    case ConsoleKey.Escape: // 뒤로가기
                        return Constant.STOP;
                }
            }
        }
        private int SetMenuNumber(int menuNumber,int menuCount, string keyType,string menuType) // 방향키 입력할때마다 menuCount변경
        {
            input = menuNumber;
            if (keyType == "UP") { input--; }
            else { input++; }

            if(input == -1)
                input = menuCount - 1;

            if (menuType == "UserMenu")
                userMenuUI.PrintUserMenu((input % menuCount) + 1);
            else if (menuType == "LectureTimeMenu")
                lectureTimeUI.PrintLectureTime((input % menuCount) + 1);


            return input; 
        }
    }
}
