using Microsoft.AspNetCore.Mvc.Rendering;

namespace PaulBejinariu_Project.Models
{
    public class BookSelectList : SelectList
    {
        public BookSelectList(IEnumerable<Book> items) : base(items, "Id", "Name") { }
    }
}
