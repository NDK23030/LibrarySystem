using LibrarySystem.Convertor;
using LibrarySystem.Main_Classes;
using static LibrarySystem.Menu.ConsoleMenu;

namespace LibrarySystem.Checks;

public static class Check
{
    public static int CheckIdBook(List<Book> books) 
    {
        int idBook = Convertors.GetUserChoice();

        if (books.Find(book => book.Id == idBook) == null)
        {
            Console.WriteLine("Книги нет в библиотеке");
            Console.ReadKey();
            CreateMenu();
        }

        return idBook;
    }

    public static int CheckIdReader(List<Reader> readers)
    {
        int idReader = Convertors.GetUserChoice();

        if (readers.Find(reader => reader.Id == idReader) == null)
        {
            Console.WriteLine("Читатель не зарегистрирован");
            Console.ReadKey();
            CreateMenu();
        }

        return idReader;
    }

    public static void CheckHistory(List<BorrowHistory> history, int idBook)
    {
        if (history.Find(log => log.BookId == idBook) != null)
        {
            Console.WriteLine("Книга выдана другому пользователю!");
            Console.ReadKey();
            CreateMenu();
        }
    }

    public static void CheckOfIssue(List<BorrowHistory> history, int idBook)
    {
        var book = history
            .Find(log => log.BookId == idBook);
        var isReturn = history
            .Find(log => log.BookId == idBook);

        if (book!.BookId == idBook && isReturn!.IsReturned == true)
        {
            Console.WriteLine("Данная книга не выдавалась");
            Console.ReadKey();
            CreateMenu();
        }
    }

    public static void CheckEmptyBookList(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст");
            Console.ReadKey();
            CreateMenu();
        }

        foreach (var book in books)
        {
            Console.WriteLine($"Книга №{book.Id}. {book.Title} - {book.Author}");
        }
    }

    public static void CheckEmptyReadersList(List<Reader> readers)
    {
        if (readers.Count == 0)
        {
            Console.WriteLine("Список читателей пуст");
            Console.ReadKey();
            CreateMenu();
        }

        foreach (var reader in readers)
        {
            Console.WriteLine($"Читатель №{reader.Id}. {reader.Name}. \nСписок взятых книг: ");
            foreach (var book in reader.BorrowedBooks)
            {
                Console.WriteLine($"Книга №{book.Id}. {book.Title} - {book.Author}");
            }
            Console.WriteLine("\n");
        }       
    }

    public static void CheckAvailabilityBook(List<Book> books, string query)
    {
        var bookByTitle = books
            .Find(book => book.Title == query);
        var booksByAuthor = books
            .FindAll(book => book.Author == query);

        if (bookByTitle == null && booksByAuthor.Count == 0)
        {
            Console.WriteLine("Книги нет в библиотеке!");
            Console.ReadKey();
            CreateMenu();                
        }
        else if (booksByAuthor.Count == 0)
        {
            Console.WriteLine($"Книга №{bookByTitle!.Id}. {bookByTitle.Title} - {bookByTitle.Author}");
        }
        else
        {
            foreach (var bookByAuthor in booksByAuthor)
            {
                Console.WriteLine($"Книга №{bookByAuthor.Id}. {bookByAuthor.Title} - {bookByAuthor.Author}");
            }
        }
    }

    public static void CheckAvailabilityReader(List<Reader> readers, string query)
    {
        var reader = readers
            .Find(reader => reader.Name == query);

        if (reader == null)
        {
            Console.WriteLine("Читатель не зарегистрирован!");
            Console.ReadKey();
            CreateMenu();
        }

        Console.WriteLine($"Читатель №{reader!.Id}. {reader.Name}. \nСписок взятых книг: ");

        foreach (var book in reader.BorrowedBooks)
        {
            Console.WriteLine($"Книга №{book.Id}. {book.Title} - {book.Author}");
        }
        Console.ReadKey();
        CreateMenu();
    }

    public static void CheckOverdueBooks(List<BorrowHistory> history, List<Book> books, List<Reader> readers)
    {
        var overdueList = history
            .FindAll(log => DateTime.Compare(DateTime.Now, log.ReturnTime) > 0 && !log.IsReturned);

        if (overdueList.Count == 0)
        {
            Console.WriteLine("Просроченных книг нет");
            Console.ReadKey();
            CreateMenu();
        }
        else
        {
            foreach (var overdue in overdueList)
            {
                var book = books
                    .Find(book => book.Id == overdue.BookId);
                var reader = readers
                    .Find(reader => reader.Id == overdue.ReaderId);

                Console.WriteLine($"Читатель {reader!.Name} не вернул книгу {book!.Title} в срок");
            }
            Console.ReadKey();
            CreateMenu();
        }        
    }
}