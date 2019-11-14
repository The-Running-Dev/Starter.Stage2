using System;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;
using FluentAssertions;

using Starter.Data.Entities;

namespace Starter.Repository.Tests.Repositories
{
    /// <summary>
    /// Contains tests for the CatRepository class
    /// </summary>
    [TestFixture]
    public class CatRepositoryTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            //CreateCatTestData();

            //CatDataRepository.Stub(x => x.LoadAsync(Arg<bool>.Is.Anything))
            //    .Return(Task.FromResult(Cats.AsEnumerable()));
        }

        [Test]
        public async Task Get_AllCats_Successful()
        {
            var cats = await CatRepository.GetAllAsync();

            cats.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Get_CatById_Successful()
        {
            var cat = Cats.FirstOrDefault();
            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Name.Should().Be(cat.Name);
        }

        [Test]
        public async Task Add_Cat_Successful()
        {
            var cat = new Cat { Name = Guid.NewGuid().ToString(), AbilityId = (int)Ability.Napping };

            Cats.Add(cat);
            await CatRepository.AddAsync(cat);

            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Id.Should().Be(cat.Id);
        }

        [Test]
        public async Task Update_Cat_Successful()
        {
            var cat = Cats.FirstOrDefault();
            cat.Name = Guid.NewGuid().ToString();

            await CatRepository.UpdateAsync(cat);

            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Id.Should().Be(cat.Id);
        }

        [Test]
        public async Task Delete_Cat_Successful()
        {
            var cat = Cats.FirstOrDefault();
            cat.Name = Guid.NewGuid().ToString();

            await CatRepository.DeleteAsync(cat.Id);
            Cats.Remove(cat);

            var existingCat = await CatRepository.GetByIdAsync(cat.Id);

            existingCat.Should().BeNull();
        }

        [Test]
        public async Task Get_AllCatsGet3Cats_Successful()
        {
            var results = await CatRepository.GetAllAsync();

            results.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Get_AllCatsSpecificCatExists_Successful()
        {
            var cat = Cats.FirstOrDefault();
            var cats = await CatRepository.GetAllAsync();

            cats.FirstOrDefault(x => x.Name == cat.Name).Should().NotBeNull();
        }
    }
}