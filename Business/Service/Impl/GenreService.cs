using Business.Service.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;

namespace Business.Service.Impl
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository Repository;

        public GenreService(IGenreRepository repository)
        {
            Repository = repository;
        }

        public async Task Create(Genre genre)
        {
            await Repository.AddGenre(genre);
        }

        public async Task Delete(int id)
        {
            await Repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await Repository.GetAllGenre();
        }

        public async Task<Genre> GetByID(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public Task<Genre> GetGenreByNameAsync(string name)
        {
            return Repository.GetGenreByNameAsync(name);
        }

        public async Task Update(Genre genre)
        {
            await Repository.UpdateAsync(genre);
        }
    }
}
