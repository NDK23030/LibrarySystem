using LibrarySystem.Checks;
using LibrarySystem.Convertor;
using static LibrarySystem.Menu.ConsoleMenu;

namespace LibrarySystem.Main_Classes;

public static class Library
{
    private static List<Book> _books = new List<Book>();
    private static List<Reader> _readers = new List<Reader>();
    private static List<BorrowHistory> _history = new List<BorrowHistory>();

    public static void AddBook()
    {
        Console.Clear();
        Console.WriteLine("Id Книги?");
        int id = Convertors.GetUserChoice();

        Console.WriteLine("Название книги ");
        string title = Convertors.GetUserString();

        Console.WriteLine("Имя автора?");
        string author = Convertors.GetUserString();
        var book = new Book(id, title, author);

        _books.Add(book);        
    }

    public static void AddReader()
    {
        Console.Clear();
        Console.WriteLine("Id Читателя?");
        int id = Convertors.GetUserChoice();

        Console.WriteLine("Имя читателя?");
        string name = Convertors.GetUserString();
        var reader = new Reader(id, name);

        _readers.Add(reader);        
    }

    public static void BorrowBook()
    {
        Console.Clear();
        Console.WriteLine("Id книги?");
        int idBook = Check.CheckIdBook(_books);
        var book = _books
            .Find(book => book.Id == idBook);

        Console.WriteLine("Id читателя?");
        int idReader = Check.CheckIdReader(_readers);
        var reader = _readers
            .Find(reader => reader.Id == idReader);

        Check.CheckHistory(_history, idBook);
        Console.WriteLine("На сколько дней?");
        int days = Convertors.GetUserChoice();
        var borrow = new BorrowHistory(idBook, idReader, days, false);

        reader!.BorrowedBooks.Add(book!);
        _history.Add(borrow);
        Console.WriteLine("Книга успешно выдана");
        Console.ReadKey();
        CreateMenu();
    }

    public static void ReturnBook()
    {
        Console.Clear();
        Console.WriteLine("Id книги?");
        int idBook = Check.CheckIdBook(_books);
        var book = _books
            .Find(book => book.Id == idBook);

        Console.WriteLine("Id читателя?");
        int idReader = Check.CheckIdReader(_readers);
        var reader = _readers
            .Find(reader => reader.Id == idReader);

        Check.CheckOfIssue(_history, idBook);

        foreach (var log in _history)
        {
            if (log.BookId == idBook)
            {
                log.IsReturned = true;
                reader!.BorrowedBooks.Remove(book!);
                Console.WriteLine("Книга возвращена");
                Console.ReadKey();
            }
        }
    }

    public static void GetAllBooks()
    {
        Console.Clear();
        Check.CheckEmptyBookList(_books);
        Console.ReadKey();
        CreateMenu();
    }

    public static void GetAllReaders()
    {
        Console.Clear();
        Check.CheckEmptyReadersList(_readers);
        Console.ReadLine();
        CreateMenu();
    }

    public static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("Введите название книги или автора книги: ");        
        Check.CheckAvailabilityBook(_books, Convertors.GetUserString());
        Console.ReadKey();
        CreateMenu();
    }

    public static void SearchReader()
    {
        Console.Clear();
        Console.WriteLine("Введите имя читатея: ");
        Check.CheckAvailabilityReader(_readers, Convertors.GetUserString());        
    }

    public static void GetOverdueBooks()
    {
        Console.Clear();
        Console.WriteLine("Cписок просроченных книг: ");
        Check.CheckOverdueBooks(_history, _books, _readers);
    }
}
