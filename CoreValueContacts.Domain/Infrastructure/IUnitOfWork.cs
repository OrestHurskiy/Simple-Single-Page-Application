using System;


namespace CoreValueContacts.Domain.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        void Commit();
    }
}
