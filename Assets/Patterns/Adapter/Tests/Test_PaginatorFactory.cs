using BWolf.Patterns.Adapters.EmbeddedPatterns.Factory;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BWolf.Patterns.Adapters.Tests
{
    /// <summary>
    /// Tests the <see cref="PaginatorFactory"/> class.
    /// </summary>
    public class Test_PaginatorFactory
    {
        /// <summary>
        /// Tests whether the factory can create a non-null adapter for a collection.
        /// It expects the outputted adapter not to be null.
        /// </summary>
        [Test]
        public void Test_GetAdapter_Collection()
        {
            // Arrange.
            List<int> list = new List<int>(Enumerable.Range(0, 5));

            // Act.
            Collection<int> adapter = list.GetPaginator(1, 1);

            // Assert.
            Assert.NotNull(adapter, "Expected the adapter created for the list not to be null but it was.");
        }

        /// <summary>
        /// Tests whether the factory can create a non-null adapter for an enumerable.
        /// It expects the outputted adapter not to be null.
        /// </summary>
        [Test]
        public void Test_GetPaginator_Enumerable()
        {
            // Arrange.
            IEnumerable<int> enumerable = Enumerable.Range(0, 5);

            // Act.
            Enumerable<int> adapter = enumerable.GetPaginator(1, 1);

            // Assert.
            Assert.NotNull(adapter, "Expected the adapter created for the list not to be null but it was.");
        }
    }
}
