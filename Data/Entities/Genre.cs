using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del género es obligatorio")]
        public string Name { get; set; }

        public ICollection<Serie> SeriesAsPrimary { get; set; }

        public ICollection<Serie> SeriesAsSecondary { get; set; }
    }
}
