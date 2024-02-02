using _7IM_TechTest.Models;
using _7IM_TechTest.Repositories;

namespace TechTest.UnitTests
{
    public class RepositoryTests
    {
        [Fact]
        public async Task GetAllGetsAll()
        {
            PersonRepository repo = new();

            var result = await repo.GetAll();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(20, result.Count());
        }

        [Theory]
        [InlineData("James", new[] { "James Kubu", "James Pfeffer" })]
        [InlineData("jam", new[] { "James Kubu", "James Pfeffer", "Chalmers Longfut" })]
        [InlineData("Katey Soltan", new[] { "Katey Soltan" })]
        [InlineData("Jasmine Duncan", new string[0])]
        [InlineData("", new string[0])]
        public async Task TestFind(string searchTerm, string[] expected)
        {
            PersonRepository repo = new();

            var result = await repo.Find(searchTerm);

            Assert.NotNull(result);
            if (expected.Length == 0)
                Assert.Empty(result);
            else
                Assert.Collection(result, GetInspectors(expected));
        }

        private Action<Person>[] GetInspectors(string[] expected) => expected
                .Select(x => new Action<Person>(p => Assert.Equal(x, string.Concat(p.FirstName, " ", p.LastName))))
                .ToArray();
    }
}