using System.Linq;
using CoreValueContacts.Domain.Repositories;

namespace CoreValueContacts.Domain.Entities.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static User GetSingleByUserName(this IEntityBaseRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(us => us.UserName == username);
        }
    }
}
