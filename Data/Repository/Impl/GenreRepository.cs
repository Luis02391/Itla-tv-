using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;

namespace Data.Repository.Impl
{
    public class GenreRepository : IGenreRepository
    {
        private AppDbContext context;

        public GenreRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task AddGenre(Genre genre)
        {
            context.genre.Add(genre);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await context.genre.FindAsync(id);

            context.genre.Remove(genre);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenre()
        {
            return await context.genre.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await context.genre.FindAsync(id);
        }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            return await context.genre
            .ToListAsync()
            .ContinueWith(producers => producers.Result
            .SingleOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task UpdateAsync(Genre genre)
        {
            var existe = await GetByIdAsync(genre.Id);

            if (existe != null)
            {
                existe.Name = genre.Name;
                context.genre.Update(genre);
                await context.SaveChangesAsync();
            }
        }
    }
}
