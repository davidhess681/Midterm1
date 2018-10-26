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

    }
}
// I know this is currently broken and the syntax is off, I am bad with lists
//I just tried to throw some ish out there as something to build off of; 
//better than nothing

Console.WriteLine("\nWould you like to add a Book? (Y or N)?");
            string choice = Console.ReadLine().ToLower();
            if (choice == 'n')
            {
                Console.WriteLine("\nGoodbye.");
                Console.ReadLine();
                return false;
            }
            else if (choice == 'y')
            {
                return true;
            }
            else
            {
                Console.Write("Invalid. Try again: ");
            }
            Console.WriteLine("\nWhat is the Title of the Book you want to add?\n");
            string newTitle = Check();
Console.WriteLine("\nWhat is the Author of the book you want to add?\n");
            string newAuthor = Check();
Console.WriteLine("\nWhat is the Status of the Book you want to add?\n");
            bool newStatus = Check();
Console.WriteLine("\nWhat is the Due Date of the Book you want to add?\n");
            DateTime newDueDate = Check();


Library.Add(new Book);
            Book.Insert(newTitle);
            Book.Insert(newAuthor);
            Book.Insert(newStatus);
            Book.Insert(newDueDate)
            Console.WriteLine("Book added to list")

           public static string Check()
{
    choice = Console.ReadLine();
    if (choice == "")
    {
        Console.Write("Cannot be empty");
        return choice();
    }
    else
    {
        return choice;
    }
}