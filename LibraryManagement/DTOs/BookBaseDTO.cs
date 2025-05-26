namespace LibraryManagement.DTOs
{
    public class BookBaseDTO
    {
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public int PublishYear { get; set; }
        public string? Gender { get; set; }
        public bool IsRemoved { get; set; }
    }
}
