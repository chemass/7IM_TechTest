using _7IM_TechTest.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace _7IM_IntegrationTests
{
    public class BasicTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        [Theory]
        [InlineData("James", 2)]
        [InlineData("jam", 3)]
        [InlineData("Katey Soltan", 1)]
        [InlineData("Arthur Dent", 0)]
        public async Task SearchReturnsOkWithResults(string searchTerm, int expectedResultCount)
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/search/{searchTerm}");
            var results = await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
            Assert.Equal(expectedResultCount, results?.Count());
        }

        [Fact]
        public async Task SearchReturnsBadRequestOnEmptyInput()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/search/     /");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
