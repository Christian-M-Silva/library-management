using LibraryManagement.Models.DTOs;
using MediatR;

namespace LibraryManagement.Commands
{
    public class RegisterBookCommand:BookBaseDTO, IRequest<Guid>
    {
    }
}
