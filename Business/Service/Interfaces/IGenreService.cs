
using Data.Entities;

namespace Business.Service.Interfaces
{
    public interface IGenreService
    {
        public Task<IEnumerable<Genre>> GetAllGenres();
        Task Create(Genre genre);
        Task<Genre> GetByID(int id);
        Task Update(Genre genre);
        Task Delete(int id);
        Task<Genre> GetGenreByNameAsync(string name);
    }
}
