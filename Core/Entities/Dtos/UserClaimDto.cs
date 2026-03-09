namespace Core.Entities.Dtos
{
    public class UserClaimDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Claim { get; set; }
    }
}
