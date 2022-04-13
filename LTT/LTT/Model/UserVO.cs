using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    internal class UserVO
    {
        private string id;
        private string password;

        public UserVO(string id, string password)
        {
            this.id = id;
            this.password = password;
         
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
    }

}
