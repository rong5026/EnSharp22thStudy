using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class LibraryStart
    {
        LibraryUI UI = new LibraryUI();
        const Boolean PROGRAM_ON = true;

        const int USER_MODE = 1;
        const int MANAGE_MODE = 2;
        const int STOP = -1;
        int menuNumber;

   
        ConsoleKeyInfo keyInput;


        public void StartProgram()
        {
            UI.PrintMainUI();
            Console.SetWindowSize(125, 40);

            while (PROGRAM_ON)
            {
                menuNumber = SelectMode();

                switch (menuNumber)
                {
                    case USER_MODE:
                        break;
                    case MANAGE_MODE:
                        break;
                    case STOP:
                        UI.PrintProgramStop();
                        return;
                        break;

                }

            }
            
        }

        public int SelectMode()
        {
            UI.PrintSelectMainUI(USER_MODE);
            while (PROGRAM_ON)
            {                       
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {              
                    case ConsoleKey.UpArrow:
                        menuNumber = USER_MODE;
                        UI.PrintSelectMainUI(USER_MODE);
                        break;

                    case ConsoleKey.DownArrow:
                        menuNumber = MANAGE_MODE;
                        UI.PrintSelectMainUI(MANAGE_MODE);
                        break;
                    case ConsoleKey.Enter:
                        return menuNumber;
                    case ConsoleKey.Escape:
                        return STOP;
                }
            }
        }
    }
       
}
