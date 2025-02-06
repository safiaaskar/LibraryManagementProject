using LibraryManagementProject;

namespace LibraryManagementProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning) 
            {
                Console.WriteLine("Welcome to the library system");
                Console.Write("Are you Admin (A) or Client (C): ");
                char userType = Console.ReadLine().ToUpper()[0];

                if (userType == 'A')
                {
                    AdminLogic();
                }

                else if (userType == 'C')
                {
                    ClientLogic();
                }
                else
                {
                    Console.WriteLine(" Please enter validation value (L or R or E)");
                    return;
                }
                char choice;
                bool bIsValid = ReadQustion("Are You Want to Continue?", out choice);
                isRunning = (choice == 'Y');
            }
        }
        static bool ReadQustion(string filedName, out char character)
        {
            character = ' ';
            Console.Write($"{filedName} y=yes n=no: ");
            char userChoice = Console.ReadLine().ToUpper()[0];
            if (userChoice != 'Y' && userChoice != 'N')
            {
                Console.Write("Please Eneter Vaild Character");
                return false;
            }
            character = userChoice;
            return true;
        }

        static bool ReadNumber(string filedName, out int number)
        {
            Console.Write($"Please enter your {filedName}: ");
            bool isConverted = true;
            isConverted = int.TryParse(Console.ReadLine(), out number);
            if (!isConverted)
            {
                Console.Write("Please enter valid number");
                return false;
            }
            return true;
        }

        static void AdminLogic()
        {

            Console.Write("Please enter your name ");
            string adminName = Console.ReadLine();

            Admin admin = new Admin(adminName);
            Console.WriteLine($"Welcome {admin.UserName}");
            while (true)
            {
                Console.WriteLine(@"""Please enter your choice
1- Add Book
2- Remove Book
3- Display Books
4- Display Borrowed Books
5- Add Client
6- Display Clients
7- Exit..""");

                int choice = 0;
                if (!ReadNumber("choice", out choice)) return;
                switch (choice)
                {
                    case 1:
                        AddBook(admin);
                        break;
                    case 2:
                        RemoveBook(admin);
                        break;
                    case 3:
                        admin.DisplayBooks();
                        break;
                    case 4:
                        admin.DisplayBorrowedBooks();
                        break;
                    case 5:
                        AddClient(admin);
                        break;
                    case 6:
                        admin.DisplayClients();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void AddBook(Admin admin)
        {
            Console.Write("Please Enter Book Title: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Please Enter Book Author : ");
            string author = Console.ReadLine();
            Console.Write("Please Enter ISBN of Book: ");
            string isbn = Console.ReadLine();
            int publishedYear = 0;
            if (!ReadNumber("Published Year", out publishedYear)) return;

            Book book = new Book(bookTitle, author, isbn, publishedYear);
            admin.AddBook(book);
        }
        private static void RemoveBook(Admin admin)
        {
            Console.Write("Please Enter ISBN of Book to Remove: ");
            string isbn = Console.ReadLine();
            Book bookToRemove = admin.books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                admin.RemoveBook(bookToRemove);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        private static void AddClient(Admin admin)
        {
            int idClient = 0;
            if (!ReadNumber("Client Id", out idClient)) return;
            Console.Write("Please Enter Client Name: ");
            string clientName = Console.ReadLine();

            Client newClient = new Client(idClient, clientName);
            admin.AddClient(newClient);
        }

        static void ClientLogic()
        {

            int idClient = 0;
            if (!ReadNumber("Client Id", out idClient)) return;
            Console.Write("Please enter your name ");
            string userName = Console.ReadLine();

            Client client = new Client(idClient, userName);
            Console.WriteLine($"Welcome {client.UserName}");
            while (true)
            {
                Console.WriteLine(@"""Please enter your choice
1- Borrow Book
2- Display Books
3- Exit...""");

                int choice = 0;
                if (!ReadNumber("choice", out choice)) return;
                switch (choice)
                {
                    case 1:
                        BorrowBook(client);
                        break;
                    case 2:
                        client.DisplayBooks();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void BorrowBook(Client client)
        {
            Console.Write("Enter ISBN of the book to borrow: ");
            string isbn = Console.ReadLine();
            Book bookToBorrow = client.books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToBorrow != null)
            {
                client.BorrowBook(bookToBorrow);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}
