using _18thTask.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== User Registration ===");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Role role;
        while (true)
        {
            Console.WriteLine("\nSelect role:");
            Console.WriteLine("1 - Admin");
            Console.WriteLine("2 - Member");
            Console.Write("Enter role number: ");
            string roleInput = Console.ReadLine();

            if (roleInput == "1") { role = Role.Admin; break; }
            else if (roleInput == "2") { role = Role.Member; break; }
            else Console.WriteLine("Invalid role. Please try again.");
        }

        User currentUser = new User(name, email, role);
        Console.WriteLine($"\nUser registered: {currentUser.UserName}, Role: {currentUser.Role}");

        Library library = new Library();
        library.BookLimit = 200;

        while (true)
        {
            Console.WriteLine("\n=== Library Menu ===");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Get book by ID");
            Console.WriteLine("3. Get all books");
            Console.WriteLine("4. Delete book by ID");
            Console.WriteLine("5. Edit book name");
            Console.WriteLine("6. Filter by page count");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (currentUser.Role != Role.Admin)
                    {
                        Console.WriteLine("Error: Only Admin can add books.");
                        break;
                    }
                    Console.WriteLine("\n=== Add Book ===");

                    Console.Write("Enter book name: ");
                    string bookName = Console.ReadLine();

                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();

                    Console.Write("Enter page count: ");
                    int pageCount = Convert.ToInt32(Console.ReadLine());

                    Book newBook = new Book(bookName, author, pageCount);
                    library.AddBook(newBook);
                    Console.WriteLine("Book added successfully.");
                    break;

                case "2":
                    Console.Write("\nEnter book ID: ");
                    int getId = Convert.ToInt32(Console.ReadLine());

                    Book foundBook = library.GetBookById(getId);
                    if (foundBook == null)
                        Console.WriteLine("Book not found.");
                    else
                        foundBook.ShowInfo();
                    break;

                case "3":
                    Console.WriteLine("\n=== All Books ===");
                    var books = library.GetAllBooks();

                    if (!books.Any())
                    {
                        Console.WriteLine("No books available.");
                        break;
                    }

                    foreach (var book in books)
                        book.ShowInfo();
                    break;

                case "4":
                    if (currentUser.Role != Role.Admin)
                    {
                        Console.WriteLine("Error: Only Admin can delete books.");
                        break;
                    }

                    Console.Write("\nEnter book ID to delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());

                    library.DeleteBookById(deleteId);
                    Console.WriteLine("Book deleted successfully.");
                    break;

                case "5":
                    if (currentUser.Role != Role.Admin)
                    {
                        Console.WriteLine("Error: Only Admin can edit books.");
                        break;
                    }

                    Console.Write("\nEnter book ID to edit: ");
                    int editId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter new book name: ");
                    string newName = Console.ReadLine();

                    library.EditBookName(editId, newName);
                    Console.WriteLine("Book name updated.");
                    break;

                case "6":
                    Console.WriteLine("\n=== Filtered Books by Page Count ===");
                    var filtered = library.FilterByPageCount();

                    if (!filtered.Any())
                    {
                        Console.WriteLine("No books available.");
                        break;
                    }

                    foreach (var book in filtered)
                        book.ShowInfo();
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
