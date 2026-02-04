using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Models
{
    public class Bilet
    {
        public long IdBilet { get; set; }
        public long FkIdSeans { get; set; }
        public long FkIdKlient { get; set; }
        public int Rzad {  get; set; }
        public int Numer {  get; set; }
        public string TypBiletu { get; set; } = "Normalny";
        public decimal Cena { get; set; }
        public string Status { get; set; } = "Aktywny";
        public DateTime StworzoneO {  get; set; }
    }
}
