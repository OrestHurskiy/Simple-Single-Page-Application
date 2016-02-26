using System.Linq;
using CoreValueContacts.Domain.Repositories;

namespace CoreValueContacts.Domain.Entities.Extensions
{
    public static class RoleRepositoryExtensions
    {
        public static Role GetSingleByRoleName(this IEntityBaseRepository<Role> roleRepository, string rolename)
        {
            return roleRepository.GetAll().FirstOrDefault(r => r.Name == rolename);
        }
    }
}
