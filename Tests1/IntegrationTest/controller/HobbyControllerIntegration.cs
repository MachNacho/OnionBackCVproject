using System.Net.Http.Json;
using System.Text.Json;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.IntegrationTest.Controller
{
    [TestFixture]
    public class HobbyControllerIntegration
    {

        private HttpClient _client;
        private CustomWebApplicationFactory<Program> _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _client = _factory.CreateClient();
            Console.WriteLine($"Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");


        }
        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [Test]
        public async Task GetEndpoint_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var requestUrl = "/api/Hobby";

            // Act
            var response = await _client.GetAsync(requestUrl);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"Expected 200 OK but got {response.StatusCode}");
            var hobbyList = await response.Content.ReadFromJsonAsync<List<Hobby>>();
            hobbyList.Should().NotBeNull().And.NotBeEmpty();
            hobbyList.Should().OnlyContain(h => !string.IsNullOrEmpty(h.Title));
        }

        [Test]
        public async Task CreateEndpoint_ShouldReturn_CreatedStatusCode()
        {
            // Arrange
            var requestUrl = "/api/Hobby";
            var hobby = new Hobby { Title = "Test", ImageSrc = "1", Description = "" };

            // Act
            var response = await _client.PostAsJsonAsync(requestUrl, hobby);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Test]
        public async Task UpdateEndpoint_ShouldReturn_OkStatusCode()
        {
            // Arrange
            var requestUrl = "/api/Hobby/6002";
            var hobbyPatch = new JsonPatchDocument<Hobby>().Replace(h => h.Title, "Changed");

            var jsonPatch = JsonSerializer.Serialize(hobbyPatch);
            var content = new StringContent(jsonPatch, System.Text.Encoding.UTF8, "application/json-patch+json");

            // Act
            var response = await _client.PatchAsync(requestUrl, content);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var updatedHobby = await _client.GetFromJsonAsync<Hobby>("/api/Hobby/6002");
            updatedHobby.Title.Should().Be("Changed");
        }

        [Test]
        public async Task DeleteEndpoint_ShouldReturn_OkStatusCode()
        {
            // Arrange
            var requestUrl = "/api/Hobby/6002";

            // Act
            var response = await _client.DeleteAsync(requestUrl);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
