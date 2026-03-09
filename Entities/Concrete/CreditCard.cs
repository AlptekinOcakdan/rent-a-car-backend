using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string CVC { get; set; }
    }
}
