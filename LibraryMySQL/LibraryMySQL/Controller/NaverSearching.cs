using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LibraryMySQL
{
    internal class NaverSearching
    {

        AdminModeUI adminModeUI = new AdminModeUI();
        ValidInput validInput = new ValidInput();
        ConsoleKeyInfo keyInput;
        private string name;
        private string bookCount;
        public void SearchInNaver()
        {

            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
                adminModeUI.PrtinInputNaverBook("입력하기"); //책 , 수량 입력

                name = validInput.EnterBookSearch(16, 1, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 책이름 입력
                bookCount = validInput.EnterInput(16, 2, ErrorMessage.BOOK_SEARCHING_COUNT, RegularExpression.BOOK_SEARCHING_COUNT); // 수량입력

                Console.SetCursorPosition(0, 5);
                SearchNaverBook(Convert.ToInt32(bookCount), name);

                Console.CursorVisible = Constants.isNONVISIBLE;

                adminModeUI.PrtinInputNaverBook("다시 입력하기"); //책 , 수량 입력
                while (Constants.isPROGRAM_ON)
                {
                    keyInput = Console.ReadKey(Constants.KEY_INPUT);
                    if (keyInput.Key == ConsoleKey.Escape)
                        return; // ESC 누르면 뒤로가기 
                    else if (keyInput.Key == ConsoleKey.Enter)
                        break;
                }
            }
        }
        public List<BookVO> SearchNaverBook(int displayCount, string content )
        {
           

            string display = Convert.ToString(displayCount); // 검색할 책 수량
            string query = content; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book?query=" + query + "&display=" + display; // 결과가 JSON 포맷

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";

            request.Headers.Add("X-Naver-Client-Id", "Yf8bYtZNXXeGGbdZZBHZ"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "xdMUgPn89d");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            List<BookVO> bookVOs = new List<BookVO>();

            var json = JObject.Parse(text);
            var items = json["items"];

            for (int index = 0; index < items.Count(); index++)
            {
                BookVO book = new BookVO();
                book.Name = items[index]["title"].ToString().Replace("<b>", "").Replace("</b>","");
                book.Author = items[index]["author"].ToString();
                book.Publisher = items[index]["publisher"].ToString();
                book.BookCount = 10;
                book.Price = Convert.ToInt32(items[index]["price"].ToString());
                book.Date = items[index]["pubdate"].ToString();

                adminModeUI.PrintNaverBookList(items[index]["isbn"].ToString(), book.Name, book.Author, book.Price, book.Publisher, book.Date, items[index]["description"].ToString().Replace("<b>", "").Replace("</b>", ""));
                bookVOs.Add(book);
            }
            Console.SetCursorPosition(0, 0);


            response.Close();
            reader.Close();
            return bookVOs;


         
        }
       
    }
}
