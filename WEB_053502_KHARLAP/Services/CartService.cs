using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using WEB_053502_KHARLAP.Entities;
using WEB_053502_KHARLAP.Models;
using WEB_053502_KHARLAP.Data;

namespace WEB_053502_KHARLAP.Services
{
    public class CartService : Cart
    {
        private string sessionKey = "cart";

        [JsonIgnore]
        ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider sp)
        {
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var cart = session?.Get<CartService>("cart")
            ?? new CartService();
            cart.Session = session;
            return cart;
        }

        public override void AddToCart(Car car)
        {
            base.AddToCart(car);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}
