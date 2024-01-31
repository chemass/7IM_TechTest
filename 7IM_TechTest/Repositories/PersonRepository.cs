using System.Text.Json;

namespace _7IM_TechTest.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private Person[]? _cache;

        public async Task<IEnumerable<Person>?> GetAll() => _cache ??=
            await JsonSerializer.DeserializeAsync<Person[]?>(GetJsonStream(), GetJsonSerializerOptions(), CancellationToken.None);

        public async Task<IEnumerable<Person>?> Find(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm) ? Enumerable.Empty<Person>() :
            (await GetAll())?.Where(x => x.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            string.Concat(x.FirstName, " ", x.LastName).Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

        private static JsonSerializerOptions GetJsonSerializerOptions() => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        private static FileStream GetJsonStream() => File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Data", "data.json"));
    }
}
