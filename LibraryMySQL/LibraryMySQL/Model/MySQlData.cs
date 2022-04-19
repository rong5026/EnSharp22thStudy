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

        public static MySQlData Instance()
        {
            if (mysqlData == null)
                mysqlData = new MySQlData();
            return mysqlData;
        }

        public MySqlConnection UserConnection()
        {
            string database = "library";
            string id = "root";
            string password = "0000";
            string server = "localhost";
            int port = 3306;
            MySqlConnection connection =
        new MySqlConnection("Server=localhost;Port=3306;Database=library;Uid=root;Pwd=0000;");

            return connection;
        }
        public int CheckLogin(string id, string passWord) // 전체 데이터 출력
        {

            MySqlConnection connection = UserConnection();


            string insertQuery = string.Format("SELECT * FROM user_data");

            connection.Open();


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                
                if (  (string)table["user_id"] == id && (string)table["user_password"] == passWord)
                {
                   
                    table.Close();
                    connection.Close();                
                    return Constants.LOGIN_SUCCESS;
                }
                   

            }
                 
            table.Close();
            connection.Close();
   
            return Constants.LOGIN_FAIL;
        }

        public void InsertUserData(string id, string password, string name,string age,string phoneNumber, string address ) // 유저정보 삽입
        {
            MySqlConnection connection = UserConnection();
            connection.Open();

            string insertQuery = string.Format("INSERT INTO user_data (user_id,user_password,user_name,user_age, user_phonenumber,user_address) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", id, password, name, age, phoneNumber, address);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
           
            connection.Close();
        }

        public int CheckUserId(string id) // 회원가입시 유저 정보가 겹치는지 확인
        {

            MySqlConnection connection = UserConnection();


            string insertQuery = string.Format("SELECT * FROM user_data");

            connection.Open();


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {

                if ((string)table["user_id"] == id)
                {

                    table.Close();
                    connection.Close();
                    return Constants.LOGIN_FAIL;
                }


            }

            table.Close();
            connection.Close();

            return Constants.LOGIN_SUCCESS;
        }
        public int CheckTableDataCount(string tableType) // 데이터 수 리턴
        {
            MySqlConnection connection = UserConnection();
            connection.Open();
            string insertQuery = string.Format("SELECT COUNT(*) from {0};", tableType);
            MySqlCommand command = new MySqlCommand(insertQuery, connection);


            int count = Convert.ToInt32(command.ExecuteScalar());


            connection.Close();
            return count;


        }
        public bool CheckBookList(string data, string type) // 책검색할때 조건에 맞는지 확인
        {

            MySqlConnection connection = UserConnection();


            string insertQuery = string.Format("SELECT * FROM book_data");

            connection.Open();


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                if ((string)table[type] == data)
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
        public string CheckBookUnit(int bookId,string type)
        {
            MySqlConnection connection = UserConnection();


            string insertQuery = string.Format("SELECT * FROM book_data");

            connection.Open();


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
             
                if ((string)table["book_id"] == bookId.ToString())
                {

                    string result = table[type].ToString();
                    table.Close();
                    connection.Close();
                    return result;
                }
                
            }
            table.Close();
            connection.Close();

            return Constants.INPUT_EMPTY;
        }
    }
}
