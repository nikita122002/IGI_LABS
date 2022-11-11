using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB_053502_KHARLAP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 5";
            ViewData["Lst"] =
                new SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }

        public class ListDemo
        {
            public int ListItemValue { get; set; }
            public string ListItemText { get; set; }
        }

        private List<ListDemo> _listDemo;
        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"}
            };
        }


    }
}
