using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Paul.Pages.BooksReads
{
    public class IndexModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public IndexModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public IList<BookRead> BookRead { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookRead != null)
            {
                BookRead = await _context.BookRead.ToListAsync();
            }
        }
    }
}
