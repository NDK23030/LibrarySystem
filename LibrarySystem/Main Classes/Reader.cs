namespace LibrarySystem.Main_Classes;

public class Reader(int id, string name)
{
    public int Id { get; set; } = id;

    public string Name { get; set; } = name;

    public IEnumerable<Book> BorrowedBooks { get; set; } = new List<Book>();
}