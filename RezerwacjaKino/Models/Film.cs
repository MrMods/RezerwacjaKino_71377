using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Models
{
    public class Film
    {
        public long IdFilm {  get; set; }
        public string Tytul { get; set; }
        public string? Opis { get; set; } = "";
        public int CzasMin { get; set; }
        public string? PosterPath { get; set; }
        public string? OmdbId { get; set; }
    }
}
