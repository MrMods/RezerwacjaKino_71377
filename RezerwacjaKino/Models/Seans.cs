using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Models
{
    public class Seans
    {
        public long IdSeans { get; set; }
        public long FkIdFilm { get; set; }
        public long FkIdSala { get; set; }
        public DateTime StartOd {  get; set; }
        public decimal CenaPodstawowa { get; set; }

        //UI
        public string FilmTytul { get; set; } = "";
        public string? PosterPath { get; set; }
        public string SalaNazwa { get; set; } = "";
        public string? Ograniczenia { get; set; } = "";
        public int SalaRzedow {  get; set; }
        public int SalaMiejsc { get; set; }
    }
}
