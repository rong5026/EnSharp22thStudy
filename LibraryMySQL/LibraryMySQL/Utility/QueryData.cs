using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class QueryData
    {
        public const string DATABASE_NAME = "hongyeonghwan";
        public const string ID = "root";
        public const string PASSWROD = "0000";
        public const string SERVER = "localhost";
        public const string PORT = "3306";

        public const string SELECT_USERLIST = "SELECT * FROM user_data"; // 모든 유저
        public const string SELECT_ADMINLIST = "SELECT * FROM admin_data"; // 모든 관리자
        public const string INSERT_USER = "INSERT INTO user_data (user_id,user_password,user_name,user_age, user_phonenumber,user_address) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');"; // 유저정보삽입
        public const string UPDATE_USERDATA = "UPDATE user_data SET user_id ='{0}' ,user_password = '{1}', user_name='{2}',user_age='{3}', user_phonenumber='{4}', user_address='{5}' WHERE user_id = '{6}'"; // 유저정보 수정
        public const string DELETE_USER = "DELETE FROM user_data WHERE user_id = '{0}';"; // 유저정보 삭제
        public const string DELETE_USER_NUMBER = "DELETE FROM user_data WHERE user_number = '{0}';"; // 유저정보 삭제


        public const string RENT_BOOK = "SELECT * FROM user_rented_book"; // 빌린책 정보
        public const string RETURN_BOOK = "SELECT * FROM user_returned_book"; // 반납책 정보
        public const string SELECT_BOOKLIST = "SELECT * FROM book_data"; // 도서관 책 리스트
        public const string UPDATE_BOOK_COUNT = "UPDATE book_data SET book_count = {0} WHERE book_id = {1}"; // 책 수량 변경
        public const string INSERT_RENT_BOOK = "INSERT INTO user_rented_book (user_id, book_id, book_name, book_author, book_publisher,book_count,book_price, book_date, book_rent_time,book_return_time,book_isbn,book_information) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')"; // 빌린책 저장
        public const string DELETE_RENT_BOOK = "DELETE FROM user_rented_book WHERE user_id = '{0}' AND book_id = '{1}';"; // 빌린책  삭제
        public const string INSERT_RETURN_BOOK = "INSERT INTO user_returned_book (user_id, book_id, book_name, book_author, book_publisher,book_count,book_price, book_date, book_return_time,book_isbn,book_information) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')"; // 반납 책 삽입
        public const string INSERT_BOOK = "INSERT INTO book_data ( book_name, book_author, book_publisher, book_count, book_price, book_date, book_isbn, book_information ) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');"; // 책 삽입

        public const string DELETE_BOOK = "DELETE FROM book_data WHERE book_id = '{0}';"; // 책 삭제
        public const string UPDATE_BOOK = "UPDATE book_data SET book_name ='{0}' , book_author = '{1}' , book_publisher = '{2}',book_count = '{3}',book_price='{4}', book_date='{5}' WHERE book_id ='{6}'"; // 책정보 변경


        public const string INSERT_LOG_DATA = "INSERT INTO log_data (log_time,log_user,log_information, log_action) VALUES ('{0}','{1}','{2}','{3}');"; // 로그정보삽입
        public const string DELETE_LOG_DATA = "DELETE FROM log_data WHERE log_id = '{0}';";

        public const string SELECT_LOGLIST = "SELECT * FROM log_data"; // 모든 로그 리턴
        public const string DELETE_ALL_LOG = "DELETE FROM log_data;"; // 모든로그 삭제
    }
}
