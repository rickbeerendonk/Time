using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beerendonk.Time.Tests
{

    [TestClass]
    public class PeriodSetTests
    {
        [TestMethod]
        public void ConstructorShouldReturnNormalizedResult()
        {
            // Arrange

            var periods = new List<Period>
            {
                new Period(new DateTime(2014, 2, 1), new DateTime(2014, 5, 1)),
                new Period(new DateTime(2014, 2, 1), new DateTime(2014, 4, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 2, 1)),
                new Period(new DateTime(2014, 5, 1), new DateTime(2014, 6, 1)),
            };

            var expected = new Period(new DateTime(2014, 1, 1), new DateTime(2014, 6, 1));

            // Act

            var actual = new PeriodSet(periods);

            // Assert

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.First());
        }

        [TestMethod]
        public void ExceptWithShouldReturnException()
        {
            // Arrange

            var first = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2014, 2, 1), new DateTime(2014, 11, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 7, 1)),
                new Period(new DateTime(2016, 6, 1), new DateTime(2016, 11, 1))
            });
            var second = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2012, 2, 1), new DateTime(2012, 11, 1)),
                new Period(new DateTime(2014, 3, 1), new DateTime(2014, 10, 1)),
                new Period(new DateTime(2015, 6, 1), new DateTime(2015, 11, 1)),
                new Period(new DateTime(2016, 2, 1), new DateTime(2016, 7, 1))
            });
            var expected = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 3, 1)),
                new Period(new DateTime(2014, 10, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 6, 1)),
                new Period(new DateTime(2016, 7, 1), new DateTime(2016, 11, 1))
            });

            // Act

            var actual = first.ExceptWith(second);

            // Assert

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }

        [TestMethod]
        public void IntersectWithShouldReturnIntersection()
        {
            // Arrange

            var first = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2014, 2, 1), new DateTime(2014, 11, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 7, 1)),
                new Period(new DateTime(2016, 6, 1), new DateTime(2016, 11, 1))
            });
            var second = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2012, 2, 1), new DateTime(2012, 11, 1)),
                new Period(new DateTime(2014, 3, 1), new DateTime(2014, 10, 1)),
                new Period(new DateTime(2015, 6, 1), new DateTime(2015, 11, 1)),
                new Period(new DateTime(2016, 2, 1), new DateTime(2016, 7, 1))
            });
            var expected = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2014, 3, 1), new DateTime(2014, 10, 1)),
                new Period(new DateTime(2015, 6, 1), new DateTime(2015, 7, 1)),
                new Period(new DateTime(2016, 6, 1), new DateTime(2016, 7, 1))
            });

            // Act

            var actual = first.IntersectWith(second);

            // Assert

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }

        [TestMethod]
        public void SymmetricExceptWithShouldReturnSymmetricException()
        {
            // Arrange

            var first = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2014, 2, 1), new DateTime(2014, 11, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 7, 1)),
                new Period(new DateTime(2016, 6, 1), new DateTime(2016, 11, 1))
            });
            var second = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2012, 2, 1), new DateTime(2012, 11, 1)),
                new Period(new DateTime(2014, 3, 1), new DateTime(2014, 10, 1)),
                new Period(new DateTime(2015, 6, 1), new DateTime(2015, 11, 1)),
                new Period(new DateTime(2016, 2, 1), new DateTime(2016, 7, 1))
            });
            var expected = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2012, 2, 1), new DateTime(2012, 11, 1)),
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 3, 1)),
                new Period(new DateTime(2014, 10, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 6, 1)),
                new Period(new DateTime(2015, 7, 1), new DateTime(2015, 11, 1)),
                new Period(new DateTime(2016, 2, 1), new DateTime(2016, 6, 1)),
                new Period(new DateTime(2016, 7, 1), new DateTime(2016, 11, 1))
            });

            // Act

            var actual = first.SymmetricExceptWith(second);

            // Assert

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }

        [TestMethod]
        public void UnionWithShouldReturnUnion()
        {
            // Arrange

            var first = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2014, 2, 1), new DateTime(2014, 11, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 7, 1)),
                new Period(new DateTime(2016, 6, 1), new DateTime(2016, 11, 1))
            });
            var second = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2012, 2, 1), new DateTime(2012, 11, 1)),
                new Period(new DateTime(2014, 3, 1), new DateTime(2014, 10, 1)),
                new Period(new DateTime(2015, 6, 1), new DateTime(2015, 11, 1)),
                new Period(new DateTime(2016, 2, 1), new DateTime(2016, 7, 1))
            });
            var expected = new PeriodSet(new List<Period>
            {
                new Period(new DateTime(2012, 2, 1), new DateTime(2012, 11, 1)),
                new Period(new DateTime(2013, 2, 1), new DateTime(2013, 11, 1)),
                new Period(new DateTime(2014, 1, 1), new DateTime(2014, 12, 1)),
                new Period(new DateTime(2015, 2, 1), new DateTime(2015, 11, 1)),
                new Period(new DateTime(2016, 2, 1), new DateTime(2016, 11, 1))
            });

            // Act

            var actual = first.UnionWith(second);

            // Assert

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());
        }
    }
}
