using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stoia_Alin_Lab2.Data;
using Stoia_Alin_Lab2.Models;

namespace Stoia_Alin_Lab2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Stoia_Alin_Lab2.Data.Stoia_Alin_Lab2Context _context;

        public EditModel(Stoia_Alin_Lab2.Data.Stoia_Alin_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }
            Book = await _context.Book
             .Include(b => b.Publisher)
             .Include(b => b.BookCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);
            //  var book =  await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Book);

            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName

            });


            Book = book;
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            ViewData["AuthorID"] = new SelectList(authorList, "ID",
"FullName");
            return Page();
        }
    }

    private bool BookExists(int id)
    {
        return _context.Book.Any(e => e.ID == id);
    }
    //}
}
