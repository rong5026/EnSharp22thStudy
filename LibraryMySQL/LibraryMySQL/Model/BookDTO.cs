using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySQL
{
    internal class BookDTO
    {

        private int id;
        private string name;
        private string author;
        private string publisher;
        private int bookCount;
        private int price;
        private string date;
        private string rentTime;
        private string returnTime;
        private string isbn;
        private string information;
    
       
    
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Information
        {
            get { return information; }
            set { information = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public int BookCount
        {
            get { return bookCount; }
            set { bookCount = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string RentTime
        {
            get { return rentTime; }
            set { rentTime = value; }
        }
        public string ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }




    }
}
