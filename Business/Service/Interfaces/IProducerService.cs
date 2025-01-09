using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IProducerService
    {
        public Task<IEnumerable<Producer>> GetAllProducer();
        Task Create(Producer producer);
        Task<Producer> GetByID(int id);
        Task Update(Producer producer);
        Task Delete(int id);
        Task<Producer> GetProducerByNameAsync(string name);
    }
}
