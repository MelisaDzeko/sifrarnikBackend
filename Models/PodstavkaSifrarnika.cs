using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace optomŠifrarnik.Models
{
    public class PodstavkaSifrarnika
    {
        [Key]
        public int PodstavkaSifrarnikaId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Oznaka { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Preduzece { get; set; }

        public int RedniBroj { get; set; }

        public DateTime DatumKreiranja { get; set; }

        [ForeignKey(nameof(StavkaSifrarnika))]
        public int StavkaSifrarnikaId { get; set; }



        public PodstavkaSifrarnika() { }
    }
}
