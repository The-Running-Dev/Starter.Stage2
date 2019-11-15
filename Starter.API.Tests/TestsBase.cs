using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using Starter.Bootstrapper;
using Starter.Data.Entities;
using Starter.API.Controllers;
using Starter.Data.Repositories;

namespace Starter.API.Tests
{
    [SetUpFixture]
    public class TestsBase
    {
        protected List<Cat> Cats;

        protected CatController CatController;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Setup.Bootstrap();

            CreateCatTestData();

            var catRepository = new Mock<ICatRepository>();

            // Setup the cat repository
            catRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(Cats.AsEnumerable()));

            catRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .Returns((Guid id) => { return Task.FromResult(Cats.FirstOrDefault(x => x.Id == id)); });

            catRepository.Setup(x => x.CreateAsync(It.IsAny<Cat>()))
                .Returns((Cat entity) =>
                {
                    Cats.Add(entity);
                    return Task.CompletedTask;
                });
            
            catRepository.Setup(x => x.DeleteAsync(It.IsAny<Guid>()))
                .Returns((Guid id) =>
                {
                    Cats.Remove(Cats.FirstOrDefault(x=>x.Id == id));
                    return Task.CompletedTask;
                });

            CatController = new CatController(catRepository.Object);
        }

        protected void CreateCatTestData()
        {
            Cats = new List<Cat>
            {
                new Cat { Id = Guid.NewGuid(), Name  = "Widget", AbilityId = (int)Ability.Eating },
                new Cat { Id = Guid.NewGuid(), Name  = "Garfield", AbilityId = (int)Ability.Engineering },
                new Cat { Id = Guid.NewGuid(), Name  = "Mr. Boots", AbilityId = (int)Ability.Lounging }
            };
        }
    }
}