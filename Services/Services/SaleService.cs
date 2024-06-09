using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SaleService
    {
        private SaleRepository _saleRepository;

        public SaleService()
        {
            _saleRepository = new SaleRepository();
        }

        public async Task<List<Sale>> GetAllSales(byte type)
        {
            return await _saleRepository.GetAllSales(type);
        }
    }
}
