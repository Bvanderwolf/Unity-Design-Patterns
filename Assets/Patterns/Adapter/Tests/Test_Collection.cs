using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BWolf.Patterns.Adapters.Tests
{
    /// <summary>
    /// Tests the <see cref="Collection{T}"/> class.
    /// </summary>
    public class Test_Collection
    {
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

        [Test]
        public void Test_Paginate_Negative_Limit()
        {
            // Arrange.
            Collection<int> collection = new Collection<int>(new List<int>(), 1, -1);

            // Act.
            TestDelegate action = () => collection.Paginate();

            // Assert.
            Assert.Catch<InvalidOperationException>(action, "Expected the negative limit to cause an exception but it didn't.");
        }

        [Test]
        public void Test_Paginate_Negative_Page()
        {
            // Arrange.
            Collection<int> collection = new Collection<int>(new List<int>(), -1, 1);

            // Act.
            TestDelegate action = () => collection.Paginate();

            // Assert.
            Assert.Catch<InvalidOperationException>(action, "Expected the negative page to cause an exception but it didn't.");
        }

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
    }
}

