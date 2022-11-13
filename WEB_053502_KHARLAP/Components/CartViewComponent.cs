using Microsoft.AspNetCore.Mvc;
using WEB_053502_KHARLAP.Models;

namespace WEB_053502_KHARLAP.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
