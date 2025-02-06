using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    internal class Library
    {
        public List<Book> books;
        protected List<Book> borrowedBooks;

        public Library()
        {
            books = new List<Book>();
        }

        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("Books in the Library:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }        
        

    }
}
