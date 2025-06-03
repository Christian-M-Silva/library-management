using MediatR;

namespace LibraryManagement.Commands
{
    public class RemoveBookCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
