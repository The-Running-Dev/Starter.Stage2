using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

using Starter.Data.Entities;
using Starter.API.Controllers;
using Starter.Data.Repositories;

namespace Starter.API.Tests.Controllers
{
    [TestFixture]
    public class CatControllerTests
    {
        public CatControllerTests(ICatRepository repository)
        {
            _controller = new CatController(repository);
        }

        [Test]
        public async Task Get_AllCats_Successful()
        {
            var entities = await _controller.GetAll();

            Assert.IsNotNull(entities);
            Assert.AreEqual(2, entities.Count());
            
            Assert.AreEqual("value1", entities.ElementAt(0));
            Assert.AreEqual("value2", entities.ElementAt(1));
        }

        [Test]
        public async Task Get_CatById_Successful()
        {
            var result = await _controller.GetById(Guid.Empty);

            Assert.AreEqual("value", result);
        }

        [Test]
        public async Task Create_Cat_Successful()
        {
            await _controller.Post(new Cat());
        }

        [Test]
        public async Task Update_Cat_Successful()
        {
            await _controller.Put(new Cat());
        }

        [Test]
        public async Task Delete_Cat_Successful()
        {
            await _controller.Delete(Guid.Empty);
        }

        private readonly CatController _controller;
    }
}
