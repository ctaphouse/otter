namespace otter.api.Persistence.Entities;

public class BookLibrary
{
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public int LibraryId { get; set; }
    public Library Library { get; set; } = default!;
}