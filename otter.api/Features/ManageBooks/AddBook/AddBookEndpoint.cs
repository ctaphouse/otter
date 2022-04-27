using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using otter.api.Persistence;
using otter.api.Persistence.Entities;
using otter.shared.Features.ManageBooks.AddBook;

namespace otter.api.Features.ManageBooks.AddBook;

public class AddBookEndpoint : EndpointBaseAsync.WithRequest<AddBookRequest>.WithActionResult<AddBookRequest.Response>
{
    private readonly OtterContext _context;

    public AddBookEndpoint(OtterContext context)
    {
        _context = context;
    }
   
   [HttpPost(AddBookRequest.RouteTemplate)]
    public override async Task<ActionResult<AddBookRequest.Response>> HandleAsync(AddBookRequest request, CancellationToken cancellationToken = default)
    {
        var book = new Book {
            Id = request.Book.Id,
            Name = request.Book.Name,
            CategoryId = request.Book.CategoryId
        };

        await _context.Books.AddAsync(book, cancellationToken);

        var bookLibraries = request.Book.Libraries.Select(l => new BookLibrary {
            BookId = book.Id,
            LibraryId = l.Id
        });

        await _context.BookLibrary.AddRangeAsync(bookLibraries, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(book.Id);
    }
}
