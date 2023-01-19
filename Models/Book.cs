using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaulBejinariu_Project.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Book title is required!"), DisplayName("Title"), StringLength(150, ErrorMessage = "Book title cannot be bigger than 150 characters!")]
        public string? Name { get; set; }
        
        [Required, MaxLength(100)]
        public string? Author { get; set; }

        [DisplayName("Link to Shop")]
        public string? LinkToShop { get; set; }
    }
}
