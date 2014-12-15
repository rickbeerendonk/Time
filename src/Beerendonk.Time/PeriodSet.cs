using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Beerendonk.Time
{
    public class PeriodSet : IEnumerable<Period>
    {
        private SortedDictionary<DateTime, int> data = new SortedDictionary<DateTime, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodSet"/> class.
        /// </summary>
        /// <param name="periods">A collection of <see cref="Period"/> classes.</param>
        public PeriodSet(params Period[] periods)
            : this((IEnumerable<Period>)periods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodSet"/> class.
        /// </summary>
        /// <param name="periods">A collection of <see cref="Period"/> classes.</param>
        public PeriodSet(IEnumerable<Period> periods)
        {
            foreach (var period in periods)
            {
                Add(period);
            }
        }

        /// <summary>
        /// Adds a period.
        /// </summary>
        /// <param name="period">A period.</param>
        public bool Add(Period period)
        {
            Add(period.From, +1);
            Add(period.To, -1);

            return true;
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
            int value = 0;
            DateTime from = DateTime.MinValue;

            foreach (var item in data)
            {
                if (value == 0)
                {
                    from = item.Key;
                }

                value += item.Value;

                if (value == 0)
                {
                    yield return new Period(from, item.Key);
                }
            }
        }

        public PeriodSet ExceptWith(PeriodSet other)
        {
            throw new NotImplementedException();
        }

        public PeriodSet IntersectWith(PeriodSet other)
        {
            throw new NotImplementedException();
        }

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
