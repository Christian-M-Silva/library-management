using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Commands
{
    public class EditBookCommand
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? PublishYear { get; set; }
        public string? Gender { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}
