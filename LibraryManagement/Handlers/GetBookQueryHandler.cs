using LibraryManagement.Exceptions;
using LibraryManagement.Models.Entities;
using LibraryManagement.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Handlers
{
    public class GetBookQueryHandler(MyDbContext dbContext) : IRequestHandler<GetBookQuery, List<BookEntity>>
    {
        private readonly MyDbContext _dbContext = dbContext;
        public async Task<List<BookEntity>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _dbContext.Books.Where(b => b.IsRemoved == false);

                if (request.Id is not null)
                {
                    query = query.Where(b => b.Id == request.Id);
                }
                List<BookEntity> book = await query.ToListAsync(cancellationToken: cancellationToken);

                return book ?? throw new NotFoundException();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
