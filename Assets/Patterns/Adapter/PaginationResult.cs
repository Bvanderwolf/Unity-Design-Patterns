namespace BWolf.Patterns.Adapters
{
    /// <summary>
    /// Represents the result of a pagination operation.
    /// </summary>
    public class PaginationResult<T>
    {
        /// <summary>
        /// The amount of items in the result.
        /// </summary>
        public int ItemCount => items.Length;

        /// <summary>
        /// The total amount of items used for the pagination.
        /// </summary>
        public readonly int totalItemCount;

        /// <summary>
        /// The current page the result ended on.
        /// </summary>
        public readonly int currentPage;

        /// <summary>
        /// The total amount of pages.
        /// </summary>
        public readonly int totalPageCount;

        /// <summary>
        /// The limit used for the pagination.
        /// </summary>
        public readonly int limit;

        /// <summary>
        /// The resulting items. 
        /// </summary>
        public readonly T[] items;

        /// <summary>
        /// Initializes the result set.
        /// </summary>
        /// <param name="items">The resulting items.</param>
        /// <param name="currentPage">The current page the result ended on.</param>
        /// <param name="totalPageCount">The total amount of pages.</param>
        /// <param name="limit">The limit used for the pagination.</param>
        public PaginationResult(T[] items, int currentPage, int totalPageCount, int totalItemCount, int limit)
        {
            this.items = items;
            this.currentPage = currentPage;
            this.totalPageCount = totalPageCount;
            this.totalItemCount = totalItemCount;
            this.limit = limit;
        }
    }
}
