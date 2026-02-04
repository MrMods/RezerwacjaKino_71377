using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Models
{
    public class Sala
    {
        public long IdSala { get; set; }
        public string Nazwa { get; set; } = "";
        public int LiczbaRzedow {  get; set; }
        public int MiejscaWRzedzie {  get; set; }
    }
}
