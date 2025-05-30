using LibraryManagement.Commands;
using LibraryManagement.Exceptions;
using LibraryManagement.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Handlers
{
    public class EditBookCommandHandler(MyDbContext dbContext) : IRequestHandler<EditBookCommand>
    {
		private readonly MyDbContext _dbContext = dbContext;
        public async Task Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
			try
			{
				BookEntity? bookEntity = await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id && book.IsRemoved == false, cancellationToken: cancellationToken);
                if (bookEntity == null)
                {
                    throw new NotFoundException("book not found");
                }

                if (request.PublishYear is int year)
                {
                    bookEntity.PublishYear = year;
                }

                if (request.Title is string title)
                {
                    bookEntity.Title = title;
                }

                if (request.Gender is string gender)
                {
                    bookEntity.Gender = gender;
                }

                if (request.Author is string author)
                {
                    bookEntity.Author = author;
                }

                await _dbContext.SaveChangesAsync(cancellationToken);

            }
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
        }
    }
}
