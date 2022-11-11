using Microsoft.AspNetCore.Mvc;
using WEB_053502_KHARLAP.Data;
using WEB_053502_KHARLAP.Models;
using WEB_053502_KHARLAP.Entities;

namespace WEB_053502_KHARLAP.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        private int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var carsFiltered = _context.Cars.Where(d => !group.HasValue || d.CarGroupId == group.Value);
            ViewData["Groups"] = _context.CarGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Car>.GetModel(carsFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

    }
}
