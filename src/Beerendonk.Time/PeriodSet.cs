using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Beerendonk.Time
{
    /// <summary>
    /// A set of <see cref="Period"/>s.
    /// </summary>
    public class PeriodSet : IEnumerable<Period>
    {
        private readonly SortedDictionary<DateTime, int> data = new SortedDictionary<DateTime, int>();

        private PeriodSet() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodSet"/> class.
        /// </summary>
        /// <param name="periods">A collection of <see cref="Period"/> classes.</param>
        public PeriodSet(IEnumerable<Period> periods)
            : this()
        {
            foreach (var period in periods)
            {
                Add(period);
            }

            Normalize();
        }

        private void Normalize()
        {
            var periods = new List<Period>();
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                periods.Add(enumerator.Current);
            }

            data.Clear();

            foreach (var period in periods)
            {
                Add(period);
            }
        }

        private void Add(Period period)
        {
            Add(period.From, +1);
            Add(period.To, -1);
        }

        private void Add(DateTime dateTime, int relativeValue)
        {
            int value;
            if (data.TryGetValue(dateTime, out value))
            {
                value += relativeValue;
                if (value == 0)
                {
                    data.Remove(dateTime);
                }
                else
                {
                    data[dateTime] = value;
                }
            }
            else
            {
                value = relativeValue;
                data[dateTime] = value;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the set.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Collections.Generic.IEnumerator{T}"/> that can be used to iterate through
        /// the set.
        /// </returns>
        public IEnumerator<Period> GetEnumerator()
        {
            int newValue = 0;
            DateTime from = DateTime.MinValue;

            foreach (var item in data)
            {
                int oldValue = newValue;
                newValue += item.Value;

                if ((oldValue == 0) && (newValue > 0))
                {
                    from = item.Key;
                }

                if ((newValue == 0) && (oldValue > 0))
                {
                    yield return new Period(from, item.Key);
                }
            }
        }

        /// <summary>
        /// Returns the current set without periods in the specified set.
        /// </summary>
        public PeriodSet ExceptWith(PeriodSet other)
        {
            var result = new PeriodSet();
            foreach (Period item in this)
            {
                result.Add(item.From, +1);
                result.Add(item.To, -1);
            }
            foreach (Period item in other)
            {
                result.Add(item.From, -1);
                result.Add(item.To, +1);
            }
            result.Normalize();

            return result;
        }

        /// <summary>
        /// Returns a set that only contains periods that exist in the current set and the specified set.
        /// </summary>
        public PeriodSet IntersectWith(PeriodSet other)
        {
            return UnionWith(other).SymmetricExceptWith(SymmetricExceptWith(other));
        }

        /// <summary>
        /// Returns a set that contains only periods that are present either in the current set or in the specified set, but not both.
        /// </summary>
        public PeriodSet SymmetricExceptWith(PeriodSet other)
        {
            return ExceptWith(other).UnionWith(other.ExceptWith(this));
        }

        /// <summary>
        /// Returns a set with all periods that are present in both the current set and in the specified collection.
        /// </summary>
        public PeriodSet UnionWith(PeriodSet other)
        {
            return new PeriodSet(this.Concat(other));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
