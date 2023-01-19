using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaulBejinariu_Project.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        [Required]
        public string? Review { get; set; }

        [Required]
        [Range(0, 10)]
        [Column(TypeName = "decimal(2, 1)")]
        public decimal? Rating { get; set; } = 0;
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
