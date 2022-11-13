using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053502_KHARLAP.Entities;

namespace WEB_053502_KHARLAP.Areas.Admin
{
    public class IndexModel : PageModel
    {
        private readonly WEB_053502_KHARLAP.Data.ApplicationDbContext _context;

        public IndexModel(WEB_053502_KHARLAP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(g => g.Group).ToListAsync();
        }
    }
}
