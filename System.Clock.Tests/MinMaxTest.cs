using FluentAssertions;
using NUnit.Framework;

namespace System.Tests
{
    [TestFixture]
    public class MinMaxTest
    {
        [TearDown]
        public void Setup()
        {
            Clock.Reset();
        }

        [Test]
        public void Min()
        {
            var left = Clock.Today;
            var right = Clock.Tomorrow;

            var actual = Clock.Min(left, right);
            actual.Should().Be(left);
        }

        [Test]
        public void Max()
        {
            var left = Clock.Today;
            var right = Clock.Tomorrow;

            var actual = Clock.Max(left, right);
            actual.Should().Be(right);
        }
    }
}
