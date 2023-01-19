using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> OnPostAddAsync(int id)
        {
            var bookToAdd = await _context.Book.FindAsync(id);
            if (bookToAdd == null)
            {
                return NotFound();
            }
            bookToAdd.IsRead = true;
            var bookRead = new BookRead
            {
                BookId = bookToAdd.Id,
                Book = bookToAdd
            };
            _context.BookRead.Add(bookRead);
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostRemoveAsync(int id)
        {
            var bookToRemove = await _context.Book.FindAsync(id);
            if (bookToRemove == null)
            {
                return NotFound();
            }
            bookToRemove.IsRead = false;
            var bookRead = await _context.BookRead.Where(b => b.BookId == id).FirstOrDefaultAsync();
            _context.BookRead.Remove(bookRead);
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }
    }
}
