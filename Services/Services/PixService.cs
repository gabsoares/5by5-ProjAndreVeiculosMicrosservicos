using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PixService
    {
        private PixRepository _pixRepository;

        public PixService()
        {
            _pixRepository = new PixRepository();
        }

        public async Task<List<Pix>> GetAllPix(byte type)
        {
            return await _pixRepository.GetAllPix(type);
        }
    }
}