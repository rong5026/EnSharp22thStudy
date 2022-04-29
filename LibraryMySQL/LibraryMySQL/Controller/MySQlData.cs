using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace LibraryMySQL
{
    internal class MySQlData
    {

        private static MySQlData mysqlData;
        private UserVO user;
        public static MySQlData Instance()
        {
            if (mysqlData == null)
                mysqlData = new MySQlData();
            return mysqlData;
        }

        public MySqlConnection ConnectMySQL()
        {
            
            MySqlConnection connection =
        new MySqlConnection("Server="+ ConnectionData.DATABASE_NAME+"; Port="+ ConnectionData.PORT + ";Database="+ ConnectionData.DATABASE_NAME+";Uid="+ ConnectionData.ID + ";Pwd="+ ConnectionData.PASSWROD + ";");

            return connection;
        }
        public void SendUserList(List<UserVO> list) // 회원정보 보내줌
        {
         
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_USERLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                user = new UserVO( 
                    (string)table["user_id"],
                    (string)table["user_password"],
                    (string)table["user_name"],
                    (string)table["user_age"],
                    (string)table["user_phonenumber"],
                    (string)table["user_address"]
                    );
                list.Add(user);
            }
                 
            table.Close();
            connection.Close();
       
        }
        public void SendAdminList(List<UserVO> list)// 관리자 정보 보내줌
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_ADMINLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                user = new UserVO(
                    (string)table["id"],
                    (string)table["password"]                 
                    );
                list.Add(user);
            }

            table.Close();
            connection.Close();
        }

        public void InsertUserData(string id, string password, string name,string age,string phoneNumber, string address ) // 유저정보 삽입
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_USER, id, password, name, age, phoneNumber, address);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void CheckLoginedUser(UserVO userVO, string loginedUser) // 현재 로그인중인 유저정보 리턴
        {

            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_USERLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                if (loginedUser == (string)table["user_id"])
                {
                    userVO.Id = (string)table["user_id"];
                    userVO.Password = (string)table["user_password"];
                    userVO.Name = (string)table["user_name"];
                    userVO.Age = (string)table["user_age"];
                    userVO.PhoneNumber = (string)table["user_phonenumber"];
                    userVO.Address = (string)table["user_address"];

                    table.Close();
                    connection.Close();
                    return;
                }
            }
        }

        public void UpdateUserData(string id, string password, string name, string age, string phoneNumber, string address ) // 회원정보 변경
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.UPDATE_USERDATA, id,password,name,age, phoneNumber, address,  LibraryStart.loginedUser);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            LibraryStart.loginedUser = id;
           
            connection.Close();
        }
       
        public void DeleteUserID(string userId) // 회원정보 삭제
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_USER, userId);


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
        
        public bool LoginedUserRentBookCount(string userId)
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.RENT_BOOK);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {

                if (LibraryStart.loginedUser == (string)table["user_id"])
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
      
        public List<BookVO> CheckBookList() // 책리스트를 리턴
        {
           
            List<BookVO> list = new List<BookVO>();
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format(QueryData.SELECT_BOOKLIST);
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();

   
            while (table.Read())
            {
                BookVO book = new BookVO();
               
                book.Id = (int)table["book_id"];
                book.Name = (string)table["book_name"];
                book.Author = (string)table["book_author"];
                book.Publisher = (string)table["book_publisher"];
                book.BookCount = (int)table["book_count"];
                book.Price = (int)table["book_price"];
                book.Date = (string)table["book_date"];
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

        public int CheckBookCount(int bookId) // 책의 수량을 리턴
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
        public void InsertRentBook(string rentTime,BookVO bookVO) // 빌린책 저장
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_RENT_BOOK, LibraryStart.loginedUser,bookVO.Id,bookVO.Name,bookVO.Author,bookVO.Publisher,bookVO.BookCount,bookVO.Price,bookVO.Date, rentTime);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void CheckRentBook(List<BookVO> list,string userId) // 해당아이디의 빌린책 리스트 리턴
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
                    BookVO book = new BookVO();
                    book.Id = (int)table["book_id"];
                    book.Name = (string)table["book_name"];
                    book.Author = (string)table["book_author"];
                    book.Publisher = (string)table["book_publisher"];
                    book.BookCount = (int)table["book_count"];
                    book.Price = (int)table["book_price"];
                    book.Date = (string)table["book_date"];
                    book.Time = (string)table["book_rent_time"];
                    list.Add(book);
                }


            }
            table.Close();
            connection.Close();

        }
        public void CheckReturnedBook(List<BookVO> list) // 해당아이디의 반납책 리스트 리턴
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
                    BookVO book = new BookVO();
                    book.Id = (int)table["book_id"];
                    book.Name = (string)table["book_name"];
                    book.Author = (string)table["book_author"];
                    book.Publisher = (string)table["book_publisher"];
                    book.BookCount = (int)table["book_count"];
                    book.Price = (int)table["book_price"];
                    book.Date = (string)table["book_date"];
                    book.Time = (string)table["book_return_time"];
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

        public void InsertReturnBook(string returnTime, BookVO bookVO) // 반납책 저장
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_RETURN_BOOK, LibraryStart.loginedUser, bookVO.Id, bookVO.Name, bookVO.Author, bookVO.Publisher, bookVO.BookCount, bookVO.Price, bookVO.Date, returnTime);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void InsertBook(BookVO bookVO) // 책 등록
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_BOOK, bookVO.Name,bookVO.Author,bookVO.Publisher,bookVO.BookCount,bookVO.Price,bookVO.Date);

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

        public void CheckSelectedBook(BookVO bookVO, int bookId) // 수정하고자 하는 책 정보 리턴
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

    }
}
