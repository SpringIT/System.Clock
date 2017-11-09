using FluentAssertions;
using NUnit.Framework;
using SimpleInjector;

namespace System.Tests
{
    [TestFixture]
    public class ContainerTest 
    {
        [Test]
        public void Container()
        {
            var container = new Container();
            container.Register<IClock, ClockProvider>();

            var clock = container.GetInstance<IClock>();

            clock.Now.Should().BeCloseTo(DateTime.Now);
        }

        private class MondayChecker
        {
            private readonly IClock _clock;

            public MondayChecker(IClock clock)
            {
                _clock = clock;
            }

            public bool IsTodayMonday()
            {
                return _clock.Now.DayOfWeek == DayOfWeek.Monday;
            }
        }

        [Test]
        public void DependencyTest()
        {
            var container = new Container();
            container.Register<IClock, ClockProvider>();
            container.Register<MondayChecker>();

            var mondayChecker = container.GetInstance<MondayChecker>();

            mondayChecker.IsTodayMonday();
        }
    }

    
}