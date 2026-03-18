

namespace LibraryManagementSystem
{

public class Library(string libraryName)
    {

        public string LibraryName { get; set; } = libraryName;

        private readonly List<Book> books = [];

        public void AddBook(Book book)
    {
        if (book == null)
        {
            Console.WriteLine("  [!] Cannot add a null book.");
            return;
        }
        books.Add(book);
        Console.WriteLine($"  [✓] \"{book.Title}\" added successfully.");
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("\n=== All Books ===");

        if (books.Count == 0)
        {
            Console.WriteLine("  No books in the library.");
            return;
        }

        PrintTableHeader();
        foreach (Book b in books)
            PrintBookRow(b);
        PrintTableFooter();
    }

    public void SearchByTitle(string title)
    {
        Console.WriteLine($"\n=== Search Results for Title: \"{title}\" ===");

        List<Book> results = books
            .Where(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("  No books found matching that title.");
            return;
        }

        PrintTableHeader();
        foreach (Book b in results)
            PrintBookRow(b);
        PrintTableFooter();
    }

    public void SearchByAuthor(string author)
    {
        Console.WriteLine($"\n=== Books by Author: \"{author}\" ===");

        List<Book> results = books
            .Where(b => b.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("  No books found for that author.");
            return;
        }

        PrintTableHeader();
        foreach (Book b in results)
            PrintBookRow(b);
        PrintTableFooter();
    }
    public void DisplayBooksByCategory(string category)
    {
        Console.WriteLine($"\n=== Books in Category: \"{category}\" ===");

        List<Book> results = books
            .Where(b => b.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("  No books found in that category.");
            return;
        }

        PrintTableHeader();
        foreach (Book b in results)
            PrintBookRow(b);
        PrintTableFooter();
    }


    public void BorrowBook(string isbn)
    {
        Book book = FindByISBN(isbn);

        if (book == null)
        {
            Console.WriteLine("  [!] Book with that ISBN was not found.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine($"  [!] \"{book.Title}\" is currently unavailable (0 copies).");
            return;
        }

        book.CopiesAvailable--;  
        Console.WriteLine($"  [✓] You have borrowed \"{book.Title}\". " +
                          $"Copies remaining: {book.CopiesAvailable}");
    }

  
    public void ReturnBook(string isbn)
    {
        Book book = FindByISBN(isbn);

        if (book == null)
        {
            Console.WriteLine("  [!] Book with that ISBN was not found.");
            return;
        }

        book.CopiesAvailable++;
        Console.WriteLine($"  [✓] \"{book.Title}\" returned. " +
                          $"Copies now available: {book.CopiesAvailable}");
    }

 
    public void DisplayStatistics()
    {
        Console.WriteLine("\n=== Library Statistics ===");

        if (books.Count == 0)
        {
            Console.WriteLine("  The library has no books yet.");
            return;
        }

        // Total unique titles
        int totalBooks = books.Count;

        // Total physical copies across all books
        int totalCopies = 0;
        foreach (Book b in books)
            totalCopies += b.CopiesAvailable;

        // Most expensive book – iterate to find the max price
        Book mostExpensive = books[0];
        foreach (Book b in books)
            if (b.Price > mostExpensive.Price)
                mostExpensive = b;

        // Books per category – use a Dictionary for O(1) look-ups
        Dictionary<string, int> categoryCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (Book b in books)
        {
            if (categoryCount.ContainsKey(b.Category))
                categoryCount[b.Category]++;
            else
                categoryCount[b.Category] = 1;
        }

        Console.WriteLine($"  Total unique titles  : {totalBooks}");
        Console.WriteLine($"  Total copies available: {totalCopies}");
        Console.WriteLine($"  Most expensive book  : \"{mostExpensive.Title}\" by {mostExpensive.Author} ({mostExpensive.Price:C})");
        Console.WriteLine("\n  Books per category:");
        foreach (var entry in categoryCount)
            Console.WriteLine($"    {entry.Key,-20} : {entry.Value}");
    }

   
    private Book FindByISBN(string isbn)
    {
        foreach (Book b in books)
            if (b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
                return b;
        return null;
    }

    private void PrintTableHeader()
    {
        Console.WriteLine(new string('-', 85));
        Console.WriteLine($"  {"ISBN",-12} {"Title",-30} {"Author",-22} {"Price",8}  {"Copies",6}  {"Available"}");
        Console.WriteLine(new string('-', 85));
    }

    private void PrintBookRow(Book b)
    {
        string available = b.IsAvailable ? "Yes" : "No";
        Console.WriteLine($"  {b.ISBN,-12} {b.Title,-30} {b.Author,-22} {b.Price,8:C}  {b.CopiesAvailable,6}  {available}");
    }

    private void PrintTableFooter()
    {
        Console.WriteLine(new string('-', 85));
    }
}

} 