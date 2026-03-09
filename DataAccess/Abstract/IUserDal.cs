using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetUserClaims(int userId);
        List<UserDto> GetUsers();
        List<OperationClaim> GetOperationClaims();
        void AddClaim(UserOperationClaim operationClaim);
        void DeleteClaim(UserOperationClaim operationClaim);
    }
}
