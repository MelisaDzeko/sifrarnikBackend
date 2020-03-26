using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace optomŠifrarnik.Models
{
    public class Sifrarnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SifrarnikId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Oznaka { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Opis { get; set; }

        public bool Programerski { get; set; }

        public bool Kesiranje { get; set; }

        public DateTime DatumKreiranja { get; set; }



        public Sifrarnik() { }
    }
}
