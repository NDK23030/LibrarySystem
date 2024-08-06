namespace LibrarySystem.Main_Classes;

public class BorrowHistory(int idBook, int idReader, int days, bool isReturn)
{
    public int BookId { get; set; } = idBook;

    public int ReaderId { get; set; } = idReader;

    public DateTime BorrowDate { get; set; } = DateTime.Now;

    public DateTime ReturnTime { get; set; } = DateTime.Now.AddDays(days);

    public bool IsReturned { get; set; } = isReturn;
}