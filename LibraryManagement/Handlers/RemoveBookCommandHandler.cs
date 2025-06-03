using LibraryManagement.Commands;
using LibraryManagement.Exceptions;
using LibraryManagement.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Handlers
{
    public class RemoveBookCommandHandler(MyDbContext myDbContext) : IRequestHandler<RemoveBookCommand>
    {
		private readonly MyDbContext _myDbContext = myDbContext;
        public async Task Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
			try
			{
				BookEntity? book = await _myDbContext.Books.FirstOrDefaultAsync(bookEntity =>
				bookEntity.Id == request.Id && bookEntity.IsRemoved == false, cancellationToken: cancellationToken)
					??
					throw new NotFoundException();
                book.IsRemoved = true;
				await _myDbContext.SaveChangesAsync(cancellationToken);
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
        }
    }
}
