using NUnit.Framework;

using Starter.Bootstrapper;

namespace Starter.Data.Tests
{
    [SetUpFixture]
    public class TestsBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Setup.Bootstrap();
        }
    }
}