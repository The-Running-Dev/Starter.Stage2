using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using FluentAssertions;
using NUnit.Framework;
using Starter.Framework.Extensions;

namespace Starter.Framework.Tests.Extensions
{
    /// <summary>
    /// Tests for the StringExtensions class
    /// </summary>
    [TestFixture]
    public class DbCommandExtensionsTests
    {
        [Test]
        public void Add_NullParametersToCommand_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => new SqlCommand().AddParameters(null));
        }

        [Test]
        //public void Should_Add_Single_Parameter_to_Command()
        public void Add_SingleParameterToCommand_Successful()
        {
            var command = new SqlCommand();

            command.AddParameters(new dynamic[] { new SqlParameter() });

            command.Parameters.Count.Should().Be(1);
        }

        [Test]
        public void Add_MultipleParametersToCommand_Successful()
        {
            var command = new SqlCommand();

            command.AddParameters(new dynamic[] { new SqlParameter(), new SqlParameter() });

            command.Parameters.Count.Should().Be(2);
        }
    }
}