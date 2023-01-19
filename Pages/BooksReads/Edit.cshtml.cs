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

namespace PaulBejinariu_Paul.Pages.BooksReads
{
    public class EditModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public EditModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookRead BookRead { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookRead == null)
            {
                return NotFound();
            }

            var BookRead =  await _context.BookRead.FirstOrDefaultAsync(m => m.Id == id);
            if (BookRead == null)
            {
                return NotFound();
            }
            BookRead = BookRead;
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

            _context.Attach(BookRead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookReadExists(BookRead.Id))
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

        private bool BookReadExists(int id)
        {
          return _context.BookRead.Any(e => e.Id == id);
        }
    }
}
