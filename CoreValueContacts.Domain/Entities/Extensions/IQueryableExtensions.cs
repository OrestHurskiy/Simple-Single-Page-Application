using CoreValueContacts.Domain.Entities.Core;
using System.Linq;

namespace CoreValueContacts.Domain.Entities.Extensions
{
    public static class IQueryableExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            var totalCount = source.Count();
            var collection = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PaginatedList<T>(pageIndex, pageSize, totalCount, collection);
        }
    }
}
