using MediatR;
using otter.shared.Features.ManageBooks.Shared;

namespace otter.shared.Features.ManageBooks.AddBook;

public record AddBookRequest(BookDto Book) : IRequest<AddBookRequest.Response>
{
    public const string RouteTemplate = "api/books";
    public record Response(int BookId);
}