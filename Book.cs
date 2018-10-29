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
        public void Checkout()
        {
            if (Status == false)//if the book is checked in
            {
                Console.WriteLine("Would you like to check out {0} by {1}?" +
                    " \nEnter 'Yes' or 'No'", Title, Author);
                if (Validation.YesOrNo())
                {
                    Status = true;//if y, set as checked out, and set due date to 2 weeks from now
                    DueDate = DateTime.Now;
                    DueDate = DueDate.AddDays(14);
                    Console.WriteLine("\nThe Book {0} has been checked out by you. Due date is {1}\n"
                        , Title, DueDate);
                }
                else
                {
                    Status = false;//set to checked in
                    Console.WriteLine("\nCheckout aborted.");
                }
            }
            else //if the book is checked out, tell user with due date.
            {
                Console.WriteLine("Sorry {0} is checked out. It is due to be back on {1}.\n",
                    Title, DueDate);
            }

        }
        public void Return()
        {
            //Do we need to check in if the book is already checked it or not???????

            if (Status == false)//if the book is checked in
            {
                Console.WriteLine("This book {0} is already checked in.",
                    Title);
            }
            else //if the book is checked out
            {
                Console.WriteLine("Are you sure you want to return {0}? Type 'yes' or 'no'", Title);
                if (Validation.YesOrNo())
                {
                    Status = false; //if y, set as checked in
                    Console.WriteLine("\nThe Book {0} has been returned. Thank You!"
                        , Title);
                }
                else
                {
                    Status = true;//set to not returned
                    Console.WriteLine("\nProcess aborted.");
                }
            }
        }
    }
}
