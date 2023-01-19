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
                Book = bookToAdd,
                TimeSpent = 1
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
            if (bookRead == null)
            {
                return NotFound();
            }    
            _context.BookRead.Remove(bookRead);
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> Index(int id, string handler)
        {
            if (handler == "Add")
            {
                return await OnPostAddAsync(id);
            }
            else if (handler == "Remove")
            {
                return await OnPostRemoveAsync(id);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
