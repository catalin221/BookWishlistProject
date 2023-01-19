using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BookGenres
{
    public class DeleteModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public DeleteModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookGenre BookGenre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookGenre == null)
            {
                return NotFound();
            }

            var bookgenre = await _context.BookGenre.FirstOrDefaultAsync(m => m.Id == id);

            if (bookgenre == null)
            {
                return NotFound();
            }
            else 
            {
                BookGenre = bookgenre;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookGenre == null)
            {
                return NotFound();
            }
            var bookgenre = await _context.BookGenre.FindAsync(id);

            if (bookgenre != null)
            {
                BookGenre = bookgenre;
                _context.BookGenre.Remove(BookGenre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
