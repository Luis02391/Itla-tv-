using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ISerieService
    {
        public Task<IEnumerable<Serie>> GetAllSerie();
        Task Create(Serie serie);
        Task<Serie> GetByID(int id);
        Task Update(Serie serie);
        Task Delete(int id);
        Task<List<Serie>> GetAllSeriesByFilter(int? producerId, int? genreId, string? searchText);
    }
}
