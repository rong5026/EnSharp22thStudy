using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class LogDTO
    {
        private int id;
        private string time;
        private string user;
        private string information;     
        private string action;

        public LogDTO()
        {

        }
        public LogDTO(int id, string time, string user, string information, string action)
        {
            this.id = id;
            this.time = time;
            this.user = user;
            this.information = information;
            this.action = action;
        }
        public string Information
        {
            get { return information; }
            set { information = value; }
        }
        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
