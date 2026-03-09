using Core.Utilities.Results;

namespace Business.Abstract {
    public interface IFindexService {
        IDataResult<int> GetCustomerFindexScore(string customerNationalIdentity);
    }
}
