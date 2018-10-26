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
                        string userInputTemp = "";

                        Console.Write("What would you like to search.?\n\n1. By Title or 2. By Author\nPlease Enter Number:  ");
                        userInputTemp = Console.ReadLine();
                        
                        //going to add validation later
                        if (userInputTemp == "1")
                        {
                            SearchBook("searchTitle");
                        }
                        else if (userInputTemp == "2")
                        {
                            SearchBook("searchAuthor");
                        }
                        break;
                    }
                case 3:
                    {
                        //call method return
                        break;
                    }
                case 4:
                    {
                        //call method checkout
                        break;
                    }
                case 5:
                    {
                        //call method add files
                        break;
                    }
                default:
                    {
                        // return bool to exit from main
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

            switch(testForIf)
            {
                case "searchTitle":
                    {
                        ArrayForWrtie.Clear();
                        Console.Write("\nPlease input keywords you wish to search for: (by Title)");
                        userSearch = Validation.IsInputValidTitle
                            (Console.ReadLine().ToLower());

                        foreach (Book b in Program.Library)
                        {
                            toLower = b.Title.ToLower();
                            if (toLower.Contains(userSearch))
                            {
                                ArrayForWrtie.Add(b);
                            }
                        }
                        break;
                    }
                case "searchAuthor":
                    {
                        ArrayForWrtie.Clear();
                        Console.Write("\nPlease input keywords you wish to search for: (by Author)");
                        userSearch = Validation.IsInputValidTitle
                            (Console.ReadLine().ToLower());
                        foreach (Book b in Program.Library)
                        {
                            toLower = b.Author.ToLower();
                            if (toLower.Contains(userSearch)) //stores each item in array if string contains usersearch
                            {
                                ArrayForWrtie.Add(b);
                            }
                        }
                        break;
                    }
                default :
                    {
                        break;
                    }
            }

            foreach(Book ans in ArrayForWrtie)
            {
                Console.WriteLine("\n{0,-50}{1,0}","Title","Author");
                Console.WriteLine("{0,-50}{1,0}", ans.Title, ans.Author);
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

