using Business.Abstract;
using Core.Utilities.Results;

namespace Business.Concrete {
    public class FindexManager : IFindexService {
        public IDataResult<int> GetCustomerFindexScore(string customerNationalIdentity) {
            //simulating
            var rand = new Random();
            return new SuccessDataResult<int>(rand.Next(400, 1900));
        }
    }
}
