using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BookReviews
{
    public class CreateModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public CreateModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public BookReview BookReview { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookReview.Add(BookReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
