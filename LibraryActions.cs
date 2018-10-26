using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class LibraryActions
    {
        //using this to store book objects to write to console later per method
        public static List<Book> ListForWrite = new List<Book>();
        public static bool userSelect = true;
        public static void allSearch()
        {
            int userNumSelect;
            Console.WriteLine("Please Choose the following opitions:\n");
            Console.WriteLine("1. List All Books\n2. Search\n3.Check Out Book" +
                "\n4.Return Book\n5.Add Book\n6.Quit Program");
            Console.Write("Please enter a menu number: ");
            userNumSelect =  Validation.SelectNum(Console.ReadLine());

            switch(userNumSelect)
            {
                case 1:
                    {
                        ListBooks();
                        break;
                    }
                case 2:
                    {
                        int userInputTemp = 0;

                        Console.Write("What would you like to search.?\n\n1. By Title or 2. By Author\nPlease Enter Number:  ");
                        userInputTemp = Validation.SelectNumBetween1And2(Console.ReadLine());

                        //going to add validation later
                        if (userInputTemp == 1)
                        {
                            SearchBook("searchTitle");
                        }
                        else if (userInputTemp == 2)
                        {
                            SearchBook("searchAuthor");
                        }
                        break;
                    }
                case 3:
                    {
                        SearchBook("returnedOrCheckOut");
                        break;
                    }
                case 4:
                    {
                        //call method checkout
                        break;
                    }
                case 5:
                    {

                        break;

                    }
                default:
                    {
                        userSelect = false;
                        break;
                    }
            }

        }

        public static void ListBooks()
        {
            Console.WriteLine("\n{0,-30}{1,0}", "Title", "Author");
            foreach (Book b in Program.Library)
            {
                Console.WriteLine("{0,-30}{1,0}", b.Title, b.Author);
            }
            
        }
        //public static string userSearch;
        public static void SearchBook(string testForIf)
        {
            string userSearch;
            string toLower;
            string toLowerToo;

            switch(testForIf)
            {
                case "searchTitle":
                    {
                        ListForWrite.Clear();
                        Console.Write("\nPlease input keywords you wish to search for: (by Title)");
                        userSearch = Validation.IsInputValidTitle
                            (Console.ReadLine().ToLower());

                        foreach (Book b in Program.Library)
                        {
                            toLower = b.Title.ToLower();
                            if (toLower.Contains(userSearch))
                            {
                                ListForWrite.Add(b);
                            }
                        }
                        break;
                    }
                case "searchAuthor":
                    {
                        ListForWrite.Clear();
                        Console.Write("\nPlease input keywords you wish to search for: (by Author)");
                        userSearch = Validation.IsInputValidAuthor
                            (Console.ReadLine().ToLower());
                        foreach (Book b in Program.Library)
                        {
                            toLowerToo = b.Author.ToLower();
                            if (toLowerToo.Contains(userSearch)) //stores each item in array if string contains usersearch
                            {
                                ListForWrite.Add(b);
                            }
                        }
                        break;
                    }
                case "returnedOrCheckOut":
                    {
                        ListForWrite.Clear();
                        Console.Write("\nSearch for book: ");
                        userSearch = Validation.IsInputValidTitle
                            (Console.ReadLine().ToLower());
                        foreach (Book b in Program.Library)
                        {
                            toLower = b.Title.ToLower();
                            toLowerToo = b.Author.ToLower();

                            if (toLower.Contains(userSearch)) //stores each item in array if string contains usersearch
                            {
                                ListForWrite.Add(b);
                            }
                            else if (toLowerToo.Contains(userSearch))
                            {
                                ListForWrite.Add(b);
                            }
                        }
                        break;
                    }
                default :
                    {
                        break;
                    }
            }
            if (testForIf == "searchTitle" || testForIf == "searchAuthor")
            {
                Console.WriteLine("\n{0,-50}{1,0}", "Title", "Author");
                foreach (Book ans in ListForWrite)
                {
                    Console.WriteLine("{0,-50}{1,0}", ans.Title, ans.Author);
                }
            }
            else
            {
                int i = 1;
                int searchLength = ListForWrite.Count();
                Console.WriteLine("\n{0,-55}{1,0}", "Title", "Author");
                foreach (Book ans in ListForWrite)
                {
                    Console.WriteLine("{0,-5}{1,-50}{2,0}",i + ". ", ans.Title, ans.Author);
                    i++;
                }
                Console.Write("\nSelect a book by number: ");
                ReturnABook(ListForWrite.ElementAt(Validation.SelectFromSearch(Console.ReadLine(), searchLength)));

            }
        }

        public static void ReturnABook(Book book)
        {

            //.WriteLine("Let's return this book!");
            //Console.WriteLine("Would you like to search book by author");
            //LibraryActions.SearchBook();//needs to return a Book obj

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

        public LibraryActions()
        {

        }
    }
}

