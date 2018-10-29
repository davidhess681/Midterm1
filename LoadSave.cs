using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class LoadSave
    {
        static string fileLib = @"c:/temp/libraryFile.txt";
        public static void InitialStream()
        {
            // check if file exists
            if (File.Exists(fileLib))
            {
                // read from file

                StreamReader readLibraryFromFile = new StreamReader(fileLib);   // create new stream reader
                string line = readLibraryFromFile.ReadLine();                   // read line from file; set to a var
                while (line != null)        // while line isn't blank
                {
                    try
                    {
                        string[] splitLine = line.Split(';');                   // parse line by semicolon
                        string newTitle = splitLine[0];                         // set title author status and date to the respective index
                        string newAuthor = splitLine[1];
                        bool newStatus = bool.Parse(splitLine[2]);
                        DateTime newDueDate = DateTime.Parse(splitLine[3]);
                        Book newbook = new Book(newTitle, newAuthor, newStatus, newDueDate);   // create book object with details from file
                        Program.Library.Add(newbook);                           // add this book to the library list
                        line = readLibraryFromFile.ReadLine();          // read next line
                    }
                    catch
                    {
                        // if something goes wrong with parsing status or duedate, display where it went wrong
                        Console.WriteLine("Parsing failed at this line: " + line);

                        // read next line
                        line = readLibraryFromFile.ReadLine();
                    }
                }
                readLibraryFromFile.Close();        // always be closing
                Console.WriteLine("Populated library from file");       // temp statement to show us which action took place


                // lists all books in library (maybe move to LibraryActions)
                foreach (Book b in Program.Library)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3}", b.Title, b.Author, b.Status, b.DueDate);
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
            Program.Library.Add(InSearchofLostTime);
            Program.Library.Add(DonQuixote);
            Program.Library.Add(Ulysses);
            Program.Library.Add(TheGreatGatsby);
            Program.Library.Add(MobyDick);
            Program.Library.Add(Hamlet);
            Program.Library.Add(WarandPeace);
            Program.Library.Add(TheOdyssey);
            Program.Library.Add(Lolita);
            Program.Library.Add(OntheRoad);
            Program.Library.Add(Breakfastofchampions);
            Program.Library.Add(TheAlchemist);
        }

        public static void UpdateLibraryFile()
        {
            try
            {
                StreamWriter createLibrary = new StreamWriter(fileLib, false);     // create new stream writer

                foreach (Book b in Program.Library)     // do this for each book
                {
                    // write book details to a new line
                    createLibrary.WriteLine(b.Title + ";" + b.Author + ";" + b.Status + ";" + b.DueDate);
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
