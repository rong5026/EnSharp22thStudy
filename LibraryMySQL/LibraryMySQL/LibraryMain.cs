using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Net;

using System.IO;
namespace LibraryMySQL
{
    internal class LibraryMain
    {        
        static void Main(string[] args)
        {
            //LibraryStart start = new LibraryStart();
            //start.StartLibrary();
            string query = "네이버 Open API"; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/blog?query=" + query; // 결과가 JSON 포맷
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "Yf8bYtZNXXeGGbdZZBHZ"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "xdMUgPn89d");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if(status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
        }
    }
}
