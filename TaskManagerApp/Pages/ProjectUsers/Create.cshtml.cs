using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.ProjectUsers
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
        ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public ProjectUser ProjectUser { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            _context.ProjectUser.Add(ProjectUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
