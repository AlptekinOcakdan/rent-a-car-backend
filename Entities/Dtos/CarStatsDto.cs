using Core.Entities;

namespace Entities.Dtos
{
    public class CarStatsDto:IDto
    {
        public int Id { get; set; }
        public int TotalIncome { get; set; }
        public int TotalRentals { get; set; }
    }
}
