﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL { 
    internal class BookSearching
    {

        LibraryUI libraryUI = new LibraryUI();
        public void SearchBook() // 책 검색
        {

            /*
            Console.Clear();
            libraryUI.PrintSearchBook();
            libraryUI.PrintBookList(null, null, null); //  전체 북리스트 출력.
            Console.SetCursorPosition(18, 1); // 커서이동

            VariableData.keyInput = Console.ReadKey(true);
            if (VariableData.keyInput.Key == ConsoleKey.Escape)
                return; // ESC 누르면 뒤로가기 
            else
            {

                name = VariableData.validInput.EnterBookName(18, 1); // 영어,한글 1글자이상
                author = VariableData.validInput.EnterAuthor(19, 2); // 영어,한글 1글자 이상
                publisher = VariableData.validInput.EnterBookPublisher(18, 3); // // 영어,한글, 숫자 1글자 이상

                Console.Clear();
                VariableData.UI.PrintSearchBook();
                VariableData.UI.PrintBookList(name, author, publisher);

                VariableData.keyInput = Console.ReadKey(true);
                if (VariableData.keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 
            */
            }
        }

    }
}
