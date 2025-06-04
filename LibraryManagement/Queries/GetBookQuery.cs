using LibraryManagement.Models.Entities;
using MediatR;

namespace LibraryManagement.Queries
{
    public class GetBookQuery: IRequest<List<BookEntity>>
    {
        public Guid? Id { get; set; }
    }
}
