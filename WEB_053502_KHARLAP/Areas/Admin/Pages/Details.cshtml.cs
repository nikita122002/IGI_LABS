using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053502_KHARLAP.Entities;

namespace WEB_053502_KHARLAP.Areas.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_053502_KHARLAP.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_053502_KHARLAP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(g => g.Group).FirstOrDefaultAsync(m => m.CarId == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
