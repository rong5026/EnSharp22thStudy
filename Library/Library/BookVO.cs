using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class BookVO
    {

        private int id;
        private string name;
        private string author;
        private string publisher;
        private int bookCount;
        private int price;
        private string date;
        private int rentId;
        public static int totalBook=0;

        public BookVO()
        {

        }
        public BookVO(int id, string name, string author, string publisher, int bookCount, int price,string date,int rentId )
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.publisher = publisher;
            this.bookCount = bookCount;
            this.price = price;
            this.date = date;
            this.rentId = rentId;
            totalBook++;
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
        public int RentId
        {
            get { return rentId; }
            set { rentId = value; }
        }

    }
}
