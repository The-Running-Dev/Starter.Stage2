using System;
using System.IO;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;
using Starter.Bootstrapper;
using Starter.Data.Entities;
using Starter.Data.Repositories;

namespace Starter.Repository.Tests
{
    [SetUpFixture]
    public class TestsBase
    {
        protected ICatRepository CatRepository;
        protected Mock<ICatRepository> CatRepositoryMock;

        protected List<Cat> Cats;

        /// <summary>
        /// One time setup for all test execution
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Setup.Bootstrap();

            CreateCatTestData();

            CatRepositoryMock = new Mock<ICatRepository>();

            //// Setup the cat repository
            //CatRepositoryMockObject.Setup(x => x.GetAll()).Returns(Task.FromResult(Cats.AsEnumerable()));
            //CatRepositoryMockObject.Setup(x => x.GetById(It.IsAny<Guid>()))
            //    .Returns(Task.FromResult(Cats.FirstOrDefault()));
            //CatRepositoryMockObject.Setup(x => x.Delete(It.IsAny<Cat>())).Returns(Task.CompletedTask);

            CatRepository = IocWrapper.Instance.GetService<ICatRepository>();
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

        protected string GetTemporaryFile()
        {
            return Path.Combine(Path.GetTempPath(), $"Cats-{Guid.NewGuid()}.json");
        }
    }
}