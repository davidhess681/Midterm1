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
        public static List<Book> ArrayForWrtie = new List<Book>();
        public static void allSearch()
        {
            int userNumSelect;
            bool userSelect;
            Console.WriteLine("Please Choose the following opitions:\n");
            Console.WriteLine("1. List All Books\n2. Search\n3.Check Out Book\n4.Return Book");
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
                        string userInputTemp = "";

                        Console.WriteLine("What would you like to search.?\n\n1. By Title or 2.By Author");
                        userInputTemp = Console.ReadLine();
                        
                        //going to add validation later
                        if (userInputTemp == "1")
                        {
                            SearchBookTitle();
                        }
                        else if (userInputTemp == "2")
                        {
                            SearchBookAuthor();
                        }
                        break;
                    }
                case 3:
                    {
                        //call method
                        break;
                    }
                default:
                    {
                        //call method for 4
                        break;
                    }
            }
        }

        public static void ListBooks()
        {
            foreach (Book b in Program.Library)
            {
                Console.WriteLine("{0,-20}{1,0}", b.Title, b.Author);
            }
            
        }
        //public static string userSearch;
        public static void SearchBookTitle()
        {
            string userSearch;
            Console.Write("Please input keywords you wish to search for: (Author / Book Title)");
            userSearch = Validation.IsInputValidTitle
                (Console.ReadLine().ToLower());

            foreach(Book b in Program.Library)
            {
                if (b.Title.Contains(userSearch))
                {
                    ArrayForWrtie.Add(b);
                }
            }
        }

        //Searches for Author
        public static void SearchBookAuthor()
        {
            string userSearch;

            ArrayForWrtie.Clear(); //clearing array be each search
            Console.Write("Please input keywords you wish to search for: (Author / Book Title)");
            userSearch = Validation.IsInputValidAuthor(Console.ReadLine().ToLower()); //passing to validation

            foreach (Book b in Program.Library)
            {
                if (b.Author.Contains(userSearch)) //stores each item in array if string contains usersearch
                {
                    ArrayForWrtie.Add(b);
                }
            }
        }
        /*
        public bool IsCheckedOut(List<Book> stuff)
        {
            Program.whatever = stuff;
        }
        public bool ReturnABook(Book book)
        {

            if (IsCheckedOut(book))
            {
                Console.WriteLine("Would you like to return this book? ");
                string response = Console.ReadLine();
                if (Validation.YesOrNo(response))
                {
                    return false;
                }
                else
                {
                    
                    return true;
                }

            }
            else
            {
                Console.WriteLine("This book is checked in!");
            }


        }*/

        public LibraryActions()
        {

        }
    }
}

