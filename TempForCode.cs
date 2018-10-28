using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class TempForCode
    {
     public TempForCode()
        {

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
    }
}