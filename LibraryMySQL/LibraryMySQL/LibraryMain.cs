using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace LibraryMySQL
{
    internal class LibraryMain
    {
        /*
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
        public void FindTableData(string tableName) // 전체 데이터 출력
        {
           
            MySqlConnection connection = UserConnection();
           
      
            string insertQuery = string.Format("SELECT * FROM user_data");

            connection.Open();
          

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();

            while (table.Read())
            {
                Console.WriteLine("{0} {1}", table["user_id"].GetType().Name, table["user_password"]);
            }
            
            Console.ReadLine();
            table.Close();
            connection.Close();
        }
        public void InsertUserData(string id, string password, string name, string age, string phoneNumber, string address) // 회원가입 하는 기능
        {
            MySqlConnection connection = UserConnection();
            connection.Open();

            string insertQuery = string.Format("INSERT INTO user_data (user_id,user_password,user_name,user_age, user_phonenumber,user_address) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", id, password, name, age, phoneNumber, address);

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
            Console.ReadLine();

            connection.Close();
        }
        */
        static void Main(string[] args)
        {

            // LibraryMain main = new LibraryMain();
            // main.InsertUserData("abcd1234", "abcd1234", "피카츄", "21", "010-1234-1234", "서울특별시 오류동");
            LibraryStart start = new LibraryStart();
             start.StartProgram();



        }
    }
}
