namespace otter.shared.Features.ManageBooks.Shared;

public class BookDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int CategoryId { get; set; }
    public ICollection<Library> Libraries { get; set; } = new List<Library>();

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class BookLibrary
    {
        public int BookId { get; set; }
        public BookDto Book { get; set; } = default!;
        public int LibraryId { get; set; } = default!;
        public Library Library { get; set; } = default!;
    }

    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
    }
}