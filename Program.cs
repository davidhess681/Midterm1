using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            // populate Library based on file
            LoadSave.InitialStream();

            Console.WriteLine("Success!");

            // loop through allSearch() for as long as needed
            do
            {
                LibraryActions.allSearch();
            }
            while (LibraryActions.userSelect);

            // Write all changes to libraryFile
            LoadSave.UpdateLibraryFile();
            Console.WriteLine("Library file has been updated! Press any key to close.");

            // end
            Console.ReadKey();
        }

        public static List<Book> Library = new List<Book>();


        
    }
}
