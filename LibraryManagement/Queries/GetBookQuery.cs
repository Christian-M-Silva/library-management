using LibraryManagement.Models.Entities;
using MediatR;

namespace LibraryManagement.Queries
{
    public class GetBookQuery: IRequest<BookEntity>
    {
        public Guid Id { get; set; }
    }
}
