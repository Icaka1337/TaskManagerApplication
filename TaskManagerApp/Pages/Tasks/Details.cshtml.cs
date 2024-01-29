using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public DetailsModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        public Models.Task Task { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                Task = task;
            }
            return Page();
        }
    }
}
