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
        BookDAO mySQlData = new BookDAO();
        UserDAO userDAO = new UserDAO();
        ConsoleKeyInfo keyInput;
      
        private string name;
        private string bookCount;

        public void SearchInNaver(string type)
        {
            List<BookDTO> bookList;
           

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

                if (type == "AddAdminBook") {
                    if (AddAdminNaverBook(bookList) == Constants.BACKMENU)
                        return;
                }
                else
                {
                    if (AddUserNaverBook(bookList) == Constants.BACKMENU)
                        return;
                }

                               
                    
            }
        }

        private string AddAdminNaverBook(List<BookDTO> bookList) // 관리자 책 추가 
        {
            List<BookDTO> validBookList;
            Console.SetCursorPosition(0, 0);
            adminModeUI.PrtinInputNaverBook("도서 추가하기(ISBN일부만 입력해도 추가가 됩니다)", "뒤로가기"); //책 , 수량 입력

            keyInput = Console.ReadKey(Constants.KEY_INPUT);
            if (keyInput.Key == ConsoleKey.Escape)
                return Constants.BACKMENU; // ESC 누르면 뒤로가기 
            else if (keyInput.Key == ConsoleKey.Enter)
            {

                while (Constants.isPROGRAM_ON)
                {
                    Console.SetCursorPosition(0, 0);
                    adminModeUI.PrintInputNaverISBN("책 ISBN", "확인하기 (ISBN일부만 입력해도 추가가 됩니다)", "뒤로가기");

                    string isbn = validInput.EnterBookISBN(16, 1, bookList); // 책 isbn
                    if (isbn == Constants.INPUT_BACK)
                        break;


                    validBookList = GetSameIsbnBook(isbn, bookList); // isbn이 같은 책의 정보를 가져옴

                    if (validBookList == null)
                    {
                        break;
                    }
                    for (int index = 0; index < validBookList.Count; index++)
                    {
                        mySQlData.InsertBook(validBookList[index]); // 책 추가
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", validBookList[index].Name, "네이버도서추가"); // 로그저장
                    }

                    Console.SetCursorPosition(0, 0);
                    adminModeUI.PrintInputNaverISBN("입력값을 포함한 ISBN을 가진 책 전부 추가성공!", "다시추가하기", "뒤로가기");

                    while (Constants.isPROGRAM_ON)
                    {
                        keyInput = Console.ReadKey(Constants.KEY_INPUT);
                        if (keyInput.Key == ConsoleKey.Escape)
                            return Constants.BACKMENU; // ESC 누르면 뒤로가기 
                        else if (keyInput.Key == ConsoleKey.Enter)
                            break;


                    }
                }

            }

            return Constants.BACKMENU;
        }
        private string AddUserNaverBook(List<BookDTO> bookList) // 유저 책 추가 요청 
        {
            List<BookDTO> validBookList;
            Console.SetCursorPosition(0, 0);
            adminModeUI.PrtinInputNaverBook("도서 신청하기(ISBN일부만 입력해도 신청이 됩니다)", "뒤로가기"); //책 , 수량 입력

            keyInput = Console.ReadKey(Constants.KEY_INPUT);
            if (keyInput.Key == ConsoleKey.Escape)
                return Constants.BACKMENU; // ESC 누르면 뒤로가기 
            else if (keyInput.Key == ConsoleKey.Enter)
            {

                while (Constants.isPROGRAM_ON)
                {
                    Console.SetCursorPosition(0, 0);
                    adminModeUI.PrintInputNaverISBN("책 ISBN", "확인하기 (ISBN일부만 입력해도 신청이 됩니다)", "뒤로가기");

                    string isbn = validInput.EnterUserBookISBN(16, 1, bookList); // 책 isbn
                    if (isbn == Constants.INPUT_BACK)
                        break;

                    validBookList = GetSameIsbnBook(isbn, bookList); // isbn이 같은 책의 정보를 가져옴

                    if (validBookList == null)
                        break;

                    for (int index = 0; index < validBookList.Count; index++)
                    {
                        mySQlData.InsertUserApplicationBook(validBookList[index]); // 책 추가
                        mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", validBookList[index].Name, "네이버도서신청"); // 로그저장
                    }

                    Console.SetCursorPosition(0, 0);
                    adminModeUI.PrintInputNaverISBN("입력값을 포함한 ISBN을 가진 책 전부 신청성공!", "다시신청하기", "뒤로가기");

                    while (Constants.isPROGRAM_ON)
                    {
                        keyInput = Console.ReadKey(Constants.KEY_INPUT);
                        if (keyInput.Key == ConsoleKey.Escape)
                            return Constants.BACKMENU; // ESC 누르면 뒤로가기 
                        else if (keyInput.Key == ConsoleKey.Enter)
                            break;


                    }
                }

            }

            return Constants.BACKMENU;
        }
        public List<BookDTO> GetSameIsbnBook(string isbn, List<BookDTO> list) // isbn을 포함하는 모든 책 리턴
        {
            List<BookDTO> validBookList = new List<BookDTO>();

            for(int index = 0; index < list.Count; index++)
            {
                if(list[index].Isbn.Contains(isbn))
                    validBookList.Add(list[index]);
            }

            return validBookList;
        }
        public List<BookDTO> SearchNaverBook(int displayCount, string content ) // 네이버 책 검색
        {
            UserDTO userDTO;
            mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", content, "네이버 검색"); // 로그저장
            string display = Convert.ToString(displayCount); // 검색할 책 수량
            string query = content; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book?query=" + query + "&display=" + display; // 결과가 JSON 포맷


            userDTO = userDAO.GetNaverAPI(); // 데이터베이스에서 id, secret가져오기
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";

            request.Headers.Add("X-Naver-Client-Id", userDTO.Id); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", userDTO.Password);       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();

                List<BookDTO> bookVOs = new List<BookDTO>();

                JObject json = JObject.Parse(text);
                var items = json["items"];

                for (int index = 0; index < items.Count(); index++)
                {
                    BookDTO book = new BookDTO(0,
                        items[index]["title"].ToString().Replace("<b>", "").Replace("</b>", ""),
                        items[index]["author"].ToString(),
                        items[index]["publisher"].ToString().Replace("<b>", "").Replace("</b>", ""),
                        10, Convert.ToInt32(items[index]["price"].ToString()), items[index]["pubdate"].ToString(),
                        null, null,
                        items[index]["isbn"].ToString(), items[index]["description"].ToString().Replace("<b>", "").Replace("</b>", "")
                        );

                    adminModeUI.PrintNaverBookList(items[index]["isbn"].ToString(), book.Name, book.Author, book.Price, book.Publisher, book.Date, book.Information);
                    bookVOs.Add(book);
                }
                Console.SetCursorPosition(0, 0);
                response.Close();

                return bookVOs;
            }
            else
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Error 발생=" + status);
            }

            return null;




        }
       
    }
}
