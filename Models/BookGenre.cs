using System.ComponentModel.DataAnnotations;

namespace PaulBejinariu_Project.Models
{
    public class BookGenre
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string? Genre { get; set; }
    }
}
