using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{

    internal class UserDTO
    {
        private string id;
        private string password;
        private string name;
        private string age;
        private string phonenumber;
        private string address;
        private int number;
      
        public UserDTO()
        {

        }
        public UserDTO(string id, string password)
        {
            this.id = id;
            this.password = password;
        }
        public UserDTO(int number,string id, string password, string name, string age, string phonenumber, string address)
        {
            this.number = number;
            this.id = id;
            this.password = password;
            this.name = name;
            this.age = age;
            this.phonenumber = phonenumber;
            this.address = address;
        }
       
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; } 
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }    
        }
        public string PhoneNumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        
      



    }


}
