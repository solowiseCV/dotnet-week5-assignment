
namespace LibraryManagementSystem
{

class Program
{
    static void Main(string[] args)
    {
      
        Library library = new Library("City Central Library");
        SeedSampleBooks(library);

      
        bool running = true;
        while (running)
        {
            DisplayMenu(library.LibraryName);
            string input = Console.ReadLine()?.Trim();

            // Validate that input is a number in range
            if (!int.TryParse(input, out int choice) || choice < 1 || choice > 9)
            {
                Console.WriteLine("\n  [!] Invalid choice. Please enter a number between 1 and 9.");
                Pause();
                continue;
            }

            Console.WriteLine(); 

            switch (choice)
            {
                // ── 1. Add New Book 
                case 1:
                    AddNewBook(library);
                    break;

                // ── 2. Display All Books 
                case 2:
                    library.DisplayAllBooks();
                    break;

                // ── 3. Search by Title 
                case 3:
                    Console.Write("  Enter title (or part of title): ");
                    string titleQuery = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(titleQuery))
                        library.SearchByTitle(titleQuery);
                    else
                        Console.WriteLine("  [!] Title cannot be empty.");
                    break;

                // ── 4. Search by Author
                case 4:
                    Console.Write("  Enter author name (or part of name): ");
                    string authorQuery = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(authorQuery))
                        library.SearchByAuthor(authorQuery);
                    else
                        Console.WriteLine("  [!] Author name cannot be empty.");
                    break;

                // ── 5. Display Books by Category
                case 5:
                    Console.WriteLine("  Available categories: Fiction, Science, History, Biography, Technology");
                    Console.Write("  Enter category: ");
                    string category = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(category))
                        library.DisplayBooksByCategory(category);
                    else
                        Console.WriteLine("  [!] Category cannot be empty.");
                    break;

                // ── 6. Borrow a Book 
                case 6:
                    Console.Write("  Enter the ISBN of the book to borrow: ");
                    string borrowISBN = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(borrowISBN))
                        library.BorrowBook(borrowISBN);
                    else
                        Console.WriteLine("  [!] ISBN cannot be empty.");
                    break;

                // ── 7. Return a Book
                case 7:
                    Console.Write("  Enter the ISBN of the book to return: ");
                    string returnISBN = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(returnISBN))
                        library.ReturnBook(returnISBN);
                    else
                        Console.WriteLine("  [!] ISBN cannot be empty.");
                    break;

                // ── 8. Display Statistics
                case 8:
                    library.DisplayStatistics();
                    break;

                // ── 9. Exit 
                case 9:
                    Console.WriteLine("  Thank you for using the Library Management System. Goodbye!");
                    running = false;
                    break;
            }

            if (running) Pause();
        }
    }

 
    static void DisplayMenu(string libraryName)
    {
        Console.Clear();
        Console.WriteLine("=== Library Management System ===");
        Console.WriteLine($"Library: {libraryName}");
        Console.WriteLine();
        Console.WriteLine("1. Add New Book");
        Console.WriteLine("2. Display All Books");
        Console.WriteLine("3. Search Book by Title");
        Console.WriteLine("4. Search Books by Author");
        Console.WriteLine("5. Display Books by Category");
        Console.WriteLine("6. Borrow a Book");
        Console.WriteLine("7. Return a Book");
        Console.WriteLine("8. Display Library Statistics");
        Console.WriteLine("9. Exit");
        Console.Write("  Enter your choice: ");
    }

    static void AddNewBook(Library library)
    {
        Console.WriteLine("=== Add New Book ===");

        // Title
        Console.Write("  Title: ");
        string title = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(title)) { Console.WriteLine("  [!] Title cannot be empty."); return; }

        // Author
        Console.Write("  Author: ");
        string author = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(author)) { Console.WriteLine("  [!] Author cannot be empty."); return; }

        // ISBN
        Console.Write("  ISBN: ");
        string isbn = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(isbn)) { Console.WriteLine("  [!] ISBN cannot be empty."); return; }

        // Price – must be a non-negative decimal
        Console.Write("  Price ($): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
        {
            Console.WriteLine("  [!] Price must be a non-negative number.");
            return;
        }

        // Copies – must be a non-negative integer
        Console.Write("  Number of copies: ");
        if (!int.TryParse(Console.ReadLine(), out int copies) || copies < 0)
        {
            Console.WriteLine("  [!] Copies must be a non-negative whole number.");
            return;
        }

        // Category
        Console.WriteLine("  Available categories: Fiction, Science, History, Biography, Technology");
        Console.Write("  Category: ");
        string cat = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(cat)) { Console.WriteLine("  [!] Category cannot be empty."); return; }

      
        Book newBook = new Book(title, author, isbn, price, copies, cat);
        library.AddBook(newBook);
    }

    static void SeedSampleBooks(Library library)
    {
        library.AddBook(new Book("The Great Gatsby",       "F. Scott Fitzgerald", "978-001", 15.99m,  3, "Fiction"));
        library.AddBook(new Book("1984",                   "George Orwell",       "978-002", 12.50m,  0, "Fiction"));
        library.AddBook(new Book("To Kill a Mockingbird",  "Harper Lee",          "978-003", 14.99m,  5, "Fiction"));
        library.AddBook(new Book("A Brief History of Time","Stephen Hawking",     "978-004", 18.75m,  2, "Science"));
        library.AddBook(new Book("Sapiens",                "Yuval Noah Harari",   "978-005", 16.00m,  4, "History"));
        library.AddBook(new Book("Clean Code",             "Robert C. Martin",    "978-006", 35.99m,  1, "Technology"));
        library.AddBook(new Book("The Diary of a Young Girl","Anne Frank",        "978-007", 11.50m,  3, "Biography"));
        Console.Clear(); // clear seed messages so main menu shows clean
    }

    static void Pause()
    {
        Console.WriteLine("\n  Press Enter to return to the menu...");
        Console.ReadLine();
    }
}

} 