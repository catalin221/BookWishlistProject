using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Models;
using PaulBejinariu_Project.Data;

public class AddRemoveBookReadModel : PageModel
{
    private readonly PaulBejinariu_ProjectContext _context;

    public AddRemoveBookReadModel(PaulBejinariu_ProjectContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> OnPost(int id, string handler)
    {
        if (handler == "Add")
        {
            // Add book logic goes here
            return new JsonResult(new { success = true });
        }
        else if (handler == "Remove")
        {
            // Remove book logic goes here
            return new JsonResult(new { success = true });
        }
        else
        {
            return NotFound();
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
}