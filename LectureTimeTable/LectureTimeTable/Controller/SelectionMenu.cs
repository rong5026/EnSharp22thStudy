using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
 
    internal class SelectionMenu
    {

        UserMenuUI userMenuUI =new UserMenuUI();
        LectureTimeUI lectureTimeUI = new LectureTimeUI();
        InterestsLectureUI interestsLectureUI = new InterestsLectureUI();
        RegisterationLectureUI registerationLecture = new RegisterationLectureUI();
     
        ConsoleKeyInfo keyInput;
        private int menuNumber;
        private int input;

     

        public int SelectHorisionMenu(int menuCount, string menuType)
        {
            menuNumber = 0;
            while (Constants.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.RightArrow: // 오른쪽가기 키
                        menuNumber = SetMenuNumber(menuNumber, menuCount, "RIGHT", menuType);
                        break;
                    case ConsoleKey.LeftArrow: // 왼쪽가기 키
                        menuNumber = SetMenuNumber(menuNumber, menuCount, "LEFT", menuType);
                        break;
                    case ConsoleKey.Enter: // 메뉴선택
                        return (menuNumber % menuCount) + 1;
                    case ConsoleKey.Escape: // 뒤로가기
                        return Constants.STOP;
                }
            }
        }
        public int SelectVerticalMenu( int menuCount,string menuType,int menuNumber) // 수직 메뉴 선택
        {
            
          
            while (Constants.PROGRAM_ON)
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
                        return Constants.STOP;
                }
            }
        }
        private int SetMenuNumber(int menuNumber,int menuCount, string keyType,string menuType) // 방향키 입력할때마다 menuCount변경
        {
            input = menuNumber;
      
            if (keyType == "UP" || keyType == "LEFT")
                input--;
            else
                input++;


            if(input == -1)
                input = menuCount - 1;

            switch (menuType)
            {
                case "UserMenu":                  
                    userMenuUI.PrintUserMenu((input % menuCount) + 1);
                    break;
                case "LectureTimeMenu":
                    lectureTimeUI.PrintLectureTime((input % menuCount) + 1);
                    break;
                case "LectureDepartment":
                    lectureTimeUI.PrintLectureDepartment((input % menuCount) + 1);
                    break;
                case "LectureDivision":
                    lectureTimeUI.PrintLetureDivision((input % menuCount) + 1);
                    break;
                case "LectureClass":
                    lectureTimeUI.PrintLectureClass((input % menuCount) + 1);
                    break;
                case "InterestLecture":
                    interestsLectureUI.PrintInterestsLectureMenu((input % menuCount) + 1);
                    break;
                case "InterestLectureSearch":
                    interestsLectureUI.PrintInterestLecture((input % menuCount) + 1); // 관심과목 
                    break;
                case "RegisterLecture":
                    registerationLecture.PrintRegisterationLectureMenu((input % menuCount) + 1);
                    break;
                case "RegisterLectureSearch":
                    registerationLecture.PrintRegisterationLecture((input % menuCount) + 1);
                    break;



            }
           


            return input; 
        }
    }
}
