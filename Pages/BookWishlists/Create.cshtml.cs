using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaulBejinariu_Project.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace PaulBejinariu_Project.Pages.BookWishlists
{
    public class CreateModel : PageModel
    {
        private readonly Data.PaulBejinariu_ProjectContext _context;

        public CreateModel(Data.PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BookGenreId"] = new SelectList(_context.BookGenre, "Id", "Genre");
            var books = _context.Book.ToList();
            Books = books;
            return Page();
        }



        [BindProperty]
        public BookWishlist BookWishlist { get; set; }
        public IEnumerable<Book> Books { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookWishlist.Add(BookWishlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
