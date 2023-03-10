using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Common.Contracts;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public IndexModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
