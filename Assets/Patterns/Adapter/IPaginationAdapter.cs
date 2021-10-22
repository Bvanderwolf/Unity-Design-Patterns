namespace BWolf.Patterns.Adapters
{
    /// <summary>
    /// Provides an interface for pagination.
    /// </summary>
    public interface IPaginationAdapter<T>
    {
        /// <summary>
        /// Performs pagination returning a result.
        /// </summary>
        /// <returns>The pagination result set.</returns>
        PaginationResult<T> Paginate();
    }
}
