using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public List<CarImage> Images { get; set; }
    }
}
