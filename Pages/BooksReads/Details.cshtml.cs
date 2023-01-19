using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BooksReads
{
    public class DetailsModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public DetailsModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public BookRead BookRead { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookRead == null)
            {
                return NotFound();
            }

            var bookRead = await _context.BookRead
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bookRead == null)
            {
                return NotFound();
            }
            else
            {
                BookRead = bookRead;
            }
            return Page();
        }
    }
}
