﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public CreateModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Task Task { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
