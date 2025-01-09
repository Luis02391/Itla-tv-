using Data.Context;
using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Impl
{
    public class SerieRepository : ISerieRepository
    {
        private readonly AppDbContext context;

        public SerieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddSerie(Serie serie)
        {
            context.series.Add(serie);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var serie = await context.series.FindAsync(id);

            context.series.Remove(serie);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Serie>> GetAllSerie()
        {
            return await context.series.ToListAsync();
        }

        public async Task<List<Serie>> GetAllSerieAFiltro(int? producerId = null, int? genreId = null, string? searchText = null)
        {
            var query = context.series.AsQueryable();

            if (producerId.HasValue)
            {
                query = query.Where(s => s.ProducerId == producerId.Value);
            }

            if (genreId.HasValue)
            {
                query = query.Where(s => s.PrimaryGenreId == genreId.Value || s.SecondaryGenreId == genreId.Value);
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(s => s.Name.Contains(searchText.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<Serie> GetByIdAsync(int id)
        {
            return await context.series.FindAsync(id);
        }

        public async Task UpdateAsync(Serie serie)
        {
            var serieExiste = await context.series.FindAsync(serie.Id);

            if (serieExiste != null)
            {
                serie.Id = serieExiste.Id;
                context.series.Update(serie);
                await context.SaveChangesAsync();
            }
        }
    }
}
