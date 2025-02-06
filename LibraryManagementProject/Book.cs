using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublished { get; set; }

        public Book(string title, string author, string isbn, int yearPublished)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublished = yearPublished;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} (ISBN: {ISBN}, Published: {YearPublished})";
        }
    }
}
