namespace LibraryManagement.Models.DTOs
{
    public class BookBaseDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public string? Gender { get; set; }
        public bool IsRemoved { get; set; }
    }
}
