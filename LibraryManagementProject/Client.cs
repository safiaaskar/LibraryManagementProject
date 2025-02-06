using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    internal class Client : User
    {
        public Client(int id, string name) : base(name)
        {
        }

        public override string ToString()
        {
            return $"User Name: {UserName}     (ID: {Id})";
        }

        public void BorrowBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                borrowedBooks.Add(book);
                Console.WriteLine($"{book} borrowed by {UserName}.");
            }
            else
            {
                Console.WriteLine("Book not available in the library.");
            }
        }
    }
}
