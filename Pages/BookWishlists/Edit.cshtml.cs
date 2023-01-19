using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BookWishlists
{
    public class EditModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public EditModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookWishlist BookWishlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookWishlist == null)
            {
                return NotFound();
            }

            var bookwishlist = await _context.BookWishlist.FirstOrDefaultAsync(m => m.Id == id);
            if (bookwishlist == null)
            {
                return NotFound();
            }
            BookWishlist = bookwishlist;
            ViewData["BookGenreId"] = new SelectList(_context.BookGenre, "Id", "Genre");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookWishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookWishlistExists(BookWishlist.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookWishlistExists(int id)
        {
            return _context.BookWishlist.Any(e => e.Id == id);
        }
    }
}
