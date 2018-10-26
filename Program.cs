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
            
            InitialStream();

            Console.WriteLine("Success!");

            do
            {
                LibraryActions.allSearch();
            }
            while (Validation.YesOrNo(Console.ReadLine()));

            UpdateLibraryFile();
            Console.WriteLine("Library file has been updated! Press any key to close.");

            Console.ReadKey();
        }

        public static List<Book> Library = new List<Book>();
        public static string fileLib = @"c:/temp/libraryFile.txt";

        static void InitialStream()
        {
            // check if file exists
            if (File.Exists(fileLib))
            {
                // read from file

                StreamReader readLibraryFromFile = new StreamReader(fileLib);   // create new stream reader
                string line = readLibraryFromFile.ReadLine();                   // read line from file; set to a var
                while (line != null)        // while line isn't blank
                {
                    string newTitle = line;                         // set current line as title
                    line = readLibraryFromFile.ReadLine();          // read next line
                    string newAuthor = line;                        // set line as author
                    Book newbook = new Book(newTitle, newAuthor);   // create book object with new title and author from file
                    Library.Add(newbook);                           // add this book to the library list
                    line = readLibraryFromFile.ReadLine();          // read next line
                }
                readLibraryFromFile.Close();        // always be closing
                Console.WriteLine("Populated library from file");       // temp statement to show us which action took place


                // lists all books in library (maybe move to LibraryActions)
                foreach (Book b in Library)
                {
                    Console.WriteLine("Title: {0} \t Author: {1}", b.Title, b.Author);
                }

            }
            else
            {
                // write default books to new file

                CreateDefaultBooks();       // create books and add them to library
                UpdateLibraryFile();
                
                Console.WriteLine("Created new file 'library.txt'");    // temp statement to show us which action took place
            }
        }
        static void CreateDefaultBooks()
        {
            // create book objects
            Book InSearchofLostTime = new Book("In Search of Lost Time", "Marcel Proust");
            Book DonQuixote = new Book("Don Quixote", "Miguel de Cervantes");
            Book Ulysses = new Book("Ulysses", "James Joyce");
            Book TheGreatGatsby = new Book("The Great Gatsby", "F.Scott Fitzgerald");
            Book MobyDick = new Book("Moby Dick", "Herman Melville");
            Book Hamlet = new Book("Hamlet", "William Shakespeare");
            Book WarandPeace = new Book("War and Peace", "Leo Tolstoy");
            Book TheOdyssey = new Book("The Odyssey", "Homer");
            Book Lolita = new Book("Lolita", "Vladimir Nabokov");
            Book OntheRoad = new Book("On the Road", "Jack Kerouac");
            Book Breakfastofchampions = new Book("Breakfast of champions", "Kurt Vonnegut");
            Book TheAlchemist = new Book("The Alchemist", "Paulo Coelho");

            // add books to Library
            Library.Add(InSearchofLostTime);
            Library.Add(DonQuixote);
            Library.Add(Ulysses);
            Library.Add(TheGreatGatsby);
            Library.Add(MobyDick);
            Library.Add(Hamlet);
            Library.Add(WarandPeace);
            Library.Add(TheOdyssey);
            Library.Add(Lolita);
            Library.Add(OntheRoad);
            Library.Add(Breakfastofchampions);
            Library.Add(TheAlchemist);
        }
        
        static void UpdateLibraryFile()
        {
            try
            {
                StreamWriter createLibrary = new StreamWriter(fileLib, false);     // create new stream writer

                foreach (Book b in Library)     // do this for each book
                {
                    createLibrary.WriteLine(b.Title);   // write book title to a new line
                    createLibrary.WriteLine(b.Author);  // same with author
                }
                createLibrary.Close();  // always be closing
            }
            catch
            {
                Console.WriteLine("Something went wrong writing to the library file!");
                Console.ReadKey();
            }
        }
    }
}
