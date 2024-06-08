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

        public List<Adress> GetAllAdresses(byte type)
        {
            return _adressRepository.GetAllAdresses(type);
        }
    }
}