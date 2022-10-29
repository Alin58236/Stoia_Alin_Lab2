using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stoia_Alin_Lab2.Data;
using Stoia_Alin_Lab2.Models;

namespace Stoia_Alin_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Stoia_Alin_Lab2.Data.Stoia_Alin_Lab2Context _context;

        public IndexModel(Stoia_Alin_Lab2.Data.Stoia_Alin_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
