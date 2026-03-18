# Library Management System

**Student:** Uche Solomon Ali
**Assignment:** Option 1 – Library Management System  
**Course:** .NET / C# Week 5 Assignment

---

## Description

A C# console application that manages a library's book collection. Users can add books, search by title or author, filter by category, borrow and return books, and view library-wide statistics — all through an interactive menu.

---

## How to Run

**Requirements:** .NET 8 SDK (or .NET 6+)

```bash
# Clone the repository
git clone https://github.com/solowiseCV/dotnet-week5-assignment.git
cd dotnet-week5-assignment

# Build and run
dotnet run
```

The app launches with 7 pre-loaded sample books so every menu option can be explored immediately.

---

## Features Implemented

- **Book class** with auto-implemented and validated properties (`Price >= 0`, `CopiesAvailable >= 0`) and a computed read-only `IsAvailable` property  
- **Library class** with a private `List<Book>` and all 8 required methods:
  - `AddBook` – adds a book to the collection  
  - `DisplayAllBooks` – formatted table of all books  
  - `SearchByTitle` – partial, case-insensitive title search  
  - `SearchByAuthor` – partial, case-insensitive author search  
  - `DisplayBooksByCategory` – filters by category  
  - `BorrowBook` – decrements copies (with availability check)  
  - `ReturnBook` – increments copies  
  - `DisplayStatistics` – totals, most expensive book, per-category counts  
- **Menu-driven main program** with a `while` loop and `switch` statement  
- Full **input validation** on all user-entered fields  
- 7 pre-loaded sample books across multiple categories  

---

## Project Structure

```
LibraryManagementSystem/
├── Book.cs                      # Book entity with properties & validation
├── Library.cs                   # Library class with list management
├── Program.cs                   # Entry point, menu, input handling
├── LibraryManagementSystem.csproj
├── .gitignore
└── README.md
```

---

## Challenges

- **Property validation without throwing exceptions:** Used silent guard clauses inside setters (print a message and keep the old value) so the object always stays valid.  
- **Partial search:** `String.IndexOf` with `OrdinalIgnoreCase` was cleaner than `Contains` + `ToLower()` for case-insensitive partial matching.  
- **Per-category counting:** A `Dictionary<string, int>` was chosen over a second list scan because it collects counts in a single pass and makes look-ups O(1).