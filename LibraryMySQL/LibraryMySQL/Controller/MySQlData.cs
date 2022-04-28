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
            string database = ConnectionData.DATABASE_NAME;
            string id = ConnectionData.ID;
            string password = ConnectionData.PASSWROD;
            string server = ConnectionData.SERVER;
            int port = ConnectionData.PORT;
            MySqlConnection connection =
        new MySqlConnection("Server=localhost;Port=3306;Database=library;Uid=root;Pwd=0000;");

            return connection;
        }
        public void SendUserList(List<UserVO> list) // 회원정보 보내줌
        {
         
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format("SELECT * FROM user_data");

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

        public void InsertUserData(string id, string password, string name,string age,string phoneNumber, string address ) // 유저정보 삽입
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format("INSERT INTO user_data (user_id,user_password,user_name,user_age, user_phonenumber,user_address) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", id, password, name, age, phoneNumber, address);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void CheckLoginedUser(UserVO userVO, string loginedUser) // 현재 로그인중인 유저정보 리턴
        {

            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format("SELECT * FROM user_data");

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

            string insertQuery = string.Format("UPDATE user_data SET user_id ='{0}' ,user_password = '{1}', user_name='{2}',user_age='{3}', user_phonenumber='{4}', user_address='{5}' WHERE user_id = '{6}'",id,password,name,age, phoneNumber, address,  LibraryStart.loginedUser);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            LibraryStart.loginedUser = id;
           
            connection.Close();
        }


        public int CheckTableDataCount(string tableType) // 데이터 수 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            connection.Open();
            string insertQuery = string.Format("SELECT COUNT(*) from {0};", tableType);
            MySqlCommand command = new MySqlCommand(insertQuery, connection);


            int count = Convert.ToInt32(command.ExecuteScalar());


            connection.Close();
            return count;


        }
        public void CheckBookList(List<BookVO> list) // 책리스트를 리턴
        {
           
           
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format("SELECT * FROM book_data");
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

        }

        public int ConfrimUserRentBook(int bookId)  // 유저가 이미 빌린책이면 1, 안빌린책이면 0 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format("SELECT * FROM user_rented_book");
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

            string insertQuery = string.Format("UPDATE book_data SET book_count = {0} WHERE book_id = {1}",bookCount,bookId);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();
          

            connection.Close();
        }


        public void InsertRentBook(string rentTime,BookVO bookVO) // 빌린책 저장
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format("INSERT INTO user_rented_book (user_id, book_id, book_name, book_author, book_publisher,book_count,book_price, book_date, book_rent_time) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}')", LibraryStart.loginedUser,bookVO.Id,bookVO.Name,bookVO.Author,bookVO.Publisher,bookVO.BookCount,bookVO.Price,bookVO.Date, rentTime);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void CheckRentBook(List<BookVO> list) // 해당아이디의 빌린책 리스트 리턴
        {
            MySqlConnection connection = ConnectMySQL();
            string insertQuery = string.Format("SELECT * FROM user_rented_book");
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
            string insertQuery = string.Format("SELECT * FROM user_returned_book");
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

            string insertQuery = string.Format("DELETE FROM user_rented_book WHERE user_id = '{0}' AND book_id = '{1}';", LibraryStart.loginedUser, bookId);
         

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void InsertReturnBook(string returnTime, BookVO bookVO) // 반납책 저장
        {

            MySqlConnection connection = ConnectMySQL();
            connection.Open();

            string insertQuery = string.Format("INSERT INTO user_returned_book (user_id, book_id, book_name, book_author, book_publisher,book_count,book_price, book_date, book_return_time) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}')", LibraryStart.loginedUser, bookVO.Id, bookVO.Name, bookVO.Author, bookVO.Publisher, bookVO.BookCount, bookVO.Price, bookVO.Date, returnTime);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }




    }
}
