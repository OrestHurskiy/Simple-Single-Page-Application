using CoreValueContacts.Domain.Entities;
using CoreValueContacts.Services.Services.HelperClasses;
using System;
using System.Collections.Generic;

namespace CoreValueContacts.Services.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMembershipService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        MembershipContext ValidateUser(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        OperationResult<UserInRoles> CreateUser(
            string username, string email, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        OperationResult<UserInRoles> CreateUser(
            string username, string email,
            string password, string role);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        OperationResult<UserInRoles> CreateUser(
            string username, string email,
            string password, string[] roles);


        
    }
}
