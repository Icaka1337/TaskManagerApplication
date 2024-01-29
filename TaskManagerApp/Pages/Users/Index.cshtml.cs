using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly TaskManagerApp.Data.TaskManagerDbContext _context;

        public IndexModel(TaskManagerApp.Data.TaskManagerDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
