using Business.Service.Interfaces;
using Data.Entities;
using Data.Repository.Impl;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Impl
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository repository;

        public SerieService(ISerieRepository repository)
        {
            this.repository = repository;
        }

        public async Task Create(Serie serie)
        {
            await repository.AddSerie(serie);
        }

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Serie>> GetAllSerie()
        {
            return await repository.GetAllSerie();

        }

        public async Task<Serie> GetByID(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task Update(Serie serie)
        {
            await repository.UpdateAsync(serie);
        }

        public async Task<List<Serie>> GetAllSeriesByFilter(int? producerId, int? genreId, string? searchText)
        {
            return await repository.GetAllSerieAFiltro(producerId, genreId, searchText);
        }
    }
}
