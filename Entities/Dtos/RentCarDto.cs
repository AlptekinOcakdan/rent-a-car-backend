using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class RentCarDto:IDto
    {
        public Rental Rental { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
