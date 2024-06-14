using APIAndreVeiculosMicrosservicos.Adress.Repositories;

namespace APIAndreVeiculosMicrosservicos.Adress.Services
{
    public class AdressServiceADODapper
    {
        private AdressRepository _adressRepository;

        public AdressServiceADODapper()
        {
            _adressRepository = new AdressRepository();
        }

        public async Task<List<Models.Adress>> GetAllAdresses(byte type)
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

        public Models.Adress InsertOne(Models.Adress adress)
        {
            _adressRepository.InsertOne(adress);
            return adress;
        }
    }
}