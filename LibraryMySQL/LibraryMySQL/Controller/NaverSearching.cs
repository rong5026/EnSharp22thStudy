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
        MySQlDataConnection mySQlData = new MySQlDataConnection();
        ConsoleKeyInfo keyInput;
        private string name;
        private string bookCount;
        public void SearchInNaver()
        {
            List<BookVO> bookList;

            while (Constants.isPROGRAM_ON)
            {
                Console.Clear();
               
                adminModeUI.PrtinInputNaverBook("입력하기","뒤로가기"); //책 , 수량 입력

              
                name = validInput.EnterInput(16, 1, ErrorMessage.BOOK_SEARCH, RegularExpression.BOOK_SEARCH); // 책이름 입력
                if (name == Constants.INPUT_BACK)
                    return;
                bookCount = validInput.EnterInput(16, 2, ErrorMessage.BOOK_SEARCHING_COUNT, RegularExpression.BOOK_SEARCHING_COUNT); // 수량입력
                if (bookCount == Constants.INPUT_BACK)
                    return;

                Console.SetCursorPosition(0, 5);
                bookList = SearchNaverBook(Convert.ToInt32(bookCount), name); // 검색결과를 리스트에 넣음
                Console.CursorVisible = Constants.isNONVISIBLE;


                Console.SetCursorPosition(0, 0);
                adminModeUI.PrtinInputNaverBook("도서 추가하기", "뒤로가기"); //책 , 수량 입력

                keyInput = Console.ReadKey(Constants.KEY_INPUT);
                if (keyInput.Key == ConsoleKey.Escape)
                    return; // ESC 누르면 뒤로가기 
                else if (keyInput.Key == ConsoleKey.Enter)
                {

                    while (Constants.isPROGRAM_ON)
                    {
                        Console.SetCursorPosition(0, 0);
                        adminModeUI.PrintInputNaverISBN("책 ISBN", "확인하기", "뒤로가기");

                        string isbn = validInput.EnterBookISBN(16, 1, bookList); // 책 isbn
                        if (isbn == Constants.INPUT_BACK)
                            break;

                        BookVO bookVO = new BookVO();
                        bookVO = GetSameIsbnBook(isbn, bookList); // isbn이 같은 책의 정보를 가져옴

                        Console.WriteLine(bookVO.Information.Length);
                        Console.ReadLine();
                        mySQlData.InsertBook(bookVO); // 책 추가

                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", bookVO.Name, "네이버도서추가"); // 로그저장

                        Console.SetCursorPosition(0, 0);
                        adminModeUI.PrintInputNaverISBN("추가성공!", "다시추가하기", "뒤로가기");

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
              
            }
        }
        private BookVO GetSameIsbnBook(string isbn, List<BookVO> list)
        {
            for(int index = 0; index < list.Count; index++)
            {
                if(isbn == list[index].Isbn)
                    return list[index];
            }

            return list[0];
        }
        public List<BookVO> SearchNaverBook(int displayCount, string content )
        {

            mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", content, "네이버 검색"); // 로그저장
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
                book.Isbn = items[index]["isbn"].ToString();
                book.Information = items[index]["description"].ToString().Replace("<b>", "").Replace("</b>", "");


                adminModeUI.PrintNaverBookList(items[index]["isbn"].ToString(), book.Name, book.Author, book.Price, book.Publisher, book.Date, book.Information);
                bookVOs.Add(book);
            }
            Console.SetCursorPosition(0, 0);

          
            response.Close();
            reader.Close();
            return bookVOs;


         
        }
       
    }
}
