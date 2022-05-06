using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace LibraryMySQL
{
    internal class BookDAO
    {

        private static BookDAO mysqlData;
        private UserDTO user;
        private BookDTO book;
        public static BookDAO Instance()
        {
            if (mysqlData == null)
                mysqlData = new BookDAO();
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
              

                book = new BookDTO((int)table["book_id"], (string)table["book_name"], (string)table["book_author"], (string)table["book_publisher"], (int)table["book_count"], (int)table["book_price"], (string)table["book_date"], (string)table["book_rent_time"], (string)table["book_return_time"], (string)table["book_isbn"], (string)table["book_information"]);

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
           
            string insertQuery;

            MySqlConnection connection = ConnectMySQL();
            insertQuery = string.Format(QueryData.RENT_BOOK);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {

                if (userId == (string)table["user_id"])
                {
                    book = new BookDTO((int)table["book_id"], (string)table["book_name"], (string)table["book_author"], (string)table["book_publisher"], (int)table["book_count"], (int)table["book_price"], (string)table["book_date"], (string)table["book_rent_time"], (string)table["book_return_time"], (string)table["book_isbn"], (string)table["book_information"]);
                  
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
                   
                    book = new BookDTO((int)table["book_id"], (string)table["book_name"], (string)table["book_author"], (string)table["book_publisher"], (int)table["book_count"], (int)table["book_price"], (string)table["book_date"], null, (string)table["book_return_time"], (string)table["book_isbn"], (string)table["book_information"]);

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
                  

                    book = new BookDTO((int)table["book_id"], (string)table["book_name"], (string)table["book_author"], (string)table["book_publisher"], (int)table["book_count"], (int)table["book_price"], (string)table["book_date"], null,null, (string)table["book_isbn"], (string)table["book_information"]);
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
            LogDTO log;
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_LOGLIST);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                log = new LogDTO((int)table["log_id"], (string)table["log_time"], (string)table["log_user"], (string)table["log_information"], (string)table["log_action"]);

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
