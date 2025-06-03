using LibraryManagement.Exceptions;
using LibraryManagement.Models.Entities;
using LibraryManagement.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Handlers
{
    public class GetBookQueryHandler(MyDbContext dbContext) : IRequestHandler<GetBookQuery, BookEntity>
    {
        private readonly MyDbContext _dbContext = dbContext;
        public async Task<BookEntity> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            try
            {
                BookEntity? book = await _dbContext.Books.FirstOrDefaultAsync(bookEntity => bookEntity.Id == request.Id, cancellationToken: cancellationToken);

                return book ?? throw new NotFoundException("book not found");
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
