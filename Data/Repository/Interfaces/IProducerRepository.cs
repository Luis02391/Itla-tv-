using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> GetAllProducer();
        Task AddProducer(Producer producer);
        Task<Producer> GetByIdAsync(int id);
        Task UpdateAsync(Producer producer);
        Task DeleteAsync(int id);
        Task<Producer> GetProducerByNameAsync(string name);
    }
}
