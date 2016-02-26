using System;
using System.Collections.Generic;
using System.Linq;
using CoreValueContacts.Domain.Repositories;
using CoreValueContacts.Services.Services.Interfaces;
using CoreValueContacts.Domain.Entities;
using CoreValueContacts.Domain.Entities.Extensions;
using CoreValueContacts.Services.Services.HelperClasses;
using System.Security.Principal;
using CoreValueContacts.Domain.Infrastructure;

namespace CoreValueContacts.Services.Services.Implementation
{
    public class MembershipService : IMembershipService
    {
        #region Private Varibles

        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userInRoleRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        public MembershipService(IEntityBaseRepository<User> userRepository, 
                                IEntityBaseRepository<Role> roleRepository,
                                IEntityBaseRepository<UserRole> userInRoleRepository,
                                ICryptoService cryptoService,
                                IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userInRoleRepository = userInRoleRepository;
            _cryptoService = cryptoService;
            _unitOfWork = unitOfWork;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var userCtx = new MembershipContext();
            var user = _userRepository.GetSingleByUserName(username);

            if(user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Id);
                userCtx.User = new UserInRoles()
                {
                    User = user,
                    Roles = userRoles
                };

                var identity = new GenericIdentity(user.UserName);
                userCtx.Principal = new GenericPrincipal(identity, userRoles.Select(r => r.Name).ToArray());
            }

            return userCtx;
        }

        public OperationResult<UserInRoles> CreateUser(string username, string email, string password)
        {
            return CreateUser(username, password, email, roles: null);
        }

        public OperationResult<UserInRoles> CreateUser(string username, string email, string password, string role)
        {
            return CreateUser(username, email, password, roles: new[] { role });
        }

        public OperationResult<UserInRoles> CreateUser(string username, string email, string password, string[] roles)
        {
            var existingUser = _userRepository.GetAll().Any(us => us.UserName == username);

            if(existingUser)
            {
                return new OperationResult<UserInRoles>(false);
            }

            var passwordSalt = _cryptoService.GenerateSalt();

            var user = new User
            {
                UserName = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = false,
                HashedPassword = _cryptoService.EncryptPassword(passwordSalt, password),
                CreatedOn = DateTime.Now
            };

            _userRepository.Add(user);
            _unitOfWork.Commit();

            if(roles != null || roles.Length > 0)
            {
                foreach(var role in roles)
                {
                    addUserToRole(user, role);
                }
            }

            _unitOfWork.Commit();

            return new OperationResult<UserInRoles>(true) { Entity = GetUserInRoles(user) };
            
        }

        private UserInRoles GetUserInRoles(User user)
        {
            if (user != null)
            {
                var userRoles = GetUserRoles(user.Id);
                return new UserInRoles { User = user, Roles = userRoles };
            }

            return null;
        }

        private void addUserToRole(User user, string roleName)
        {
            var role = _roleRepository.GetSingleByRoleName(roleName);

            if(role == null)
            {
                throw new ApplicationException("Role doesn't exist.");
            }

            var userInRole = new UserRole()
            {
                RoleId = role.Id,
                UserId = user.Id
            };

            _userInRoleRepository.Add(userInRole);
        }

        private bool isUserValid(User user, string password)
        {
            if(isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }

        private IList<Role> GetUserRoles(Guid userId)
        {
            var userInRoles = _userInRoleRepository.FindBy(us => us.UserId == userId).ToList();

            if(userInRoles != null && userInRoles.Count > 0)
            {
                var userRoleKeys = userInRoles.Select(r => r.RoleId).ToList();

                var userRoles = _roleRepository.FindBy(r => userRoleKeys.Contains(r.Id));

                return userRoles.ToList();
            }

            return new List<Role>();
        }

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_cryptoService.EncryptPassword(user.Salt, password), user.HashedPassword);
        }
    }
}
