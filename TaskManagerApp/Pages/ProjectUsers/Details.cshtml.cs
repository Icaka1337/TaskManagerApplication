using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.ProjectUsers
{
    public class DetailsModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public DetailsModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        public ProjectUser ProjectUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectuser = await _context.ProjectUser.FirstOrDefaultAsync(m => m.UserId == id);
            if (projectuser == null)
            {
                return NotFound();
            }
            else
            {
                ProjectUser = projectuser;
            }
            return Page();
        }
    }
}
