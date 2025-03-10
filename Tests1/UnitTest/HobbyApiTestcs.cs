using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Internal;

namespace Tests.UnitTest
{
    [TestFixture]
    public class HobbyApiTestcs
    {
        private Mock<IHobbyService> _mockService;
        private HobbyController _controller;
        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IHobbyService>();
            _controller = new HobbyController(_mockService.Object);
        }
        [Test]
        public async Task GetAll_ReturnsOkResult()
        {
            //Arrange
            var hobby1 = new List<Hobby> {
                new Hobby { ID = 1, Title = "Test", ImageSrc = "1", Description = "" },
                new Hobby { ID = 2, Title = "Test", ImageSrc = "2", Description = "" }
            };

            _mockService.Setup(s => s.GetAllHobbies()).ReturnsAsync(hobby1);
            // Act
            var result = await _controller.GetAll();


            // Assert: Verifying that the returned result matches the expected item
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(hobby1));
        }
        [Test]
        public async Task GetAll_ReturnsNoContentResult()
        {
            //Arrange
            List<Hobby> hobby = null;

            _mockService.Setup(s => s.GetAllHobbies()).ReturnsAsync(hobby);
            // Act
            var result = await _controller.GetAll();


            // Assert: Verifying that the returned result matches the expected item
            var noContentResult = result as NoContentResult;
            Assert.That(noContentResult, Is.Not.Null);
            Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
        }
        [Test]
        public async Task Delete_ReturnsOkResult()
        {
            //Arrange
            int id = 1;
            _mockService.Setup(s => s.DeleteHobby(id)).ReturnsAsync("Success");
            // Act
            var result = await _controller.Delete(id);
            // Assert: Verifying that the returned result matches the expected item
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public async Task Delete_ReturnsNotFoundResult()
        {
            //Arrange
            int id = 1;
            _mockService.Setup(s => s.DeleteHobby(id)).ReturnsAsync((string)null);
            // Act
            var result = await _controller.Delete(id);
            // Assert: Verifying that the returned result matches the expected item
            var notFoundResult = result as NotFoundResult;
            Assert.That(notFoundResult, Is.Not.Null);
            Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
        }
        [Test]
        public async Task Update_ReturnCreated()
        {
            int id = 1;
            var hobby = new JsonPatchDocument<Hobby>();
            _mockService.Setup(s => s.UpdateHobby(id, hobby)).ReturnsAsync(new Hobby { ID = 1, Title = "Test", ImageSrc = "1", Description = "" });
            // Act
            var result = await _controller.update(id, hobby);
            // Assert: Verifying that the returned result matches the expected item
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public async Task Update_ReturnNotFound()
        {
            int id = 1;
            var hobby = new JsonPatchDocument<Hobby>();
            _mockService.Setup(s => s.UpdateHobby(id, hobby)).ReturnsAsync((Hobby)null);
            // Act
            var result = await _controller.update(id, hobby);
            // Assert: Verifying that the returned result matches the expected item
            var notFoundResult = result as NotFoundResult;
            Assert.That(notFoundResult, Is.Not.Null);
            Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
        }
        [Test]
        public async Task Update_ReturnBadRequest()
        {
            int id = 1;
            JsonPatchDocument<Hobby> hobby = null;
            // Act
            var result = await _controller.update(id, hobby);
            // Assert: Verifying that the returned result matches the expected item
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }
        [Test]
        public async Task Add_ReturnCreated()
        {
            var hobby = new Hobby { ID = 1, Title = "Test", ImageSrc = "1", Description = "" };
            _mockService.Setup(s => s.AddHobby(hobby)).ReturnsAsync("Success");
            // Act
            var result = await _controller.Add(hobby);
            // Assert: Verifying that the returned result matches the expected item
            var createdResult = result as CreatedResult;
            Assert.That(createdResult, Is.Not.Null);
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
        }
    }
}
