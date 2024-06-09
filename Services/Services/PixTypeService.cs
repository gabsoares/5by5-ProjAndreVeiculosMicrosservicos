using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PixTypeService
    {
        private PixTypeRepository _pixTypeRepository;

        public PixTypeService()
        {
            _pixTypeRepository = new PixTypeRepository();
        }

        public async Task<List<PixType>> GetAllPixTypes(byte type)
        {
            return await _pixTypeRepository.GetAllPixTypes(type);
        }
    }
}