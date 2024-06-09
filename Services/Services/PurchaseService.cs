using Models;
using Repositories.Repositories;

namespace Services.Services
{
    public class PurchaseService
    {
        private PurchaseRepository _purchaseRepository;

        public PurchaseService()
        {
            _purchaseRepository = new PurchaseRepository();
        }

        public async Task<List<Purchase>> GetAllPurchases(byte type)
        {
            return await _purchaseRepository.GetAllPurchases(type);
        }
    }
}