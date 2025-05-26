using LibraryManagement.Models.DTOs;

namespace LibraryManagement.Models.Entities
{
    public class BookEntity:BookBaseDTO
    {
        public Guid Id { get; set; }
		private DateTime? _createAt;

		public DateTime? CreateAt
		{
			get { return _createAt; }
            set { _createAt = DateTime.UtcNow; }
		}

        public DateTime? UpdateAt { get; set; }
    }
}
