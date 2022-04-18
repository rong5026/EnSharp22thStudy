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
            string insertQuery = string.Format("SELECT * FROM {0}",tableName);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();
            try//예외 처리
            {


                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("{0} {1}",table["user_id"]);
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
        static void Main(string[] args)
        {

            LibraryMain main = new LibraryMain();
            //LibraryStart start = new LibraryStart();
            // start.StartProgram();
            main.FindTableData("user_data");


        }
    }
}
