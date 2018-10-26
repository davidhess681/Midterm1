using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class TempForCode
    {
      
       public void ReturnABook(Book book)
       {

            //.WriteLine("Let's return this book!");
            Console.WriteLine("Would you like to search book by author");
            LibraryActions.SearchBookAuthor();//needs to return a Book obj

            if (book.Status == false)//if the book is checked in
            {
                Console.WriteLine("Would you like to check out this book? ");
                if (Validation.YesOrNo(Console.ReadLine()))
                {
                    book.Status = true;//if y, set as checked out, and set due date to 2 weeks from now
                    book.DueDate = book.DueDate.AddDays(14);
                }
                else
                {

                    book.Status = false;//set to checked in
                }

            }
            else //if the book is checked out
            {
                Console.WriteLine("Would you like to return this book?");
                if (Validation.YesOrNo(Console.ReadLine()))
                {
                    book.Status = false;//if y, set book to checked in
                    
                }
                else
                {

                    book.Status = true;//set to checked out
                    Console.WriteLine("Your book is due on" + book.DueDate);//show due date
                }
            }


       }

        public static void AddABook()
        {
            Console.WriteLine("\nWould you like to add a Book? (Y or N)?");
            string choice = Console.ReadLine().ToLower();
            if (choice == "n")
            {
                Console.WriteLine("\nGoodbye.");
                Console.ReadLine();
            }
            else if (choice == "y")
            {
                Console.WriteLine("\nWhat is the Title of the Book you want to add?\n");
                string newTitle = Check();
                Console.WriteLine("\nWhat is the Author of the book you want to add?\n");
                string newAuthor = Check();

                Book newBook = new Book(newTitle, newAuthor);

                Program.Library.Add(newBook);
                Console.WriteLine("Book added to list");
            }
            public static string Check()
            {
                choice = Console.ReadLine();
                if (choice == "")
                {
                    Console.Write("Cannot be empty");
                    return Check();
                }
                else
                {
                    return choice;
                }
            }


        }
    }
}