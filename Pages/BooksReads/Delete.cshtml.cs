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
    public class DeleteModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public DeleteModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookRead BookRead { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookRead == null)
            {
                return NotFound();
            }

            var BookRead = await _context.BookRead.FirstOrDefaultAsync(m => m.Id == id);

            if (BookRead == null)
            {
                return NotFound();
            }
            else 
            {
                BookRead = BookRead;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookRead == null)
            {
                return NotFound();
            }
            var BookRead = await _context.BookRead.FindAsync(id);

            if (BookRead != null)
            {
                BookRead = BookRead;
                _context.BookRead.Remove(BookRead);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
