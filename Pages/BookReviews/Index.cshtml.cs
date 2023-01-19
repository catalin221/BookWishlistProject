using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BookReviews
{
    public class IndexModel : PageModel
    {
        private readonly PaulBejinariu_Project.Data.PaulBejinariu_ProjectContext _context;

        public IndexModel(PaulBejinariu_Project.Data.PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public IList<BookReview> BookReview { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookReview != null)
            {
                BookReview = await _context.BookReview
                .Include(b => b.Book)
                .ToListAsync();
            }
        }
    }
}
