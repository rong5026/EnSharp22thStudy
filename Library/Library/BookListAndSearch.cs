using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BookListAndSearch
    {
        LibraryUI UI = new LibraryUI();
        ConsoleKeyInfo keyInput;

        public void SearchBook()
        {
            Console.Clear();
            UI.PrintSearchBook();
            UI.PrintBookList();
         // 18,1
           //19,2
           //18,3
            keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {
                

            }
            


        }
       



    }
}
