using FluentAssertions;
using NUnit.Framework;

namespace System.Tests
{
    [TestFixture]
    public class ClockProviderTest
    {
        private IClock _clockProvider;

        private class TestClock : IClock
        {
            internal static readonly DateTime TheClock = new DateTime(2014, 1, 1, 12, 0, 0);

            public DateTime Now => TheClock;
        }

        [SetUp]
        public void Setup()
        {


            _clockProvider = new TestClock();
        }

        [Test]
        public void Now()
        {
            var now = _clockProvider.Now;

            now.Should().Be(TestClock.TheClock);
        }

        [Test]
        public void Today()
        {
            var expected = new DateTime(2014, 1, 1, 0, 0, 0);

            _clockProvider.Today().Should().Be(expected);
        }

        [Test]
        public void Yesterday()
        {

            var expected = new DateTime(2013, 12, 31, 12, 0, 0);

            _clockProvider.Yesterday().Should().Be(expected);
        }

        [Test]
        public void Tomorrow()
        {
            var expected = new DateTime(2014, 1, 2, 12, 0, 0);

            _clockProvider.Tomorrow().Should().Be(expected);
        }

        [Test]
        public void Ticks()
        {

            var expected = new DateTime(2014, 1, 1, 12, 0, 0).Ticks;

            _clockProvider.Ticks().Should().Be(expected);
        }

        [Test]
        public void StartOfDay()
        {

            var expected = new DateTime(2014, 1, 1, 0, 0, 0);

            _clockProvider.Now.StartOfDay().Should().Be(expected);
        }

        [Test]
        public void EndOfDay()
        {

            var expected = new DateTime(2014, 1, 1, 23, 59, 59);

            _clockProvider.Now.EndOfDay().Should().Be(expected);
        }


        [Test]
        public void StartOfMonth()
        {

            var expected = new DateTime(2014, 1, 1, 0, 0, 0);

            _clockProvider.Now.StartOfMonth().Should().Be(expected);
        }

        [Test]
        public void EndOfMonth()
        {

            var expected = new DateTime(2014, 1, 31, 23, 59, 59);

            _clockProvider.Now.EndOfMonth().Should().Be(expected);
        }

        [Test]
        public void Min()
        {
            var right = new DateTime(2014, 1, 1, 12, 0, 0).AddMilliseconds(1);
            var expected = TestClock.TheClock;

            _clockProvider.Now.Min(right).Should().Be(expected);
        }

        [Test]
        public void Max()
        {
            var right = new DateTime(2014, 1, 1, 12, 0, 0).AddMilliseconds(1);
            var expected = new DateTime(2014, 1, 1, 23, 59, 59);

            _clockProvider.Now.Max(right).Should().Be(right);
        }

    }
}