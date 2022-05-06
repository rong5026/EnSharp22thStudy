using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryMySQL
{
    internal class UserDAO
    {
        BookDAO mySQlData = BookDAO.Instance();
        MySqlConnection connection;
        private UserDTO user;

        public UserDAO()
        {
            connection = mySQlData.ConnectMySQL();
        }
        public void GetUserList(List<UserDTO> list) // 회원정보 보내줌    send->get
        {

           
            string insertQuery = string.Format(QueryData.SELECT_USERLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                user = new UserDTO(
                    (int)table["user_number"],
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
        public void GetAdminList(List<UserDTO> list)// 관리자 정보 보내줌
        {
           
            string insertQuery = string.Format(QueryData.SELECT_ADMINLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                user = new UserDTO(
                    (string)table["id"],
                    (string)table["password"]
                    );
                list.Add(user);
            }

            table.Close();
            connection.Close();
        }

        public void InsertUserData(string id, string password, string name, string age, string phoneNumber, string address) // 유저정보 삽입
        {
           
            connection.Open();

            string insertQuery = string.Format(QueryData.INSERT_USER, id, password, name, age, phoneNumber, address);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }




        public void GetLoginedUserLogList(UserDTO userVO, string loginedUser) // 현재 로그인중인 유저정보 리턴
        {

          
            string insertQuery = string.Format(QueryData.SELECT_USERLIST);

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();


            while (table.Read())
            {
                if (loginedUser == (string)table["user_id"])
                {
                    userVO.Number = (int)table["user_number"];
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

        public void UpdateUserData(string id, string password, string name, string age, string phoneNumber, string address) // 회원정보 변경
        {
          
            connection.Open();

            string insertQuery = string.Format(QueryData.UPDATE_USERDATA, id, password, name, age, phoneNumber, address, LibraryStart.loginedUser);

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            LibraryStart.loginedUser = id;

            connection.Close();
        }

        public void DeleteUserID(string userId) // 회원정보 삭제
        {
          
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_USER, userId);


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public void DeleteUserNumber(string userNumber) // 유저number엣 해당하는 유저삭제
        {
         
            connection.Open();

            string insertQuery = string.Format(QueryData.DELETE_USER_NUMBER, userNumber);


            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public UserDTO GetNaverAPI( ) // 데이터베이스에서 네이버 연결 id,secret키 가져오기
        {
            UserDTO userDTO = new UserDTO();
            string insertQuery = string.Format(QueryData.SELECT_NAVER_API);
            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            MySqlDataReader table = command.ExecuteReader();

            while (table.Read())
            {
                userDTO.Id= (string)table["client_id"];
                userDTO.Password = (string)table["client_secret"];
               
            }

            table.Close();
            connection.Close();
            return userDTO;
        }
    }
}
