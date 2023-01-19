using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaulBejinariu_Project.Models
{
    public class BookWishlist
    {
        public int Id { get; set; }

        [Required, DisplayName("Book Genre")]
        public int BookGenreId { get; set; }

        [DisplayName("Book Genre")]
        public BookGenre? BookGenre { get; set; }

        [DisplayName("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
