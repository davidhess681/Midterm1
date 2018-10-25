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
                foreach (Book b in Library)
                {
                    createLibrary.WriteLine();  // write book title and author to a new line
                }
            }
        }

        public static List<Book> Library = new List<Book>();


        public static Book InSearchofLostTime = new Book("In Search of Lost Time", "Marcel Proust");
        public static Book DonQuixote = new Book("Don Quixote", "Miguel de Cervantes");
        public static Book Ulysses = new Book("Ulysses", "James Joyce");
        public static Book TheGreatGatsby = new Book("The Great Gatsby", "F.Scott Fitzgerald");
        public static Book MobyDick = new Book("Moby Dick", "Herman Melville");
        public static Book Hamlet = new Book("Hamlet", "William Shakespeare");
        public static Book WarandPeace = new Book("War and Peace", "Leo Tolstoy");
        public static Book TheOdyssey = new Book("The Odyssey", "Homer");
        public static Book Lolita = new Book("Lolita", "Vladimir Nabokov");
        public static Book OntheRoad = new Book("On the Road", "Jack Kerouac");
        public static Book Breakfastofchampions = new Book("Breakfast of champions", "Kurt Vonnegut");
        public static Book TheAlchemist = new Book("The Alchemist", "Paulo Coelho");

    }
}
