using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Tests.UnitTest
{
    [TestFixture]
    public class HobbyRepositoryTest
    {
        private HobbyRepository _hobbyRepository;
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _hobbyRepository = new HobbyRepository(_context);
        }
        [Test]
        public async Task GetAllAsync_ReturnAllProducts_WhenExists_ReturnList()
        {
            //Arrange
            _context.Hobby.Add(new Hobby { Title = "", ImageSrc = "1", Description = "" });
            _context.SaveChanges();

            //Act
            var result = await _hobbyRepository.GetAll();

            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));

        }
        [Test]
        public async Task GetAllAsync_WhenNonExists_ReturnNull()
        {
            //Arrange

            //Act
            var result = await _hobbyRepository.GetAll();

            //Assert
            Assert.That(result, Is.Null);

        }
        [Test]
        public async Task AddAsync_ReturnAddedProduct()
        {
            //Arrange
            var hobby = new Hobby { ID = 1, Title = "Test", ImageSrc = "1", Description = "" };

            //Act
            var result = await _hobbyRepository.Add(hobby);

            //Assert
            Assert.That(result, Is.EqualTo(true));

        }
        [Test]
        public async Task DeleteAsync_NotFound_ReturnFalse()
        {
            //Arrange

            //Act
            var result = await _hobbyRepository.Delete(2);
            //Assert
            Assert.That(result, Is.EqualTo(false));
        }
        [Test]
        public async Task DeleteAsync_NotFound_ReturnProduct()
        {
            //Arrange
            var hobby = new Hobby { ID = 1, Title = "Test", ImageSrc = "1", Description = "" };
            await _hobbyRepository.Add(hobby);
            //Act
            var result = await _hobbyRepository.Delete(1);
            //Assert
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public async Task UpdateAsync_ReturnProduct()
        {
            //Arrange
            var hobby = new Hobby { ID = 1, Title = "Test", ImageSrc = "1", Description = "" };
            await _hobbyRepository.Add(hobby);
            var patch = new JsonPatchDocument<Hobby>();
            patch.Replace(x => x.Title, "Test2");
            //Act
            var result = await _hobbyRepository.Update(1, patch);
            //Assert
            Assert.That(result.Title, Is.EqualTo("Test2"));
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose(); ;
        }
    }

}
