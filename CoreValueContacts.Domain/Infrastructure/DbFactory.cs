using CoreValueContacts.Domain.Entities.Core;
using System;

namespace CoreValueContacts.Domain.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EntitiesContext dbContext;

        public EntitiesContext Init()
        {
            return dbContext ?? (dbContext = new EntitiesContext());
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
