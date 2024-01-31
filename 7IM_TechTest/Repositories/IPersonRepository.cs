
namespace _7IM_TechTest.Repositories
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Searches for a person
        /// </summary>
        /// <param name="searchTerm">The search term to use. An empty search term will return an empty collection.</param>
        /// <returns>A collection containing the search results</returns>
        Task<IEnumerable<Person>?> Find(string searchTerm);

        /// <summary>
        /// Gets a collection of all <see cref="Person"/> objects in the data store
        /// </summary>
        /// <returns>A collection of all the <see cref="Person"/> objects.</returns>
        Task<IEnumerable<Person>?> GetAll();
    }
}