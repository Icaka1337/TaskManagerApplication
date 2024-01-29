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
    public class IndexModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public IndexModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        public IList<Models.Task> Task { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Task = await _context.Tasks.ToListAsync();
        }
    }
}
