using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Beerendonk.Time.Tests
{
    [TestClass]
    public class PeriodTests
    {
        [TestMethod]
        public void ConstructorDurationToShouldReturnCorrectPeriod()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);
            var duration = new TimeSpan(2222);

            // Act

            var actual = new Period(duration, to);

            // Assert

            Assert.AreEqual(duration, actual.Duration);
            Assert.AreEqual(from, actual.From);
            Assert.AreEqual(to, actual.To);
        }

        [TestMethod]
        public void ConstructorFromDurationShouldReturnCorrectPeriod()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);
            var duration = new TimeSpan(2222);

            // Act

            var actual = new Period(from, duration);

            // Assert

            Assert.AreEqual(duration, actual.Duration);
            Assert.AreEqual(from, actual.From);
            Assert.AreEqual(to, actual.To);
        }

        [TestMethod]
        public void ConstructorFromToShouldReturnCorrectPeriod()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);
            var duration = new TimeSpan(2222);

            // Act

            var actual = new Period(from, to);

            // Assert

            Assert.AreEqual(duration, actual.Duration);
            Assert.AreEqual(from, actual.From);
            Assert.AreEqual(to, actual.To);
        }

        [TestMethod]
        public void EqualObjectWithOtherObjectShouldReturnFalse()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);

            var period = new Period(from, to);

            // Act

            bool condition = period.Equals(new Object());

            // Assert

            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void EqualWithFromToDurationEqualShouldReturnTrue()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);

            var p1 = new Period(from, to);
            var p2 = new Period(from, to);

            // Act

            bool condition1 = p1.Equals((object)p2);
            bool condition2 = p1.Equals(p2);
            bool condition3 = Period.Equals(p1, p2);
            bool condition4 = p1 == p2;

            // Assert

            Assert.IsTrue(condition1);
            Assert.IsTrue(condition2);
            Assert.IsTrue(condition3);
            Assert.IsTrue(condition4);
        }

        [TestMethod]
        public void EqualWithFromEqualAndToDurationUnequalShouldReturnFalse()
        {
            // Arrange

            var from = new DateTime(1111);
            var to1 = new DateTime(3333);
            var to2 = new DateTime(4444);

            var p1 = new Period(from, to1);
            var p2 = new Period(from, to2);

            // Act

            bool condition1 = p1.Equals((object)p2);
            bool condition2 = p1.Equals(p2);
            bool condition3 = Period.Equals(p1, p2);
            bool condition4 = p1 == p2;

            // Assert

            Assert.IsFalse(condition1);
            Assert.IsFalse(condition2);
            Assert.IsFalse(condition3);
            Assert.IsFalse(condition4);
        }

        [TestMethod]
        public void EqualWithToEqualAndFromDurationUnequalShouldReturnFalse()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var from2 = new DateTime(2222);
            var to = new DateTime(3333);

            var p1 = new Period(from1, to);
            var p2 = new Period(from2, to);

            // Act

            bool condition1 = p1.Equals((object)p2);
            bool condition2 = p1.Equals(p2);
            bool condition3 = Period.Equals(p1, p2);
            bool condition4 = p1 == p2;

            // Assert

            Assert.IsFalse(condition1);
            Assert.IsFalse(condition2);
            Assert.IsFalse(condition3);
            Assert.IsFalse(condition4);
        }

        [TestMethod]
        public void EqualWithDurationEqualAndFromToUnequalShouldReturnFalse()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var from2 = new DateTime(2222);
            var duration = new TimeSpan(3333);

            var p1 = new Period(from1, duration);
            var p2 = new Period(from2, duration);

            // Act

            bool condition1 = p1.Equals((object)p2);
            bool condition2 = p1.Equals(p2);
            bool condition3 = Period.Equals(p1, p2);
            bool condition4 = p1 == p2;

            // Assert

            Assert.IsFalse(condition1);
            Assert.IsFalse(condition2);
            Assert.IsFalse(condition3);
            Assert.IsFalse(condition4);
        }

        [TestMethod]
        public void UnequalWithFromToDurationEqualShouldReturnFalse()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);

            var p1 = new Period(from, to);
            var p2 = new Period(from, to);

            // Act

            bool condition = p1 != p2;

            // Assert

            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void UnequalWithFromEqualAndToDurationUnequalShouldReturnTrue()
        {
            // Arrange

            var from = new DateTime(1111);
            var to1 = new DateTime(3333);
            var to2 = new DateTime(4444);

            var p1 = new Period(from, to1);
            var p2 = new Period(from, to2);

            // Act

            bool condition = p1 != p2;

            // Assert

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void UnequalWithToEqualAndFromDurationUnequalShouldReturnTrue()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var from2 = new DateTime(2222);
            var to = new DateTime(3333);

            var p1 = new Period(from1, to);
            var p2 = new Period(from2, to);

            // Act

            bool condition = p1 != p2;

            // Assert

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void UnequalWithDurationEqualAndFromToUnequalShouldReturnTrue()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var from2 = new DateTime(2222);
            var duration = new TimeSpan(3333);

            var p1 = new Period(from1, duration);
            var p2 = new Period(from2, duration);

            // Act

            bool condition = p1 != p2;

            // Assert

            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void GetHashCodeShouldReturnCombinedFromAndToHashCodes()
        {
            // Arrange

            var from = new DateTime(123456789);
            var to = new DateTime(987654321);
            var period = new Period(from, to);

            int expected = from.GetHashCode() + to.GetHashCode();

            // Act

            int actual = period.GetHashCode();

            // Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TodayShouldReturnToday()
        {
            // Arrange

            var now = DateTime.Now;

            // Don't run this test too close to midnight
            var midnight = new TimeSpan(24, 0, 0);
            if (midnight - now.TimeOfDay < TimeSpan.FromSeconds(5))
            {
                Thread.Sleep(midnight - now.TimeOfDay + TimeSpan.FromMilliseconds(100));
                now = DateTime.Now;
            }

            Period expected = new Period(now.Date, now.Date.AddDays(1));

            // Act

            Period actual = Period.Today;

            // Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringShouldReturnCorrectFormat()
        {
            // Arrange

            var from = new DateTime(2014, 11, 30, 13, 6, 44, 567);
            var to = new DateTime(2015, 2, 3, 4, 5, 6, 789);
            var period = new Period(from, to);

            string expected = String.Format("{0} - {1}", from.ToString(), to.ToString());

            // Act

            string actual = period.ToString();

            // Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringWithFormatShouldReturnCorrectFormat()
        {
            // Arrange

            var from = new DateTime(2014, 11, 30, 13, 6, 44, 567);
            var to = new DateTime(2015, 2, 3, 4, 5, 6, 789);
            var period = new Period(from, to);

            string format = "yyy MMM ddd HH mm ss ffff tt zzz";
            string expected = String.Format("{0} - {1}", from.ToString(format), to.ToString(format));

            // Act

            string actual = period.ToString(format);

            // Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringWithProviderShouldReturnCorrectFormat()
        {
            // Arrange

            var from = new DateTime(2014, 11, 30, 13, 6, 44, 567);
            var to = new DateTime(2015, 2, 3, 4, 5, 6, 789);
            var period = new Period(from, to);

            Mock<IFormatProvider> mockProvider = new Mock<IFormatProvider>();
            mockProvider.Setup(x => x.GetFormat(It.IsAny<Type>())).Returns((Type t) => CultureInfo.InvariantCulture.GetFormat(t));
            IFormatProvider provider = mockProvider.Object;

            string expected = String.Format("{0} - {1}", from.ToString(CultureInfo.InvariantCulture), to.ToString(CultureInfo.InvariantCulture));

            // Act

            string actual = period.ToString(provider);

            // Assert

            Assert.AreEqual(expected, actual);
            mockProvider.Verify(x => x.GetFormat(It.IsAny<Type>()));
        }

        [TestMethod]
        public void ToStringWithFormatProviderShouldReturnCorrectFormat()
        {
            // Arrange

            var from = new DateTime(2014, 11, 30, 13, 6, 44, 567);
            var to = new DateTime(2015, 2, 3, 4, 5, 6, 789);
            var period = new Period(from, to);

            string format = "yyy MMM ddd HH mm ss ffff tt zzz";
            Mock<IFormatProvider> mockProvider = new Mock<IFormatProvider>();
            mockProvider.Setup(x => x.GetFormat(It.IsAny<Type>())).Returns((Type t) => CultureInfo.InvariantCulture.GetFormat(t));
            IFormatProvider provider = mockProvider.Object;

            string expected = String.Format("{0} - {1}", from.ToString(format, CultureInfo.InvariantCulture), to.ToString(format, CultureInfo.InvariantCulture));

            // Act

            string actual = period.ToString(format, provider);

            // Assert

            Assert.AreEqual(expected, actual);
            mockProvider.Verify(x => x.GetFormat(It.IsAny<Type>()));
        }

        [TestMethod]
        public void AddEnclosedPeriodShouldReturnSamePeriod()
        {
            // Arrange

            var from = new DateTime(1111);
            var to = new DateTime(3333);
            var period = new Period(from, to);

            ICollection expected = new Period[] { period };

            // Act

            IEnumerable<Period> actual = period + period;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void AddLargerPeriodShouldReturnSamePeriod()
        {
            // Arrange

            var from1 = new DateTime(2222);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(1111);
            var to2 = new DateTime(4444);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { period2 };

            // Act

            IEnumerable<Period> actual = period1 + period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void AddDistinctPeriodShouldReturnBothPeriods()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(4444);
            var to2 = new DateTime(6666);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { period1, period2 };

            // Act

            IEnumerable<Period> actual = period1 + period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void AddPeriodWithOverlappingFromShouldReturnExtendedPeriod()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(0);
            var to2 = new DateTime(2222);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { new Period(from2, to1) };

            // Act

            IEnumerable<Period> actual = period1 + period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void AddPeriodWithOverlappingToShouldReturnExtendedPeriod()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(2222);
            var to2 = new DateTime(4444);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { new Period(from1, to2) };

            // Act

            IEnumerable<Period> actual = period1 + period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void RemoveEnclosedPeriodShouldReturnTwoPeriods()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var to1 = new DateTime(4444);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(2222);
            var to2 = new DateTime(3333);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { new Period(from1, from2), new Period(to2, to1) };

            // Act

            IEnumerable<Period> actual = period1 - period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void RemoveLargerPeriodShouldReturnEmpty()
        {
            // Arrange

            var from1 = new DateTime(2222);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(1111);
            var to2 = new DateTime(4444);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { };

            // Act

            IEnumerable<Period> actual = period1 - period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void RemovePastPeriodsShouldReturnTheOriginalPeriod()
        {
            // Arrange

            var from1 = new DateTime(4444);
            var to1 = new DateTime(6666);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(1111);
            var to2 = new DateTime(3333);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { period1 };

            // Act

            IEnumerable<Period> actual = period1 - period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void RemoveFuturePeriodsShouldReturnTheOriginalPeriod()
        {
            // Arrange

            var from1 = new DateTime(4444);
            var to1 = new DateTime(6666);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(7777);
            var to2 = new DateTime(9999);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { period1 };

            // Act

            IEnumerable<Period> actual = period1 - period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void RemovePeriodWithOverlappingFromShouldReturnShortenedPeriod()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(0);
            var to2 = new DateTime(2222);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { new Period(to2, to1) };

            // Act

            IEnumerable<Period> actual = period1 - period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }

        [TestMethod]
        public void RemovePeriodWithOverlappingToShouldReturnShortenedPeriod()
        {
            // Arrange

            var from1 = new DateTime(1111);
            var to1 = new DateTime(3333);
            var period1 = new Period(from1, to1);

            var from2 = new DateTime(2222);
            var to2 = new DateTime(4444);
            var period2 = new Period(from2, to2);

            ICollection expected = new Period[] { new Period(from1, from2) };

            // Act

            IEnumerable<Period> actual = period1 - period2;

            // Assert

            CollectionAssert.AreEqual(expected, (ICollection)actual.ToList());
        }
    }
}
