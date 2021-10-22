using System;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.Patterns.Adapters
{
    /// <summary>
    /// An adapter for pagination done on a collection.
    /// </summary>
    public class Collection<T> : IPaginationAdapter<T>
    {
        /// <summary>
        /// The page to use.
        /// </summary>
        public int page;

        /// <summary>
        /// The maximum amount of items per page.
        /// </summary>
        public int limit;

        /// <summary>
        /// The collection containing the complete set of data to be paginated.
        /// </summary>
        private readonly ICollection<T> _collection;

        /// <summary>
        /// Initializes the state for pagination.
        /// </summary>
        /// <param name="collection">The collection containing the complete set of data to be paginated.</param>
        /// <param name="page">The page to use.</param>
        /// <param name="limit">The maximum amount of items per page.</param>
        public Collection(ICollection<T> collection, int page, int limit)
        {
            _collection = collection;

            this.page = page;
            this.limit = limit;
        }

        /// <summary>
        /// Applies pagination on the collection of items returning a result.
        /// </summary>
        /// <returns>The pagination result.</returns>
        public PaginationResult<T> Paginate()
        {
            if (_collection == null)
                throw new InvalidOperationException("The collection containing the complete set of data was null.");

            if (limit <= 0)
                throw new InvalidOperationException("Limit used for pagination must be greater than 0.");

            if (page <= 0)
                throw new InvalidOperationException("The page to use for pagination must be greater than 0.");

            int totalItemCount = _collection.Count;
            if (totalItemCount == 0)
                return new PaginationResult<T>(Array.Empty<T>(), 0, 0, 0, limit);

            T[] array = new T[totalItemCount];
            _collection.CopyTo(array, 0);

            if (totalItemCount <= limit)
                return new PaginationResult<T>(array, 1, 1, totalItemCount, limit);

            T[] items = new T[limit];
            int startIndex = (page - 1) * limit;
            if (startIndex >= totalItemCount)
                throw new InvalidOperationException("The page to use for pagination is to great for the collection size.");

            int endIndex = startIndex + limit;
            for (int i = 0, j = startIndex; j < endIndex && j < totalItemCount; i++, j++)
                items[i] = array[j];

            int totalPageCount = Mathf.CeilToInt(totalItemCount / (float)limit);
            return new PaginationResult<T>(items, page, totalPageCount, totalItemCount, limit);
        }
    }
}
