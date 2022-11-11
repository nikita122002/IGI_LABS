namespace WEB_053502_KHARLAP.Entities
{
    public class CarGroup
    {
        public int CarGroupId { get; set; }
        public string GroupName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
