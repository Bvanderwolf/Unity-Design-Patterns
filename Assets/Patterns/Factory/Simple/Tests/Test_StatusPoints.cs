using NUnit.Framework;
using UnityEngine;

namespace BWolf.Patterns.Factory.Simple.Tests
{
    /// <summary>
    /// Tests the <see cref="StatusPoints"/> class.
    /// </summary>
    public class Test_StatusPoints
    {
        [Test]
        public void Test_Update_Clamp()
        {
            // Arrange.
            StatusPoints status = new StatusPoints(StatusPoints.DEFAULT_MAX_POINT);

            // Act.
            status.Update(StatusPoints.DEFAULT_MAX_POINT + 100);

            // Assert.
            Assert.AreEqual(StatusPoints.DEFAULT_MAX_POINT, status.Current, "Expected the current status to be clamped but it wasn't.");
        }

        [Test]
        public void Test_Update()
        {
            // Arrange.
            StatusPoints status = new StatusPoints(StatusPoints.DEFAULT_MAX_POINT);

            // Act.
            int newStatus = 50;
            status.Update(newStatus);

            // Assert.
            Assert.AreEqual(newStatus, status.Current, "Expected the current status to be updated but it wasn't.");
        }

        [Test]
        public void Test_Add_Clamp()
        {
            // Arrange.
            StatusPoints status = new StatusPoints(StatusPoints.DEFAULT_MAX_POINT);

            // Act.
            int pointsToAdd = 5;
            status.Add(pointsToAdd);

            // Assert.
            Assert.AreEqual(StatusPoints.DEFAULT_MAX_POINT, status.Current, "Expected the points not to be added but they where.");
        }

        [Test]
        public void Test_Add()
        {
            // Arrange.
            int startPoints = Mathf.RoundToInt(StatusPoints.DEFAULT_MAX_POINT * 0.5f);
            StatusPoints status = new StatusPoints(StatusPoints.DEFAULT_MAX_POINT);
            status.Update(startPoints);

            // Act.
            int pointsToAdd = 5;
            status.Add(pointsToAdd);

            // Assert.
            Assert.AreEqual(startPoints + pointsToAdd, status.Current, "Expected the points to be added but they wheren't.");
        }

        [Test]
        public void Test_Remove_Clamp()
        {
            // Arrange.
            StatusPoints status = new StatusPoints(StatusPoints.DEFAULT_MAX_POINT);

            // Act.
            int pointsToRemove = StatusPoints.DEFAULT_MAX_POINT + 5;
            status.Remove(pointsToRemove);

            // Assert.
            Assert.AreEqual(0, status.Current, "Expected the points to be " +
                "clamped but they wheren't.");
        }

        [Test]
        public void Test_Remove()
        {
            // Arrange.
            StatusPoints status = new StatusPoints(StatusPoints.DEFAULT_MAX_POINT);

            // Act.
            int pointsToRemove = 5;
            status.Remove(pointsToRemove);

            // Assert.
            Assert.AreEqual(StatusPoints.DEFAULT_MAX_POINT - pointsToRemove, status.Current, "Expected the points to be " +
                "removed but they wheren't.");
        }
    }
}