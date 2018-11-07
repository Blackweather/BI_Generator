using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class Wizyta
    {
        public int IdWizyty { get; set; }
        //FK 
        public int IdWeterynarza { get; set; }
        //FK
        public int IdZwierzecia { get; set; }
        public float Koszt { get; set; }
        public string Opis { get; set; }
        public DateTime Czas { get; set; }

        public string ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(),
                IdWizyty.ToString(),
                IdWeterynarza.ToString(),
                IdZwierzecia.ToString(),
                Koszt.ToString(),
                Opis,
                Czas.ToShortDateString());

        }
    }
}
