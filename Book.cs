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
        public Book(string Title, string Author, bool Status, DateTime DueDate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = dueDate;
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
