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
        internal static List<Book> ListForWrite = new List<Book>();
        public static bool userSelectedQuit = true;

        public static void Menu()
        {
            int userNumSelectMenu;

            Console.Clear();
            Console.Beep();
            Console.WriteLine("\n\nPlease choose a number of the following opitions:\n");
            Console.WriteLine("1. List All Books\n2. Search\n3. Check Out Book" +
                "\n4. Return Book\n5. Add Book\n6. Quit Program");
            Console.Write("\nPlease enter a menu number: ");
            userNumSelectMenu =  Validation.SelectNum(Console.ReadLine()); //validates user selection

            int subMenuUserInput = 0;
            switch (userNumSelectMenu) // 5 cases for the users selection on the menu
            {
                case 1: //goes to method listbooks and returns back to main menu.
                    {
                        ListBooks(); 
                        break;
                    }
                case 2: //goes to search method, calls search method and passes in a string (these strings could be enums??)
                    {
                        subMenuUserInput = 0; //sets to zero. (needed ????)

                        Console.Write("What would you like to search.?\n\n1. By Title or 2. By Author\nPlease Enter Number:  ");
                        subMenuUserInput = Validation.SelectNumBetween1And2(Console.ReadLine()); //validation on numbers 1 and 2.

                        if (subMenuUserInput == 1) //one goes to search title part of method
                        {
                            SearchBook("searchTitle","");
                        }
                        else if (subMenuUserInput == 2) //two goes to search title part of method
                        {
                            SearchBook("searchAuthor","");
                        }
                        break; //returns to main menu
                    }
                case 3: //check out book. asks to input book name title or search for book
                    {
                        subMenuUserInput = 0; //sets to zero. (needed ????)

                        Console.Write("\n1. Checkout book by title. 2. Checkout book by search.\nPlease Enter Number:  ");
                        subMenuUserInput = Validation.SelectNumBetween1And2(Console.ReadLine()); //validation on numbers 1 and 2.

                        if (subMenuUserInput == 1) //one is directly to method after checking for book
                        {
                            IsBook("checkout");
                        }
                        else if (subMenuUserInput == 2) //two goes to search title part of method
                        {
                            SearchBook("returnedOrCheckOut","checkout"); // goes to search title part of method that returns book.
                        }
                        break;
                    }

                case 4: //needs to be returned part of book
                    {
                        subMenuUserInput = 0; //sets to zero. (needed ????)

                        Console.Write("\n1. Return book by title. 2. Return book by search.\nPlease Enter Number:  ");
                        subMenuUserInput = Validation.SelectNumBetween1And2(Console.ReadLine()); //validation on numbers 1 and 2.

                        if (subMenuUserInput == 1) //one goes to search title part of method
                        {
                            IsBook("return");
                        }
                        else if (subMenuUserInput == 2) //two goes to search title part of method
                        {
                            SearchBook("returnedOrCheckOut","return"); // goes to search title part of method that returns book.
                        }
                        break;
                    }
                case 5:
                    {
                        AddABook();
                        break;
                    }
                case 6: //case to end the program.
                    {
                        userSelectedQuit = false; 
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Oops, something went wrong"); //should not get here
                        break;
                    }
            }

        }

        //method to check for book in list for return and checkout actions 1 in allList method
        private static void IsBook(string checkoutOrReturnCase)
        {
            string userInput = "";
            bool didFindBook = false;

            Console.Write("Enter Book Title: ");
            userInput = Validation.IsInputValidTitle(Console.ReadLine());

            foreach (Book b in Program.Library)
            {
                if (b.Title.ToLower() == userInput.ToLower())
                {
                    if(checkoutOrReturnCase == "checkout")
                    {
                        b.Checkout();
                    }
                    else if(checkoutOrReturnCase == "return")
                    {
                        b.Return();
                    }

                 didFindBook = true;
                 break; //breaks out of the first true, does not continue for each
                }
            }

            if (didFindBook == false) //if the foreach return nothing then write the line
            {
                Console.WriteLine("\nThe Title {0} doesn't exist. Try Searching.", userInput);
            }
        }

        //lists all books in a formated way
        private static void ListBooks() 
        {
            Console.WriteLine("\n{0,-30}{1,0}", "Title", "Author");
            Console.WriteLine("==========================================================");
            foreach (Book b in Program.Library)
            {
                Console.WriteLine("{0,-30}{1,0}", b.Title, b.Author);
            }
            
        }
        //public static string userSearch;
        public static void SearchBook(string titleOrAuthor, string checkoutOrReturnCase)
        {
            string userSearch;
            string toLowerTitle;
            string toLowerAuthor;

            switch(titleOrAuthor)
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
            //passes case 3 and 4 conidtions into Results of Search
            ResultsOfSearch(titleOrAuthor, checkoutOrReturnCase);
        }

        // uses gobal ListForWrite results from search book to go into other methods checkout search and return
        private static void ResultsOfSearch(string testForIf, string testForElseIf)
        {
            //if searches come up with no results
            if (ListForWrite.Count() == 0)
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
                    Console.WriteLine("{0,-5}{1,-50}{2,0}", i + ". ", ans.Title, ans.Author); //sets space for 4 digit number and also for author and title
                    i++;                                                                    //each title has a number of i ++ each time.
                }
                Console.Write("\nSelect a book by number: ");

                //calls either return book method or checkout method to return a book at the List element based on search results that is counted by i for each result then takes user input to get that book number..
                //also passes through validation method and class.
                if (testForElseIf == "checkout")
                {
                    ListForWrite.ElementAt(Validation.SelectFromSearch(Console.ReadLine(), searchLength)).Checkout();
                }
                else if (testForElseIf == "return")
                {
                    ListForWrite.ElementAt(Validation.SelectFromSearch(Console.ReadLine(), searchLength)).Return();
                }
            }
        }

        public static void AddABook()
        {
            Console.Write("\nWhat is the Title of the Book you want to add? ");
            string newTitle = Validation.IsInputValidTitle(Console.ReadLine());
            Console.Write("\nWhat is the Author of the book you want to add? ");
            //validation not right here???
            string newAuthor = Validation.IsInputValidAuthor(Console.ReadLine());


            Book newBook = new Book(newTitle, newAuthor);

            Program.Library.Add(newBook);
            Console.WriteLine("Book added to list");
        }

        //empty constuctor
        public LibraryActions()
        {

        }
    }
}

