using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.ProjectUsers
{
    public class EditModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public EditModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectUser ProjectUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectuser =  await _context.ProjectUser.FirstOrDefaultAsync(m => m.UserId == id);
            if (projectuser == null)
            {
                return NotFound();
            }
            ProjectUser = projectuser;
           ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProjectUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectUserExists(ProjectUser.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectUserExists(int id)
        {
            return _context.ProjectUser.Any(e => e.UserId == id);
        }
    }
}
