using Business.Service.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Impl
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository repository;

        public ProducerService(IProducerRepository repository)
        {
            this.repository = repository;
        }

        public async Task Create(Producer producer)
        {
            await repository.AddProducer(producer);
        }

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Producer>> GetAllProducer()
        {
            return await repository.GetAllProducer();
        }

        public async Task<Producer> GetByID(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public Task<Producer> GetProducerByNameAsync(string name)
        {
            return repository.GetProducerByNameAsync(name);
        }

        public async Task Update(Producer producer)
        {
            await repository.UpdateAsync(producer);
        }
    }
}
