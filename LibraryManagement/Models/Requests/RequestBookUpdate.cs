namespace LibraryManagement.Models.Requests
{
    public class RequestBookUpdate
    {
        public string? Title { get; set; } = string.Empty;
        public string? Author { get; set; } = string.Empty;
        public int? PublishYear { get; set; }
        public string? Gender { get; set; }
    }
}
