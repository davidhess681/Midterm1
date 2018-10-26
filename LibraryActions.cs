using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class LibraryActions
    {
        public void allSearch()
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
                        //call method
                        break;
                    }
                case 2:
                    {
                        //call method
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

