using System.Runtime.Remoting.Metadata.W3cXsd2001;
using FluentAssertions;
using NUnit.Framework;

namespace System.Tests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [TearDown]
        public void Setup()
        {
            Clock.Reset();
        }

        [TestCase(2014, 1, 1,31)]
        [TestCase(2014, 2, 1,28)]
        [TestCase(2014, 3, 1,31)]
        [TestCase(2014, 4, 1,30)]
        [TestCase(2014, 5, 1, 31)]
        [TestCase(2014, 6, 1, 30)]
        [TestCase(2014, 7, 1, 31)]
        [TestCase(2014, 8, 1, 31)]
        [TestCase(2014, 9, 1, 30)]
        [TestCase(2014, 10, 1, 31)]
        [TestCase(2014, 11, 1, 30)]
        [TestCase(2014, 12, 1, 31)]
        public void EndOfMonth(int year, int month, int day, int expectedDay)
        {
            var date = new DateTime(year, month, day, 12, 0, 0);
            var expected = new DateTime(year, month, expectedDay, 23, 59, 59);

            date.EndOfMonth().Should().Be(expected);
        }

        [Test]
        public void EndOfMonthWithAllDaysInAGivenMonth()
        {
            const int year = 2014;
            const int month = 12;

            var daysInMonth = DateTime.DaysInMonth(year, month);

            for (var day = 1; day < daysInMonth; day++)
            {
                var date = new DateTime(year, 12, day, 12, 0, 0);
                var expected = new DateTime(year, month, daysInMonth, 23, 59, 59);
                date.EndOfMonth().Should().Be(expected);
            }

        }

        [TestCase(1804, 2, 1, 29)]
        [TestCase(2000, 2, 1, 29)]
        [TestCase(2004, 2, 1, 29)]
        [TestCase(2008, 2, 1, 29)]
        [TestCase(2012, 2, 1, 29)]
        [TestCase(2016, 2, 1, 29)]
        public void EndOfMonthInLeapYear(int year, int month, int day, int expectedDay)
        {
            var date = new DateTime(year, month, day, 12, 0, 0);
            var expected = new DateTime(year, month, expectedDay, 23, 59, 59);

            date.EndOfMonth().Should().Be(expected);
        }
    }
}