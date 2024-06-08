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

        public List<Role> GetAllRoles(byte type)
        {
            return _roleRepository.GetAllRoles(type);
        }
    }
}