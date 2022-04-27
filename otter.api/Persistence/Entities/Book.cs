namespace otter.api.Persistence.Entities;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int CategoryId { get; set; }
    public ICollection<Library> Libraries { get; set; } = new List<Library>();
}