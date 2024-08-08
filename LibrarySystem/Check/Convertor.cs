namespace LibrarySystem.Convertor;

internal static class Convertors
{
    public static int GetUserChoice()
    {
        while (true)
        {
            try
            {
                int console = Convert.ToInt32(Console.ReadLine());

                if (console < 0)
                {
                    Console.WriteLine("ты еблан");
                    continue;
                }

                return console;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Слишком большое число, повторите попытку!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Не верный формат, повторите попытку!");
            }
        }
    }

    public static string GetUserString()
    {
        while (true)
        {
            try
            {
                string console = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(console))
                {
                    throw new ArgumentException("Не может быть пустой строки!");
                }

                return console;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }

    public static string GetUserPoint()
    {
        while (true)
        {
            try
            {
                string console = Console.ReadLine()!;

                if (String.IsNullOrWhiteSpace(console) || console!.Length > 1)
                {
                    throw new ArgumentException("Выберите пункт меню!");
                }

                return console;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }
}