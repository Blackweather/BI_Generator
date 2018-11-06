using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class Weterynarz
    {
        public int IdWeterynarza { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerTelefonu { get; set; }

        public String ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), new string[] { IdWeterynarza.ToString(), Imie, Nazwisko, NumerTelefonu });
        }
    }
}
