using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace LibraryMySQL
{
    internal class MySQlDataConnection
    {

        private static MySQlDataConnection mysqlData;
        private UserDTO user;
        public static MySQlDataConnection Instance()
        {
            if (mysqlData == null)
                mysqlData = new MySQlDataConnection();
            return mysqlData;
        }

        public MySqlConnection ConnectMySQL()
        {

            MySqlConnection connection = new MySqlConnection("Server=" + QueryData.SERVER + "; Port=" + QueryData.PORT + ";Database=" + QueryData.DATABASE_NAME + ";Uid=" + QueryData.ID + ";Pwd=" + QueryData.PASSWROD + ";");


            return connection;
        }
     







        public bool LoginedUserRentBookCount(string userId) // 로그인한 유저의 빌린책 수
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.RENT_BOOK);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {

                if (userId == (string)table["user_id"])
                {
                    table.Close();
                    connection.Close();
                    return Constants.isRENTBOOK_EXIST;
                }
            }
            table.Close();
            connection.Close();
            return Constants.isRENTBOOK_NOT_EXIST;
        }
        public string GetUserIdFromNumber(int userNumber) // number에 해당하는 유저ID 리턴
        {
            string userId;
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_USERLIST);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                
        
                if (userNumber == (int)table["user_number"])
                {

                    userId = (string)table["user_id"];
                    table.Close();
                    connection.Close();
                    return userId;
                }
            }

          
            table.Close();
            connection.Close();
            return Constants.INPUT_EMPTY;

        }

       


        public List<BookDTO> GetBookList() // 책리스트를 리턴
        {
           
            List<BookDTO> list = new List<BookDTO>();
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_BOOKLIST);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();

   
            while (table.Read())
            {
                BookDTO book = new BookDTO();
               

                book.Id = (int)table["book_id"];
                book.Name = (string)table["book_name"];
                book.Author = (string)table["book_author"];
                book.Publisher = (string)table["book_publisher"];
                book.BookCount = (int)table["book_count"];
                book.Price = (int)table["book_price"];
                book.Date = (string)table["book_date"];
                book.Isbn = (string)table["book_isbn"];
                book.Information = (string)table["book_information"];
                list.Add(book);               
            }
            table.Close();
            connection.Close();

            return list;

        }
        
        public int ConfrimUserRentBook(int bookId)  // 유저가 이미 빌린책이면 1, 안빌린책이면 0 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.RENT_BOOK);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                if(LibraryStart.loginedUser == (string)table["user_id"] && bookId == (int)table["book_id"]) // 빌린책에 똑같은 책이 있다면
                {
                    table.Close();
                    connection.Close();                
                    return Constants.BOOK_EXIST;
                }
                       
            }
            table.Close();
            connection.Close();
     
            return Constants.BOOK_NOT_EXIST;
        }
        public void UpdateBookCount(int bookCount,int bookId) // 책 수량 수정
        {



            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.UPDATE_BOOK_COUNT, bookCount,bookId);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();
          

            connection.Close();
        }

        public int GetBookCount(int bookId) // 책의 수량을 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_BOOKLIST);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();

            while (table.Read())
            {
                if (bookId == (int)table["book_id"])                        
                    return (int)table["book_count"];
               
            }
            table.Close();
            connection.Close();
            return Constants.BACK;
        }
     

        public void GetRentBook(List<BookDTO> list,string userId) // 해당아이디의 빌린책 리스트 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.RENT_BOOK);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {

                if (userId == (string)table["user_id"])
                {
                    BookDTO book = new BookDTO();
                    book.Id = (int)table["book_id"];
                    book.Name = (string)table["book_name"];
                    book.Author = (string)table["book_author"];
                    book.Publisher = (string)table["book_publisher"];
                    book.BookCount = (int)table["book_count"];
                    book.Price = (int)table["book_price"];
                    book.Date = (string)table["book_date"];
                    book.RentTime = (string)table["book_rent_time"];
                    book.ReturnTime = (string)table["book_return_time"];
                    book.Isbn = (string)table["book_isbn"];
                    book.Information = (string)table["book_information"];
                    list.Add(book);
                }


            }
            table.Close();
            connection.Close();

        }
        public void GetReturnedBook(List<BookDTO> list) // 해당아이디의 반납책 리스트 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.RETURN_BOOK);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();

            while (table.Read())
            {

                if (LibraryStart.loginedUser == (string)table["user_id"])
                {
                    BookDTO book = new BookDTO();
                    book.Id = (int)table["book_id"];
                    book.Name = (string)table["book_name"];
                    book.Author = (string)table["book_author"];
                    book.Publisher = (string)table["book_publisher"];
                    book.BookCount = (int)table["book_count"];
                    book.Price = (int)table["book_price"];
                    book.Date = (string)table["book_date"];
                    book.ReturnTime = (string)table["book_return_time"];
                    book.Isbn = (string)table["book_isbn"];
                    book.Information = (string)table["book_information"];
                    list.Add(book);
                }


            }
            table.Close();
            connection.Close();

        }
        public void DeleteRentBook(int bookId) // 로그인된 유저와 bookid가 같을때 삭제
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_RENT_BOOK, LibraryStart.loginedUser, bookId);
         

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void InsertReturnBook(string returnTime, BookDTO bookVO) // 반납책 저장
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_RETURN_BOOK, LibraryStart.loginedUser, bookVO.Id, bookVO.Name, bookVO.Author, bookVO.Publisher, bookVO.BookCount, bookVO.Price, bookVO.Date, returnTime,bookVO.Isbn,bookVO.Information);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public void InsertRentBook(string rentTime, string returnTime, BookDTO bookVO) // 빌린책 저장
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_RENT_BOOK, LibraryStart.loginedUser, bookVO.Id, bookVO.Name, bookVO.Author, bookVO.Publisher, bookVO.BookCount, bookVO.Price, bookVO.Date, rentTime, returnTime, bookVO.Isbn, bookVO.Information);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();



            connection.Close();
        }
        public void InsertBook(BookDTO bookVO) // 책 등록
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_BOOK, bookVO.Name,bookVO.Author,bookVO.Publisher,bookVO.BookCount,bookVO.Price,bookVO.Date,bookVO.Isbn,bookVO.Information);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
        
        public void DeleteBook(int bookId) // 책 삭제
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_BOOK, bookId);


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void GetSelectedBook(BookDTO bookVO, int bookId) // 수정하고자 하는 책 정보 리턴
        {

            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_BOOKLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                if (bookId == (int)table["book_id"])
                {
                    bookVO.Id = (int)table["book_id"];
                    bookVO.Name= (string)table["book_name"];
                    bookVO.Author = (string)table["book_author"];
                    bookVO.Publisher = (string)table["book_publisher"];
                    bookVO.BookCount = (int)table["book_count"];
                    bookVO.Price = (int)table["book_price"];
                    bookVO.Date = (string)table["book_date"];
                    bookVO.Isbn = (string)table["book_isbn"];
                    bookVO.Information = (string)table["book_information"];
                    table.Close();
                    connection.Close();
                    return;
                }
            }
        }
        public void UpdateBookDate(string name, string author, string publisher, int count, int price, string date,int bookId) // 책정보 변경
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.UPDATE_BOOK, name, author, publisher, count, price, date,bookId);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();


            connection.Close();
        }






        public void InsertLogData(string time, string user, string information, string action) // 로그정보 삽입
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_LOG_DATA, time, user, information, action);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public void DeleteLogData(int logId) // 로그정보 삭제 
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_LOG_DATA, logId);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();

        }
        public List<LogDTO> GetLogList() // 전체로그 리스트 리턴
        {
            List<LogDTO> list = new List<LogDTO>();
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_LOGLIST);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                LogDTO log = new LogDTO();

                log.Id = (int)table["log_id"];
                log.Time = (string)table["log_time"];
                log.User = (string)table["log_user"];
                log.Information = (string)table["log_information"];
                log.Action = (string)table["log_action"];

                list.Add(log);
            }
            table.Close();
            connection.Close();

            return list;
        }

        public void DeleteALlLog() // 모든 로그정보 삭제
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_ALL_LOG);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }


    }
}
