using LibraryManagement.Models.DTOs;

namespace LibraryManagement.Models
{
    public class BookEntity:BookBaseDTO
    {
        public Guid Id { get; set; }
    }
}
