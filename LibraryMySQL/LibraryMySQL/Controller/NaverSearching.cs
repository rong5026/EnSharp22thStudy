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
        public List<BookVO> SearchInNaver(int displayCount, string content )
        {
            string display = Convert.ToString(displayCount);
            string query = content; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book?query=" + query + "&display=" + display; // 결과가 JSON 포맷

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";

            request.Headers.Add("X-Naver-Client-Id", "Yf8bYtZNXXeGGbdZZBHZ"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "xdMUgPn89d");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //오류 상태          
            //string status = response.StatusCode.ToString();


            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            List<BookVO> bookVOs = new List<BookVO>();

            var json = JObject.Parse(text);
            var items = json["items"];

            for (int index = 0; index < items.Count(); index++)
            {
                BookVO book = new BookVO();
                book.Name = items[index]["title"].ToString().Replace("<b>","");
                book.Author = items[index]["author"].ToString();
                book.Publisher = items[index]["publisher"].ToString();
                book.BookCount = 10;
                book.Price = Convert.ToInt32(items[index]["price"].ToString());
                book.Date = items[index]["pubdate"].ToString();
                bookVOs.Add(book);
            }

            return bookVOs;


         
        }
       
    }
}
