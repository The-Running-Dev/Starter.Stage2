using NUnit.Framework;
using FluentAssertions;

using Starter.Framework.Extensions;

namespace Starter.Framework.Tests.Extensions
{
    /// <summary>
    /// Tests for the StringExtensions class
    /// </summary>
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void Convert_ObjectToJson_Successful()
        {
            dynamic entity = new { Id = 1, Name = "Name" };

            ((object) entity).ToJson().Should().Be("{\"Id\":1,\"Name\":\"Name\"}");
        }

        [Test]
        public void Convert_ObjectToJsonWithFormatting_Successful()
        {
            dynamic entity = new { Id = 1, Name = "Name" };

            var json = ((object) entity).ToJson(true);
            
            json.Should().NotBeEmpty();
            json.Should().Contain("\"Id\": 1");
        }
    }
}