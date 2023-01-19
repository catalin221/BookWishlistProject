using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BookWishlists
{
    public class IndexModel : PageModel
    {
        private readonly Data.PaulBejinariu_ProjectContext _context;

        public IndexModel(Data.PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public IList<BookWishlist> BookWishlist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookWishlist != null)
            {
                BookWishlist = await _context.BookWishlist
                .Include(b => b.BookGenre)
                .Include(b => b.Book)
                .ToListAsync();
            }
        }
    }
}
