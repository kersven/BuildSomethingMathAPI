using MathApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MathApp.Pages
{
    public class Logs : PageModel
    {
        private readonly AppDbContext _dbContext;

        public Logs(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<RequestLog> RequestLogs { get; set; }

        public async Task OnGetAsync()
        {
            RequestLogs = await _dbContext.RequestLogs.ToListAsync();
        }
    }
}
