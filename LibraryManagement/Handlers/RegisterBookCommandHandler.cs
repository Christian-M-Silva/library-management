using LibraryManagement.Commands;
using LibraryManagement.Models.Entities;
using MediatR;

namespace LibraryManagement.Handlers
{
    public class RegisterBookCommandHandler(MyDbContext dbContext) : IRequestHandler<RegisterBookCommand, Guid>
    {
		private readonly MyDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(RegisterBookCommand request, CancellationToken cancellationToken)
        {
			try
			{
				Guid id = Guid.NewGuid();
				BookEntity book = new()
				{
					Id = id,
					IsRemoved = false,
					Author = request.Author,
					Gender = request.Gender,
					PublishYear = request.PublishYear,
					Title = request.Title
                };
				_dbContext.Books.Add(book);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return id;
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
        }
    }
}
