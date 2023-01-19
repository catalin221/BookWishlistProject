﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaulBejinariu_Project.Data;
using PaulBejinariu_Project.Models;

namespace PaulBejinariu_Project.Pages.BookWishlists
{
    public class DetailsModel : PageModel
    {
        private readonly PaulBejinariu_ProjectContext _context;

        public DetailsModel(PaulBejinariu_ProjectContext context)
        {
            _context = context;
        }

      public BookWishlist BookWishlist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookWishlist == null)
            {
                return NotFound();
            }

            var bookwishlist = await _context.BookWishlist
                .Include(b => b.Book)
                .Include(b => b.BookGenre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookwishlist == null)
            {
                return NotFound();
            }
            else 
            {
                BookWishlist = bookwishlist;
            }
            return Page();
        }
    }
}
