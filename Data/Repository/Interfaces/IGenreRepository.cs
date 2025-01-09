using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenreByNameAsync(string name);
        Task<IEnumerable<Genre>> GetAllGenre();
        Task AddGenre(Genre genre);
        Task<Genre> GetByIdAsync(int id);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(int id);
    }
}
