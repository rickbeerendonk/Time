// Copyright (c) Rick Beerendonk. All rights reserved.
//
// The use and distribution terms for this software are covered by the
// Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
// which can be found in the file LICENSE at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by
// the terms of this license.
//
// You must not remove this notice, or any other, from this software.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Beerendonk.Time
{
    /// <summary>
    /// Defines a Time Period.
    /// </summary>
    public struct Period : IEquatable<Period>
    {
        private readonly DateTime from;

        private readonly DateTime to;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Period" /> structure.
        /// </summary>
        /// <param name="from">The moment the period starts (included).</param>
        /// <param name="to">The moment the period ends (excluded).</param>
        public Period(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Period" /> structure.
        /// </summary>
        /// <param name="from">The moment the period starts (included).</param>
        /// <param name="duration">The duration of the period.</param>
        public Period(DateTime from, TimeSpan duration)
        {
            this.from = from;
            this.to = from + duration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Period" /> structure.
        /// </summary>
        /// <param name="duration">The duration of the period.</param>
        /// <param name="to">The moment the period ends (excluded).</param>
        public Period(TimeSpan duration, DateTime to)
        {
            this.from = to - duration;
            this.to = to;
        }

        /// <summary>
        /// Gets the duration of the period.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return to - from;
            }
        }

        /// <summary>
        /// Gets the moment the period starts (included).
        /// </summary>
        public DateTime From 
        { 
            get 
            {
                return from;
            }
        }

        /// <summary>
        /// Gets the moment the period ends (excluded).
        /// </summary>
        public DateTime To 
        { 
            get 
            { 
                return to; 
            } 
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return ToString(null, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="T:Period" /> object to its equivalent 
        /// string representation using the specified format for each <see cref="T:System.DateTime" />.
        /// </summary>
        /// <returns>
        /// A string representation of value of the current <see cref="T:System.Period" /> object 
        /// with <see cref="T:System.DateTime" />s as specified by <paramref name="format" />.
        /// </returns>
        /// <param name="format">A standard or custom date and time format string (see Remarks).</param>
        /// <exception cref="T:System.FormatException">
        /// The length of <paramref name="format" /> is 1, and it is not one of the format specifier 
        /// characters defined for <see cref="T:System.Globalization.DateTimeFormatInfo" />.-or- 
        /// <paramref name="format" /> does not contain a valid custom format pattern.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date and time is outside the range of dates supported by the calendar used by the 
        /// current culture.
        /// </exception>
        public string ToString(string format)
        {
            return ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="T:Period" /> object to its equivalent 
        /// string representation using the specified culture-specific format information.
        /// </summary>
        /// <returns>
        /// A string representation of value of the current <see cref="T:System.Period" /> object 
        /// with <see cref="T:System.DateTime" />s as specified by <paramref name="provider" />.
        /// </returns>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date and time is outside the range of dates supported by the calendar used by 
        /// <paramref name="provider" />.
        /// </exception>
        public string ToString(IFormatProvider provider)
        {
            return ToString(null, provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="T:Period" /> object to its equivalent 
        /// string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <returns>
        /// A string representation of value of the current <see cref="T:System.Period" /> object 
        /// with <see cref="T:System.DateTime" />s as specified by <paramref name="format" /> and 
        /// <paramref name="provider" />.
        /// </returns>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <exception cref="T:System.FormatException">
        /// The length of <paramref name="format" /> is 1, and it is not one of the format specifier 
        /// characters defined for <see cref="T:System.Globalization.DateTimeFormatInfo" />.-or- 
        /// <paramref name="format" /> does not contain a valid custom format pattern.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date and time is outside the range of dates supported by the calendar used by 
        /// <paramref name="provider" />.
        /// </exception>
        public string ToString(string format, IFormatProvider provider)
        {
            return String.Format("{0} - {1}", from.ToString(format, provider), to.ToString(format, provider));
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <returns><c>true</c> if <paramref name="obj" /> is an instance of <see cref="T:Period" /> 
        /// and equals the value of this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <param name="obj">The object to compare to this instance. </param>
        public override bool Equals(object obj)
        {
            return obj is Period && Equals((Period)obj);
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the 
        /// value of the specified <see cref="T:Period" /> instance.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the <paramref name="other" /> parameter equals the value of this 
        /// instance; otherwise, <c>false</c>.
        /// </returns>
        /// <param name="other">The object to compare to this instance. </param>
        public bool Equals(Period other)
        {
            return Equals(this, other);
        }

        /// <summary>
        /// Returns a value indicating whether two <see cref="T:Period" /> instances have 
        /// the same date and time value.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the two values are equal; otherwise, <c>false</c>.
        /// </returns>
        /// <param name="p1">The first object to compare.</param>
        /// <param name="p2">The second object to compare.</param>
        public static bool Equals(Period p1, Period p2)
        {
            return p1.from == p2.from && p1.to == p2.to;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return to.GetHashCode() + from.GetHashCode();
        }

        /// <summary>
        /// Gets the current day.
        /// </summary>
        /// <returns>
        /// An object that is set to today, with the included start time set to 00:00:00 today 
        /// and the exluded end time set to 00:00:00 the next day.
        /// </returns>
        public static Period Today
        {
            get
            {
                // Prevent asking Now twice and potentially get two dates.
                var now = DateTime.Now;
                return new Period(now.Date, now.Date.AddDays(1));
            }
        }

        /// <summary>
        /// Returns a value indicating whether two <see cref="T:Period" /> instances have equal.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the two values are equal; otherwise, <c>false</c>.
        /// </returns>
        /// <param name="p1">The first object to compare.</param>
        /// <param name="p2">The second object to compare.</param>
        public static bool operator ==(Period p1, Period p2)
        {
            return Equals(p1, p2);
        }

        /// <summary>
        /// Returns a value indicating whether two <see cref="T:Period" /> instances are different.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the two values are equal; otherwise, <c>false</c>.
        /// </returns>
        /// <param name="p1">The first object to compare.</param>
        /// <param name="p2">The second object to compare.</param>
        public static bool operator !=(Period p1, Period p2)
        {
            return !Equals(p1, p2);
        }

        public static IEnumerable<Period> operator +(Period p1, Period p2)
        {
            if (p1.to < p2.from || p1.from > p2.to)
            {
                yield return p1;
                yield return p2;
                yield break;
            }

            yield return new Period(
                new DateTime(Math.Min(p1.from.Ticks, p2.from.Ticks)),
                new DateTime(Math.Max(p1.to.Ticks, p2.to.Ticks)));
        }

        public static IEnumerable<Period> operator -(Period p1, Period p2)
        {
            if (p1.from < p2.from)
            {
                yield return new Period(
                    p1.from,
                    new DateTime(Math.Min(p1.to.Ticks, p2.from.Ticks)));
            }

            if (p1.to > p2.to)
            {
                yield return new Period(
                    new DateTime(Math.Max(p1.from.Ticks, p2.to.Ticks)),
                    p1.to);
            }
        }
    }
}
