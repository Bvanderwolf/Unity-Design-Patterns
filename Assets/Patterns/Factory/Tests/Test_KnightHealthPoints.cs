using NUnit.Framework;

namespace BWolf.Patterns.Factory.Tests
{
    /// <summary>
    /// Tests the <see cref="KnightHealthPoints"/> class.
    /// </summary>
    public class Test_KnightHealthPoints
    {
        /// <summary>
        /// Tests whether the knight can lose health.
        /// It expects the knight to lose the full amount of health if he has no shield.
        /// </summary>
        [Test]
        public void Test_Remove_No_Shield()
        {
            // Arrange.
            int pointsToRemove = 5;
            ShieldStatusPoints shield = new ShieldStatusPoints(0.0f, 0);
            KnightHealthPoints health = new KnightHealthPoints(shield);

            // Act.
            health.Remove(pointsToRemove);
            int currentHealth = health.Current;

            // Assert.
            Assert.AreEqual(StatusPoints.DEFAULT_MAX_POINT - pointsToRemove, currentHealth, "Expected the total amount of " +
                "points to be removed because there was not shield but it wasn't.");
        }

        /// <summary>
        /// Tests whether the knight can lose health.
        /// It expects the knight to lose no amount of health if he has a shield with max strength.
        /// </summary>
        [Test]
        public void Test_Remove_Shield()
        {
            // Arrange.
            int pointsToRemove = 5;
            ShieldStatusPoints shield = new ShieldStatusPoints(1.0f, pointsToRemove);
            KnightHealthPoints health = new KnightHealthPoints(shield);

            // Act.
            health.Remove(pointsToRemove);
            int currentHealth = health.Current;

            // Assert.
            Assert.AreEqual(StatusPoints.DEFAULT_MAX_POINT, currentHealth, "Expected the health not be removed because of " +
                "the shield but it wasn't.");
        }
    }

}
