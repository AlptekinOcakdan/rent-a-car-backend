using Core.Entities;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string NationalIdentity { get; set; }
    }
}
