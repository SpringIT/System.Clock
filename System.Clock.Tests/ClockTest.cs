using FluentAssertions;
using NUnit.Framework;

namespace System.Tests
{
    [TestFixture]
    public class ClockTest
    {
        [TearDown]
        public void Setup()
        {
            Clock.Reset();
        }

        [Test]
        public void Now()
        {
            Clock.DateTimeProvider = () => new DateTime(2014, 1, 1, 12, 0, 0);

            var expected = new DateTime(2014, 1, 1, 12, 0, 0);

            Clock.Now.Should().Be(expected);
        }

        [Test]
        public void Today()
        {
            Clock.DateTimeProvider = () => new DateTime(2014, 1, 1, 12, 0, 0);

            var expected = new DateTime(2014, 1, 1, 0, 0, 0);

            Clock.Today.Should().Be(expected);
        }

        [Test]
        public void Yesterday()
        {
            Clock.DateTimeProvider = () => new DateTime(2014, 1, 1, 12, 0, 0);

            var expected = new DateTime(2013, 12, 31, 0, 0, 0);

            Clock.Yesterday.Should().Be(expected);
        }

        [Test]
        public void Tomorrow()
        {
            Clock.DateTimeProvider = () => new DateTime(2014, 1, 1, 12, 0, 0);

            var expected = new DateTime(2014, 1, 2, 0, 0, 0);

            Clock.Tomorrow.Should().Be(expected);
        }

        [Test]
        public void Ticks()
        {
            Clock.DateTimeProvider = () => new DateTime(2014, 1, 1, 0, 0, 0);

            var expected = new DateTime(2014, 1, 1, 0, 0, 0).Ticks;

            Clock.Ticks.Should().Be(expected);
        }


    }
}
