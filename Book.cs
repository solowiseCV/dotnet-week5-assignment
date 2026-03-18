

namespace LibraryManagementSystem
{

public class Book
{
    private decimal _price;
    private int _copiesAvailable;
    public string Title    { get; set; }
    public string Author   { get; set; }
    public string ISBN     { get; set; }
    public string Category { get; set; }   

    public decimal Price
    {
        get { return _price; }
        set
        {
          
            if (value >= 0)
                _price = value;
            else
                Console.WriteLine("  [!] Price cannot be negative. Value was not changed.");
        }
    }
    public int CopiesAvailable
    {
        get { return _copiesAvailable; }
        set
        {
            if (value >= 0)
                _copiesAvailable = value;
            else
                Console.WriteLine("  [!] CopiesAvailable cannot be negative. Value was not changed.");
        }
    }

       public bool IsAvailable => CopiesAvailable > 0;

  
    public Book(string title, string author, string isbn,
                decimal price, int copiesAvailable, string category)
    {
        Title            = title;
        Author           = author;
        ISBN             = isbn;
        Price            = price;            // goes through validation
        CopiesAvailable  = copiesAvailable;  // goes through validation
        Category         = category;
    }
}

} 