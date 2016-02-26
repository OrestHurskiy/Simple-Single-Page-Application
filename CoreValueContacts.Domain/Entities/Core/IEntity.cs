using System;

namespace CoreValueContacts.Domain.Entities.Core
{
    /// <summary>
    /// base interface for entities implementation
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
