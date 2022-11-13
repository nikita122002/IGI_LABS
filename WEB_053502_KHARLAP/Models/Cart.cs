using WEB_053502_KHARLAP.Entities;

namespace WEB_053502_KHARLAP.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// </summary>
        public int Strings
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Car.Price);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="dish">добавляемый объект</param>
        virtual public void AddToCart(Car car)
        {

            // если объект есть в корзине
            // то увеличить количество

            if (Items.ContainsKey(car.CarId))
                Items[car.CarId].Quantity++;
            // иначе - добавить объект в корзину

            else
                Items.Add(car.CarId, new CartItem
                {
                    Car = car,
                    Quantity = 1
                });

        }

        virtual public void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        virtual public void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}
