using System.Collections.Generic;

namespace BWolf.Patterns.Adapters.EmbeddedPatterns.Factory
{
    /// <summary>
    /// Provides methods for creation of an pagination adapter that suits 
    /// your source of objects.
    /// </summary>
    public static class PaginatorFactory
    {
        /// <summary>
        /// Returns an paginator for an enumerable type.
        /// </summary>
        /// <typeparam name="TItem">The type of item to paginate.</typeparam>
        /// <param name="items">The items to paginate.</param>
        /// <param name="page">The page to use.</param>
        /// <param name="limit">The maximum amount of items per page.</param>
        /// <returns>The pagination adapter.</returns>
        public static Enumerable<TItem> GetPaginator<TItem>(this IEnumerable<TItem> items, int page, int limit) => new Enumerable<TItem>(items, page, limit);

        /// <summary>
        /// Returns a paginator for a collection of objects.
        /// </summary>
        /// <typeparam name="TItem">The type of item to paginate.</typeparam>
        /// <param name="items">The items to paginate.</param>
        /// <param name="page">The page to use.</param>
        /// <param name="limit">The maximum amount of items per page.</param>
        /// <returns>The pagination adapter.</returns>
        public static Collection<TItem> GetPaginator<TItem>(this ICollection<TItem> items, int page, int limit) => new Collection<TItem>(items, page, limit);
    }
}
