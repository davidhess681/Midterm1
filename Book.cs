using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Book
    {
        public Book()
        {

        }
        public Book(string title, string author, bool status, DateTime dueDate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = dueDate;
        }

        //temp const
        public Book(string title, string author)
        {

            DateTime defaultDate = new DateTime(2099, 12, 31);  // declare default datetime
            Title = title;          // set title
            Author = author;        // set author
            Status = false;         // set status as false (book isn't checked out
            DueDate = defaultDate;  // set due date to far in the future
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        private bool status;
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        private DateTime dueDate;
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
    }
}
