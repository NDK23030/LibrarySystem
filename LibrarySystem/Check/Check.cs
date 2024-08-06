using LibrarySystem.Main_Classes;
using static LibrarySystem.Menu.ConsoleMenu;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystem.Checks;

public static class Check
{
    public static int CheckIdBook(List<Book> books)
    {
        int idBook = Convert.ToInt32(Console.ReadLine());

        try
        {
            if (books.Find(book => book.Id == idBook) == null)
            {
                throw new Exception("Книги нет в библиотеке!");
            }
            else
            {
                return idBook;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return CheckIdBook(books);
        }
    }

    public static int CheckIdReader(List<Reader> readers)
    {
        int idReader = Convert.ToInt32(Console.ReadLine());

        try
        {
            if (readers.Find(reader => reader.Id == idReader) == null)
            {

                throw new Exception("Читатель не зарегистрирован!");
            }
            else
            {
                return idReader;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return CheckIdReader(readers);
        }
    }

    public static void CheckHistory(List<BorrowHistory> history, int idBook)
    {
        try
        {
            if (history.Find(log => log.BookId == idBook) != null)
            {
                throw new Exception("Книга выдана другому пользователю!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            CreateMenu();
        }
    }

    public static void CheckOfIssue(List<BorrowHistory> history, int idBook)
    {
        try
        {
            if (history.Find(log => log.BookId == idBook).BookId == idBook && history.Find(log => log.BookId == idBook).IsReturned == true)
            {
                throw new Exception("Данная книга не выдавалась");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            CreateMenu();
        }
    }

    public static void CheckEmptyBookList(List<Book> books)
    {
        try
        {
            if (books.Count == 0)
            {
                throw new Exception("Список книг пуст");
            }

            foreach (var book in books)
            {
                Console.WriteLine($"Книга №{book.Id}. {book.Title} - {book.Author}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            CreateMenu();
        }
    }

    public static void CheckEmptyReadersList(List<Reader> readers)
    {
        try
        {
            if (readers.Count == 0)
            {
                throw new Exception("Список читателей пуст");
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            CreateMenu();
        }
    }

    public static void CheckAvailabilityBook(List<Book> books, string query)
    {
        try
        {
            var bookByTitle = books
                .Find(book => book.Title == query);
            var booksByAuthor = books
                .FindAll(book => book.Author == query);

            if (bookByTitle == null && booksByAuthor.Count == 0)
            {
                throw new Exception("Книги нет в библиотеке!");
                
            }
            else if (booksByAuthor.Count == 0)
            {
                Console.WriteLine($"Книга №{bookByTitle.Id}. {bookByTitle.Title} - {bookByTitle.Author}");
            }
            else
            {
                foreach (var bookByAuthor in booksByAuthor)
                {
                    Console.WriteLine($"Книга №{bookByAuthor.Id}. {bookByAuthor.Title} - {bookByAuthor.Author}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            CreateMenu();
        }
    }

    public static void CheckAvailabilityReader(List<Reader> readers, string query)
    {
        try
        {
            if (readers.Find(reader => reader.Name == query) == null)
            {
                throw new Exception("Читатель не зарегистрирован!");
            }
            else
            {
                var reader = readers.Find(reader => reader.Name == query);

                Console.WriteLine($"Читатель №{reader.Id}. {reader.Name}. \nСписок взятых книг: ");
                foreach (var book in reader.BorrowedBooks)
                {
                    Console.WriteLine($"Книга №{book.Id}. {book.Title} - {book.Author}");
                }                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    public static void CheckOverdueBooks(List<BorrowHistory> history, List<Book> books, List<Reader> readers)
    {
        try
        {
            var overdueList = history
                .FindAll(log => DateTime.Compare(DateTime.Now, log.ReturnTime) > 0 && !log.IsReturned);

            if (overdueList.Count == 0)
            {
                throw new Exception("Просроченных книг нет");
            }
            else
            {
                foreach (var overdue in overdueList)
                {
                    var book = books
                        .Find(book => book.Id == overdue.BookId);
                    var reader = readers
                        .Find(reader => reader.Id == overdue.ReaderId);

                    Console.WriteLine($"Читатель {reader.Name} не вернул книгу {book.Title} в срок");
                }
                Console.ReadLine();
                CreateMenu();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            CreateMenu();
        }
    }
}