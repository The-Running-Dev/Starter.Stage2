using System;

using NUnit.Framework;
using FluentAssertions;
using Microsoft.SqlServer.Server;

using Starter.Data.Entities;
using Starter.Framework.Extensions;

namespace Starter.Framework.Tests.Extensions
{
    /// <summary>
    /// Tests for the StringExtensions class
    /// </summary>
    [TestFixture]
    public class DataRecordExtensionsTests: TestsBase
    {
        [Test]
        public void Verify_ColumnDoesNotExist_Successful()
        {
            SqlDataRecord.HasColumn("Age").Should().BeFalse();
        }

        [Test]
        public void Verify_ColumnExist_Successful()
        {
            SqlDataRecord.HasColumn("Name").Should().BeTrue();
        }

        [Test]
        public void Verify_ColumnExistWithDifferentCaseName_Successful()
        {
            SqlDataRecord.HasColumn("name").Should().BeTrue();
        }

        [Test]
        public void Verify_WhenNullColumnDoesNotExist_Successful()
        {
            SqlDataRecord record = null;

            record.HasColumn("Name").Should().BeFalse();
        }

        [Test]
        public void Map_Object_Successful()
        {
            var id = Guid.NewGuid();
            var name = "Frank";

            SqlDataRecord.SetGuid(0, id);
            SqlDataRecord.SetString(1, name);

            var cat = SqlDataRecord.Map<Cat>();

            cat.Id.Should().Be(id);
            cat.Name.Should().Be(name);
        }
    }
}
