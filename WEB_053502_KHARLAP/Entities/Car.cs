namespace WEB_053502_KHARLAP.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        public int CarGroupId { get; set; }
        public CarGroup Group { get; set; }

    }
}
