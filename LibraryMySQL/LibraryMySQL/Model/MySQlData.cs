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

        public void UseDatabase(string type)
        {


            string database = "library";
            string id = "root";
            string password = "0000";
            string server = "localhost";
            int port = 3306;
            MySqlConnection connection =
        new MySqlConnection("Server=localhost;Port=3306;Database=library;Uid=root;Pwd=0000;");

            string insertQuery = string.Format("INSERT INTO user_data (id,password,user_name) VALUES (2,1,\"hong\");");
            connection.Open();
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
    }
}
