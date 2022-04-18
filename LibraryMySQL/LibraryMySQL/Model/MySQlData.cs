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
        public void FindTableData(string tableName)
        {

            MySqlConnection connection = UserConnection();


            //  string insertQuery = string.Format("INSERT INTO user_data (id,password,user_name) VALUES (2,1,\"hong\");");

            connection.Open();
            string insertQuery = string.Format("SELECT * FROM user_data");
           
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try//예외 처리
            {
                

                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("정상적으로 갔다");
                }
                else
                {
                    Console.WriteLine("비정상 갔다");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

          
            connection.Close();
        }

        public void InsertUserData(string id, string password, string name,string age,string phoneNumber, string address )
        {
            MySqlConnection connection = UserConnection();
            connection.Open();

            string insertQuery = string.Format("INSERT INTO user_data (user_id,user_password,user_name,user_age, user_phonenumber,user_address) VALUES ({0},{1},{2},{3},{4},{5});",id,password,name,age,phoneNumber,address);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try//예외 처리
            {

                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("정상적으로 갔다");
                }
                else
                {
                    Console.WriteLine("비정상 갔다");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            connection.Close();
        }
    }
}
