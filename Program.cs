
namespace LibraryManagementSystem
{

class Program
{
    static void Main(string[] args)
    {
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

}

} 