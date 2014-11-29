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
using System.Globalization;

namespace Beerendonk.Time
{
    /// <summary>
    /// Defines a Time Period.
    /// </summary>
    public struct Period
    {
        private readonly DateTime from;

        private readonly DateTime to;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Period" /> structure.
        /// </summary>
        /// <param name="from">The moment the period starts.</param>
        /// <param name="to">The moment the period ends.</param>
        public Period(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Period" /> structure.
        /// </summary>
        /// <param name="from">The moment the period starts.</param>
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
        /// <param name="to">The moment the period ends.</param>
        public Period(TimeSpan duration, DateTime to)
        {
            this.from = to - duration;
            this.to = to;
        }

        /// <summary>
        /// Defines the moment the period starts.
        /// </summary>
        public DateTime From 
        { 
            get 
            {
                return from;
            }
        }

        /// <summary>
        /// Defines the moment the period ends.
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
        /// with <see cref="T:System.DateTime" />s as specified by <paramref name="provider" />.
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

        /// <summary>Converts the value of the current <see cref="T:Period" /> object to its 
        /// equivalent string representation using the specified culture-specific format information.
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
            return String.Format("{0} - {1}", To.ToString(format, provider), From.ToString(format, provider));
        }
    }
}
