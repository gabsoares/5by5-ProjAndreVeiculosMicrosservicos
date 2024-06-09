using Models;
using Repositories.Repositories_DAPPER;

namespace Services
{
    public class AdressServiceADODapper
    {
        private AdressRepository _adressRepository;

        public AdressServiceADODapper()
        {
            _adressRepository = new AdressRepository();
        }

        public async Task<List<Adress>> GetAllAdresses(byte type)
        {
            try
            {
                return await _adressRepository.GetAllAdresses(type);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}