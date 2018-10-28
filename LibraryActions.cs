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

            Console.WriteLine("\n\nPlease choose a number of the following opitions:\n");
            Console.WriteLine("1. List All Books\n2. Search\n3. Check Out Book" +
                "\n4. Return Book\n5. Add Book\n6. Quit Program");
            Console.Write("\nPlease enter a menu number: ");
            userNumSelect =  Validation.SelectNum(Console.ReadLine()); //validates user selection

            int userInputTemp = 0;
            string returnAndCheckout = "";
            bool bookFound = false;
            switch (userNumSelect) // 5 cases for the users selection on the menu
            {
                case 1: //goes to method listbooks and returns back to main menu.
                    {
                        ListBooks(); 
                        break;
                    }
                case 2: //goes to search method, calls search method and passes in a string (these strings could be enums??)
                    {
                        userInputTemp = 0; //sets to zero. (needed ????)

                        Console.Write("What would you like to search.?\n\n1. By Title or 2. By Author\nPlease Enter Number:  ");
                        userInputTemp = Validation.SelectNumBetween1And2(Console.ReadLine()); //validation on numbers 1 and 2.

                        if (userInputTemp == 1) //one goes to search title part of method
                        {
                            SearchBook("searchTitle");
                        }
                        else if (userInputTemp == 2) //two goes to search title part of method
                        {
                            SearchBook("searchAuthor");
                        }
                        break; //returns to main menu
                    }
                case 3: //check out book. asks to input book name title or search for book
                    {
                        userInputTemp = 0; //sets to zero. (needed ????)

                        Console.Write("\n1. Checkout book by title. 2. Checkout book by search.\nPlease Enter Number:  ");
                        userInputTemp = Validation.SelectNumBetween1And2(Console.ReadLine()); //validation on numbers 1 and 2.

                        if (userInputTemp == 1) //one is directly to method after checking for book
                        {
                            IsBook();
                        }
                        else if (userInputTemp == 2) //two goes to search title part of method
                        {
                            SearchBook("returnedOrCheckOut"); // goes to search title part of method that returns book.
                        }
                        break;
                    }

                case 4: //needs to be returned part of book
                    {
                        userInputTemp = 0; //sets to zero. (needed ????)

                        Console.Write("\n1. Return book by title. 2. Return book by search.\nPlease Enter Number:  ");
                        userInputTemp = Validation.SelectNumBetween1And2(Console.ReadLine()); //validation on numbers 1 and 2.

                        if (userInputTemp == 1) //one goes to search title part of method
                        {
                            IsBook();
                        }
                        else if (userInputTemp == 2) //two goes to search title part of method
                        {
                            SearchBook("returnedOrCheckOut"); // goes to search title part of method that returns book.
                        }
                        break;
                    }
                case 5:
                    {
                        //add a book goes here
                        break;

                    }
                case 6: //case to end the program.
                    {
                        userSelect = false; 
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Oops, something went wrong"); //should not get here
                        break;
                    }
            }

        }

        private static void IsBook()
        {
            string returnAndCheckout = "";
            bool didFindBook = false;
                    Console.Write("Enter Book Title: ");
                    returnAndCheckout = Validation.IsInputValidTitle(Console.ReadLine());
                    foreach (Book b in Program.Library)
                    {
                        if (b.Title.ToLower() == returnAndCheckout.ToLower())
                        {
                            didFindBook = true;
                            Checkout(b);
                            break;
                        }
                    }
            if (didFindBook == false)
            {
                Console.WriteLine("\nThe Title {0} doesn't exist. Try Searching.", returnAndCheckout);
            }
        }

        //lists all books in a formated way
        private static void ListBooks() 
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
                case "searchTitle": //case for searching for title by key word
                    {
                        ListForWrite.Clear(); //clears Lists in case of multiple searches
                        Console.Write("\nPlease input keywords you wish to search for: (by Title)");
                        userSearch = Validation.IsInputValidTitle //goes to validation
                            (Console.ReadLine().ToLower());

                        foreach (Book b in Program.Library) //loop that looks for title keyword match and adds it to List.
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
                        ListForWrite.Clear(); //clears Lists in case of multiple searches
                        Console.Write("\nPlease input keywords you wish to search for: (by Author)");
                        userSearch = Validation.IsInputValidAuthor //goes to validation
                            (Console.ReadLine().ToLower());

                        foreach (Book b in Program.Library) //loop that looks for author keyword match and adds it to List.
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
                        ListForWrite.Clear(); //clears Lists in case of multiple searches
                        Console.Write("\nSearch for book: ");
                        userSearch = Validation.IsInputValidTitle //goes to validation 
                            (Console.ReadLine().ToLower());

                        foreach (Book b in Program.Library) //loop that looks for title and author match and adds it to List.
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
                        Console.WriteLine("Oops, Something went wrong with search."); //should no get this message
                        break;
                    }
            }
            //if searches come up with no results
            if(ListForWrite.Count() == 0)
            {
                Console.WriteLine("Sorry, no results\n");
            }
            // prints out all searches of array based on if switch case uses title or author
            else if (testForIf == "searchTitle" || testForIf == "searchAuthor")
            {
                Console.WriteLine("\n{0,-50}{1,0}", "Title", "Author");
                foreach (Book ans in ListForWrite)
                {
                    Console.WriteLine("{0,-50}{1,0}", ans.Title, ans.Author);
                }
            }
            // prints out all searches of array based on if switch case uses checkout or return. Returns a book.
            else
            {
                int i = 1; // sets to one in case of multiple searches
                int searchLength = ListForWrite.Count(); //counts how many items in list
                Console.WriteLine("\n{0,-55}{1,0}", "Title", "Author");
                foreach (Book ans in ListForWrite)
                {
                    Console.WriteLine("{0,-5}{1,-50}{2,0}",i + ". ", ans.Title, ans.Author); //sets space for 4 digit number and also for author and title
                    i++;                                                                    //each title has a number of i ++ each time.
                }
                Console.Write("\nSelect a book by number: ");

                //calls Returnbook method to return a book at the List element based on search results that is counted by i for each result then takes user input to get that book number..
                //also passes through validation method and class.
                Checkout(ListForWrite.ElementAt(Validation.SelectFromSearch(Console.ReadLine(), searchLength)));
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

        public static void Checkout(Book book)
        {
           
            if (book.Status == false)//if the book is checked in
            {
                Console.WriteLine("Would you like to check out {0} by {1}?" +
                    " \nEnter 'Yes' or 'No'",book.Title, book.Author);
                if (Validation.YesOrNo(Console.ReadLine()))
                {
                    book.Status = true;//if y, set as checked out, and set due date to 2 weeks from now
                    book.DueDate = book.DueDate.AddDays(14);
                    Console.WriteLine("\nThe Book {0} has been checked out by you. Due date is {1}\n"
                        ,book.Title,book.DueDate);
                }
                else
                {
                    book.Status = false;//set to checked in
                }
            }
            else //if the book is checked out, tell user with due date.
            {
                Console.WriteLine("Sorry {0} is checked out. It is due to be back on {1}.\n" +
                    "Press enter to continue:",book.Title, book.DueDate);
                Console.ReadLine();
            }
        }

        //empty constuctor
        public LibraryActions()
        {

        }
    }
}

