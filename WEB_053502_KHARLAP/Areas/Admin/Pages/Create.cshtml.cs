using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_053502_KHARLAP.Entities;

namespace WEB_053502_KHARLAP.Areas.Admin
{
    public class CreateModel : PageModel
    {
        private readonly WEB_053502_KHARLAP.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WEB_053502_KHARLAP.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
            ViewData["CarGroupId"] = new SelectList(_context.CarGroups, "CarGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            if (Image != null)
            {
                var fileName = $"{Car.CarId}" + Path.GetExtension(Image.FileName);
                Car.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);

                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
