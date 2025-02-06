using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    internal class Admin : User
    {
        private List<Client> clients = new List<Client>();

        public Admin(string name) : base(name)
        {
        }

        public void AddBook(Book book)
        {
            // Check if a book with the same ISBN already exists
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                Console.WriteLine("A book with this ISBN already exists in the library.");
                return;
            }
            books.Add(book);
            Console.WriteLine($"{book} added successfully");
        }

        public void RemoveBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                Console.WriteLine($"{book} Removed Successfull");
            }
            else
            {
                Console.WriteLine("Book Not Found in The Library");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("No books have been borrowed.");
                return;
            }

            Console.WriteLine("Borrowed Books:");
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine(book);
            }
        }

        public void AddClient(Client client)
        {
            if (clients.Any(c => c.Id == client.Id))
            {
                Console.WriteLine("A book with this ISBN already exists in the library.");
                return;
            }
            clients.Add(client);
            Console.WriteLine("Member Added Successfully");
        }

        public void DisplayClients()
        {
            if (clients.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("Books in the Library:");
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

    }
}
