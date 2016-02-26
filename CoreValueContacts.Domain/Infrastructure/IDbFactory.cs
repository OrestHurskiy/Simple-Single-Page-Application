using CoreValueContacts.Domain.Entities.Core;
using System;

namespace CoreValueContacts.Domain.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        EntitiesContext Init();
    }
}
