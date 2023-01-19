using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Paul.Pages.BookReviews
{
    public class DeleteModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public DeleteModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookReview BookReview { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookReview == null)
            {
                return NotFound();
            }

            var bookreview = await _context.BookReview.FirstOrDefaultAsync(m => m.Id == id);

            if (bookreview == null)
            {
                return NotFound();
            }
            else 
            {
                BookReview = bookreview;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookReview == null)
            {
                return NotFound();
            }
            var bookreview = await _context.BookReview.FindAsync(id);

            if (bookreview != null)
            {
                BookReview = bookreview;
                _context.BookReview.Remove(BookReview);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
