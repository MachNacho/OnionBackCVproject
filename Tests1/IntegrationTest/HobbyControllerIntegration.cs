using System.Net.Http.Json;
using System.Text.Json;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace Tests.IntegrationTest
{
    [TestFixture]
    public class HobbyControllerIntegration
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;   
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
            //_client.BaseAddress = new System.Uri("https://localhost:44344");
        }

        [Test]
        public async Task GetEndpoint_ShouldReturn_SuccessStatusCode()
        {
            //Arrange
            var requestUrl = "/api/Hobby";
            //Act
            var response = await _client.GetAsync(requestUrl);
            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"Expected 200 OK but got {response.StatusCode}");
            var hobbyList = await response.Content.ReadFromJsonAsync<List<Hobby>>();
            Assert.That(hobbyList, Is.Not.Null);
            Assert.That(hobbyList, Is.Not.Empty);
            Assert.That(hobbyList.All(h => !string.IsNullOrEmpty(h.Title)), Is.True, "All hobbies should have a title");
        }
        [Test]
        public async Task CreateEndpoint_ShouldReturn_CreatedStatusCode()
        {
            //Arrange
            var requestUrl = "/api/Hobby";
            var hobby = new Hobby { Title = "Test", ImageSrc = "1", Description = "" };
            //Act
            var response = await _client.PostAsJsonAsync(requestUrl, hobby);
            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created, $"Expected 201 Created but got {response.StatusCode}");
        }
        [Test]
        public async Task UpdateEndpoint_ShouldReturn_OkStatusCode()
        {
            //Arrange
            //Createing product to update
            //var hobby = new Hobby {Title = "TestUpdate", ImageSrc = "TestPostUpdate", Description = "TestPostUpdate" };
            //await _client.PostAsJsonAsync("/api/Hobby", hobby);

            //Creating patch document
            var hobbyPatch = new JsonPatchDocument<Hobby>().Replace(h => h.Title, "Changed");

            var jsonPatch = JsonSerializer.Serialize(hobbyPatch);
            var content = new StringContent(jsonPatch, System.Text.Encoding.UTF8, "application/json-patch+json");

            var requestUrl = "/api/Hobby/6002";

            //Act
            var response = await _client.PatchAsync(requestUrl, content);

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"Expected 200 OK but got {response.StatusCode}");
            var updatedHobby = await _client.GetFromJsonAsync<Hobby>("/api/Hobby/2002");
            Assert.That(updatedHobby.Title, Is.EqualTo("Changed"));
        }
        [Test]
        public async Task DeleteEndpoint_ShouldReturn_OkStatusCode()
        {
            //Arrange
            var requestUrl = "/api/Hobby/5002";
            //Act
            var response = await _client.DeleteAsync(requestUrl);
            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"Expected 200 OK but got {response.StatusCode}");
        }

        [TearDown]
        public void TearDown()
        {

            _client?.Dispose();
            _factory?.Dispose();
        }
    }
}
