using NUnit.Framework;
using System;
using System.Linq;

namespace BWolf.Patterns.Adapters.Tests
{
    /// <summary>
    /// Tests the <see cref="Collection{T}"/> class.
    /// </summary>
    public class Test_Collection
    {
        /// <summary>
        /// Tests whether the collection adapter can paginate with a collection that is null.
        /// It expects an <see cref="InvalidOperationException"/> to be thrown if the collection has no value.
        /// </summary>
        [Test]
        public void Test_Paginate_Null_Collection()
        {
            // Arrange.
            Collection<int> collection = new Collection<int>(null, 1, 1);

            // Act.
            TestDelegate action = () => collection.Paginate();

            // Assert.
            Assert.Catch<InvalidOperationException>(action, "Expected the null collection to cause an exception but it didn't.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate with a negative limit.
        /// It expects an <see cref="InvalidOperationException"/> to be thrown if the limit has a negative value.
        /// </summary>
        [Test]
        public void Test_Paginate_Negative_Limit()
        {
            // Arrange.
            int[] array = Enumerable.Range(0, 1).ToArray();
            Collection<int> collection = new Collection<int>(array, 1, -1);

            // Act.
            TestDelegate action = () => collection.Paginate();

            // Assert.
            Assert.Catch<InvalidOperationException>(action, "Expected the negative limit to cause an exception but it didn't.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate with a negative page.
        /// It expects an <see cref="InvalidOperationException"/> to be thrown if the page has a negative value.
        /// </summary>
        [Test]
        public void Test_Paginate_Negative_Page()
        {
            // Arrange.
            int[] array = Enumerable.Range(0, 1).ToArray();
            Collection<int> collection = new Collection<int>(array, -1, 1);

            // Act.
            TestDelegate action = () => collection.Paginate();

            // Assert.
            Assert.Catch<InvalidOperationException>(action, "Expected the negative page to cause an exception but it didn't.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate with an empty collection.
        /// It expects the result to not be null if the collection was empty.
        /// </summary>
        [Test]
        public void Test_Paginate_Empty_Collection()
        {
            // Arrange.
            Collection<int> collection = new Collection<int>(Array.Empty<int>(), 1, 1);

            // Act.
            PaginationResult<int> result = collection.Paginate();

            // Assert.
            Assert.NotNull(result, "Expected the result of for pagination of an empty collection not to be null.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate with a limit that is smaller than te collection size.
        /// It expects the item count to be equal to the limit if the limit was smaller than the collection size.
        /// </summary>
        [Test]
        public void Test_Paginate_Limit_Smaller_Than_Collection()
        {
            // Arrange.
            int limit = 4;
            int[] array = Enumerable.Range(0, 5).ToArray();
            Collection<int> collection = new Collection<int>(array, 1, limit);

            // Act.
            PaginationResult<int> result = collection.Paginate();

            // Assert.
            Assert.AreEqual(result.ItemCount, limit, "Expected the amount of items to be equal to the limit but it wasn't.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate if the page is out of range.
        /// It expects an <see cref="InvalidOperationException"/> to be thrown if the page was out of range.
        /// </summary>
        [Test]
        public void Test_Paginate_Page_Out_Of_Range()
        {
            // Arrange.
            int page = 3;
            int limit = 3;
            int[] array = Enumerable.Range(0, 5).ToArray();
            Collection<int> collection = new Collection<int>(array, page, limit);

            // Act.
            TestDelegate action = () => collection.Paginate();

            // Assert.
            Assert.Catch<InvalidOperationException>(action, "Expected the out of bounds page to cause an exception but it didn't.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate when the page is the last page.
        /// It expects the items on the last page to contain the leftover items of the collection.
        /// </summary>
        [Test]
        public void Test_Paginate_Last_Page()
        {
            // Arrange.
            int page = 3;
            int limit = 3;
            int[] array = Enumerable.Range(0, 8).ToArray();
            Collection<int> collection = new Collection<int>(array, page, limit);

            // Act.
            PaginationResult<int> result = collection.Paginate();

            // Assert.
            Assert.AreEqual(2, result.ItemCount, "Expected the item count to be the size of the leftover items of the last page.");
        }

        /// <summary>
        /// Tests whether the collection adapter can paginate when the limit is greater than the collection size.
        /// It expects the item count in the result to be equal to the given array size if the limit was greater than the collection.
        /// </summary>
        [Test]
        public void Test_Paginate_Limit_Greater_Than_Collection()
        {
            // Arrange.
            int page = 3;
            int limit = 5;
            int[] array = Enumerable.Range(0, 4).ToArray();
            Collection<int> collection = new Collection<int>(array, page, limit);

            // Act.
            PaginationResult<int> result = collection.Paginate();

            // Assert.
            Assert.AreEqual(array.Length, result.ItemCount, "Expected the item count to be equal to the length of the given array but it wasn't.");
        }
    }
}

