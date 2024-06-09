using Models;
using Repositories.Repositories_DAPPER;

namespace Services.Services_DAPPER
{
    public class RoleService
    {
        private RoleRepository _roleRepository;

        public RoleService()
        {
            _roleRepository = new RoleRepository();
        }

        public async Task<List<Role>> GetAllRoles(byte type)
        {
            return await _roleRepository.GetAllRoles(type);
        }
    }
}