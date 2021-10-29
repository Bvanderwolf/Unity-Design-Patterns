using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Factory.Tests
{
    /// <summary>
    /// Tests the <see cref="PriestHealthPoints"/> class.
    /// </summary>
    public class Test_PriestHealthPoints
    {
        /// <summary>
        /// Tests whether the priest can get heal.
        /// It expects that if the priest has no heal power it will not given him extra heal.
        /// </summary>
        [Test]
        public void Test_Add_No_Heal_Power()
        {
            // Arrange.
            int pointsToAdd = 5;
            int startHealth = Mathf.RoundToInt(StatusPoints.DEFAULT_MAX_POINT / 2f);
            PriestHealthPoints health = new PriestHealthPoints(0.0f);
            health.Update(startHealth);

            // Act.
            health.Add(pointsToAdd);

            // Assert
            Assert.AreEqual(startHealth + pointsToAdd, health.Current, "Expected just the points to add to be added but it wasn't.");
        }

        /// <summary>
        /// Tests whether the priest can get heal.
        /// It expects that if the priest has heal power this will give him extra heal.
        /// </summary>
        [Test]
        public void Test_Add_Heal_Power()
        {
            // Arrange.
            int pointsToAdd = 5;
            int startHealth = Mathf.RoundToInt(StatusPoints.DEFAULT_MAX_POINT / 2f);
            float healPower = 0.5f;
            PriestHealthPoints health = new PriestHealthPoints(healPower);
            health.Update(startHealth);

            // Act.
            health.Add(pointsToAdd);
            int extra = Mathf.RoundToInt(pointsToAdd * healPower);

            // Assert
            Assert.AreEqual(startHealth + pointsToAdd + extra, health.Current, "Expected the extra points to be added but they wheren't");
        }
    }
}