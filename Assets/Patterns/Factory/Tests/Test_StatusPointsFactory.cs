using NUnit.Framework;
using System;

namespace BWolf.Patterns.Factory.Tests
{
    /// <summary>
    /// Tests the <see cref="StatusPointsFactory"/> class.
    /// </summary>
    public class Test_StatusPointsFactory
    {
        /// <summary>
        /// Tests whether a correct status points object is created by the factory.
        /// It expects a knight behaviour to get a <see cref="KnightHealthPoints"/> object.
        /// </summary>
        [Test]
        public void Test_CreateHealthForActor_Knight()
        {
            // Arrange.
            Type knightType = typeof(KnightBehaviour);

            // Act.
            StatusPoints status = StatusPointsFactory.CreateHealthForActor(knightType);

            // Assert.
            Assert.AreEqual(typeof(KnightHealthPoints), status.GetType(), "Expected knight health points to be created but it wasn't.");
        }

        /// <summary>
        /// Tests whether a correct status points object is created by the factory.
        /// It expects a priest behaviour to get a <see cref="PriestHealthPoints"/> object.
        /// </summary>
        [Test]
        public void Test_CreateHealthForActor_Priest()
        {
            // Arrange.
            Type priestType = typeof(PriestBehaviour);

            // Act.
            StatusPoints status = StatusPointsFactory.CreateHealthForActor(priestType);

            // Assert.
            Assert.AreEqual(typeof(PriestHealthPoints), status.GetType(), "Expected priest health points to be created but it wasn't.");
        }

        /// <summary>
        /// Tests whether a correct status points object is created by the factory.
        /// It expects a squire behaviour to get a <see cref="SquireHealthPoints"/> object.
        /// </summary>
        [Test]
        public void Test_CreateHealthForActor_Squire()
        {
            // Arrange.
            Type squireType = typeof(SquireBehaviour);

            // Act.
            StatusPoints status = StatusPointsFactory.CreateHealthForActor(squireType);

            // Assert.
            Assert.AreEqual(typeof(SquireHealthPoints), status.GetType(), "Expected squire health points to be created but it wasn't.");
        }
    }
}
