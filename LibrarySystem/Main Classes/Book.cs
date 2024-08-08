namespace LibrarySystem.Main_Classes;

public class Book(int id, string title, string author)
{
    public int Id { get; set; } = id;

    public string Title { get; set; } = title;

    public string Author { get; set; } = author;
}