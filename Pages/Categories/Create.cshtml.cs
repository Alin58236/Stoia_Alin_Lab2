﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stoia_Alin_Lab2.Data;
using Stoia_Alin_Lab2.Models;

namespace Stoia_Alin_Lab2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Stoia_Alin_Lab2.Data.Stoia_Alin_Lab2Context _context;

        public CreateModel(Stoia_Alin_Lab2.Data.Stoia_Alin_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
