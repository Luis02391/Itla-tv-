using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Serie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la serie es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La imagen de portada es obligatoria")]
        public string CoverImage { get; set; }

        [Required(ErrorMessage = "El enlace del video de la serie es obligatorio")]
        public string VideoLink { get; set; }


        // Relaciones

        [Required(ErrorMessage = "La productora es obligatoria")]
        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        [Required(ErrorMessage = "El género primario es obligatorio")]
        public int PrimaryGenreId { get; set; }

        [ForeignKey("PrimaryGenreId")]
        public Genre PrimaryGenre { get; set; }

        public int? SecondaryGenreId { get; set; }

        [ForeignKey("SecondaryGenreId")]
        public Genre SecondaryGenre { get; set; }
    }
}
