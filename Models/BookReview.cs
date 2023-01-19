using System.ComponentModel.DataAnnotations;

namespace PaulBejinariu_Project.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        [Required]
        public string? Review { get; set; }
        [Required]
        public int? Rating { get; set; } = 0;
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
