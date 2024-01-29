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
    public class IndexModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public IndexModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        public IList<ProjectUser> ProjectUser { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            ProjectUser = await _context.ProjectUser
                .Include(p => p.Project)
                .Include(p => p.User).ToListAsync();
        }
    }
}
