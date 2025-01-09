using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface ISerieRepository
    {
        Task<IEnumerable<Serie>> GetAllSerie();
        Task AddSerie(Serie serie);
        Task<Serie> GetByIdAsync(int id);
        Task UpdateAsync(Serie serie);
        Task DeleteAsync(int id);
        Task<List<Serie>> GetAllSerieAFiltro(int? producerId = null, int? genreId = null, string? searchText = null);
    }
}
