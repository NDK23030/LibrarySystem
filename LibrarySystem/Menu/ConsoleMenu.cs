using LibrarySystem.Main_Classes;

namespace LibrarySystem.Menu;

public static class ConsoleMenu
{
    public static void CreateMenu()
    {
        Console.Clear();
        Console.WriteLine("Выберите пункт меню:");
        Console.WriteLine("1. Добавить книгу");
        Console.WriteLine("2. Добавить читателя");
        Console.WriteLine("3. Выдать книгу");
        Console.WriteLine("4. Вернуть книгу");
        Console.WriteLine("5. Отобразить список всех книг");
        Console.WriteLine("6. Отобразить список всех читателей");
        Console.WriteLine("7. Поиск книги");
        Console.WriteLine("8. Поиск читателя");
        Console.WriteLine("9. Просроченные книги");
        Console.WriteLine("0. Выход");
        
        string? point = Console.ReadLine();

        if (point == null || point == "" || point.Length > 1)
        {
            Console.WriteLine("Выберете пункт!!!");
            CreateMenu();
        }

        switch (char.Parse(point))
        {
            case '1':
                Library.AddBook();
                CreateMenu();
                break;
            case '2':
                Library.AddReader();
                CreateMenu();
                break;
            case '3':
                Library.BorrowBook();
                CreateMenu();
                break;
            case '4':
                Library.ReturnBook();
                CreateMenu();
                break;
            case '5':
                Library.GetAllBooks();
                break;
            case '6':
                Library.GetAllReaders();
                break;
            case '7':
                Library.SearchBook();
                break;
            case '8':
                Library.SearchReader();
                break;
            case '9':
                Library.GetOverdueBooks();
                break;
            case '0':
                Environment.Exit(0);
                break;
        }
    }

    public static string GetPoint()
    {
        string? point = Console.ReadLine();

        if (point == null || point == "" || point.Length > 1)
        {
            Console.WriteLine("Выберете пункт!!!");
            return GetPoint();
        }
        return point;
    }
}
