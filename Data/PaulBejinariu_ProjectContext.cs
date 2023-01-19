using Microsoft.EntityFrameworkCore;

namespace PaulBejinariu_Project.Data
{
    public class PaulBejinariu_ProjectContext : DbContext
    {
        public PaulBejinariu_ProjectContext(DbContextOptions<PaulBejinariu_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Book> Book { get; set; } = default!;

        public DbSet<Models.BookGenre> BookGenre { get; set; }

        public DbSet<Models.BookReview> BookReview { get; set; }

        public DbSet<Models.BookRead> BookRead { get; set; }

        public DbSet<Models.BookWishlist> BookWishlist { get; set; }
    }
}
