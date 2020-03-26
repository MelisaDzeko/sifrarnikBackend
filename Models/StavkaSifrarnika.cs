using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace optomŠifrarnik.Models
{
    public class StavkaSifrarnika
    {
        [Key]
        public int StavkaSifrarnikaId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Oznaka { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Preduzece { get; set; }

        public int RedniBroj { get; set; }

        public DateTime DatumKreiranja { get; set; }

        [ForeignKey(nameof(Sifrarnik))]
        public int SifrarnikId { get; set; }



        public StavkaSifrarnika() { }
    }
}
