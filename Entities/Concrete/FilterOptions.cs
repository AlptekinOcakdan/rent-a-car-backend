namespace Entities.Concrete
{
    public class FilterOptions
    {
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinModelYear { get; set; }
    }
}
