using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaulBejinariu_Project.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Book title is required!"), DisplayName("Title"), StringLength(50, ErrorMessage = "Book title cannot be bigger than 50 characters!")]
        public string? Name { get; set; }
        
        [Required, MaxLength(100)]
        public string? Author { get; set; }

        [DisplayName("Link to Shop")]
        public string? LinkToShop { get; set; }

        [DisplayName("Price (RON)")]
        [Required, Range(0, 5000)]
        public decimal? Price { get; set; } = 0;

        [DisplayName("Did you read it?")]
        public bool IsRead { get; set; } = false;
    }
}
