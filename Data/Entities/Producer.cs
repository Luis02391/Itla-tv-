using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Producer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la productora es obligatorio")]
        public string Name { get; set; }

        // Relación: una productora tiene muchas series
        public ICollection<Serie> Series { get; set; }
    }
}
