using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Book
    {
        public Book()
        {

        }
        public Book(string Title, string Author, bool Status, DateTime DueDate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = dueDate;
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        private bool status;
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        private DateTime dueDate;
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
    }
}
Book In SearchofLostTime = new Book("In Search of Lost Time", "Marcel Proust");
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