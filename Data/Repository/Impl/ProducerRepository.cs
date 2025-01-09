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
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext context;

        public ProducerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddProducer(Producer producer)
        {
            context.producer.Add(producer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producer = await context.producer.FindAsync(id);

            context.producer.Remove(producer);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllProducer()
        {
            return await context.producer.ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await context.producer.FindAsync(id);
        }

        public async Task<Producer> GetProducerByNameAsync(string name)
        {
            return await context.producer
            .ToListAsync()
            .ContinueWith(producers => producers.Result
            .SingleOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task UpdateAsync(Producer producer)
        {
            var producerExite = await context.producer.FindAsync(producer.Id);

            if (producerExite != null)
            {

                producer.Id = producerExite.Id;
                context.producer.Update(producer);
                await context.SaveChangesAsync();
            }
        }


    }
}
