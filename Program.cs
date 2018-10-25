using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLib = @"c:/temp/libraryFile.txt";
            if (File.Exists(fileLib))
            {
                StreamReader readLibraryFromFile = new StreamReader(fileLib);
                // read each line
                // create books based on file
            }
            else
            {
                StreamWriter createLibrary = new StreamWriter(fileLib);
                foreach(Book b in Library)
                {
                    createLibrary.WriteLine();  // write book title and author to a new line
                }
            }
        }

        public static List<Book> Library = new List<Book>();
    }
}
