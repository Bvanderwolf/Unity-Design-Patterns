using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BWolf.Patterns.Adapters
{
    /// <summary>
    /// An adapter for pagination done on an enumerable.
    /// </summary>
    public class Enumerable<T> : IPaginationAdapter<T>
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
        /// The enumerable containing the complete set of data to be paginated.
        /// </summary>
        private IEnumerable<T> _enumerable;

        /// <summary>
        /// Initializes the state for pagination.
        /// </summary>
        /// <param name="enumerable">The enumerable containing the complete set of data to be paginated.</param>
        /// <param name="page">The page to use.</param>
        /// <param name="limit">The maximum amount of items per page.</param>
        public Enumerable(IEnumerable<T> enumerable, int page, int limit)
        {
            _enumerable = enumerable;

            this.page = page;
            this.limit = limit;
        }

        /// <summary>
        /// Applies pagination on the enumeration of items returning a result.
        /// </summary>
        /// <returns>The pagination result.</returns>
        public PaginationResult<T> Paginate()
        {
            if (_enumerable == null)
                throw new InvalidOperationException("The enumerable containing the complete set of data was null.");

            if (limit <= 0)
                throw new InvalidOperationException("Limit used for pagination must be greater than 0.");

            if (page <= 0)
                throw new InvalidOperationException("The page to use for pagination must be greater than 0.");

            T[] array = _enumerable.ToArray();

            int totalItemCount = array.Length;
            if (totalItemCount == 0)
                return new PaginationResult<T>(array, 0, 0, 0, limit);

            if (totalItemCount <= limit)
                return new PaginationResult<T>(array, 1, 1, totalItemCount, limit);

            int totalPageCount = Mathf.CeilToInt(totalItemCount / (float)limit);
            int itemCount = (totalPageCount == page) ? (totalItemCount - ((page - 1) * limit)) : limit;

            T[] items = new T[itemCount];
            int startIndex = (page - 1) * limit;
            if (startIndex >= totalItemCount)
                throw new InvalidOperationException("The page to use for pagination is to great for the collection size.");

            int endIndex = startIndex + limit;
            for (int i = 0, j = startIndex; j < endIndex && j < totalItemCount; i++, j++)
                items[i] = array[j];

            return new PaginationResult<T>(items, page, totalPageCount, totalItemCount, limit);
        }
    }
}
