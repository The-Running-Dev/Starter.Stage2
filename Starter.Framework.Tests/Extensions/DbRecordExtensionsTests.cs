using System;
using System.Data;

using NUnit.Framework;
using Starter.Framework.Extensions;

namespace Starter.Framework.Tests.Extensions
{
    /// <summary>
    /// Tests for the StringExtensions class
    /// </summary>
    [TestFixture]
    public class DataRecordExtensionsTests
    {
        [Test]
        public void Verify_ColumnDoesNotExist_Successful()
        //(IDataRecord dataRecord, string columnName)
        {
            //for (var i = 0; i < dataRecord.FieldCount; i++)
            //{
            //    if (dataRecord.GetName(i).IsEqualTo(columnName))
            //    {
            //        return true;
            //    }
            //}

            //return false;
            Assert.Fail();
        }

        [Test]
        public void Verify_ColumnExist_Successful()
        {
            Assert.Fail();
        }

        [Test]
        public void Map_Object_Successful()
        //(IDataRecord record)
        {
            //var entity = Activator.CreateInstance<T>();

            //foreach (var property in typeof(T).GetProperties())
            //{
            //    if (record.HasColumn(property.Name) &&
            //        !record.IsDBNull(record.GetOrdinal(property.Name)))
            //    {
            //        property.SetValue(entity, record[property.Name]);
            //    }
            //}

            //return entity;
            Assert.Fail();
        }
    }
}
