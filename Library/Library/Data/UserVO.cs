using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library
{

    internal class UserVO
    {
        private string id;
        private string password;
        private string name;
        private string age;
        private string phonenumber;
        private string address;
        private List<int> rentedBookId = new List<int>();
        private List<string> returnBookTime = new List<string>();
        private List<int> returnBookId = new List<int>();
        public UserVO()
        {
             
        }
        public UserVO(string id, string password, string name, string age, string phonenumber, string address)
        {
            
            this.id = id;
            this.password = password;
            this.name = name;
            this.age = age;
            this.phonenumber = phonenumber;
            this.address = address;
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
        
        public List<int> RendtedBookId
        {
            get { return rentedBookId; }
            set { rentedBookId = value; }

        }
        public List<int> ReturnBookId
        {
            get { return returnBookId; }
            set { returnBookId = value; }

        }
        public List<string> ReturnBookTime
        {
            get { return returnBookTime; }
            set { returnBookTime = value; }

        }



    }


}
