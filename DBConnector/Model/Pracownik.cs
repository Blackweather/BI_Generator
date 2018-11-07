using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class Pracownik
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        //FK
        public int IdStanowiska { get; set; }

        public string ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), new string[] { IdPracownika.ToString(), Imie, Nazwisko, IdStanowiska.ToString(), DataZatrudnienia.ToShortDateString() });
        }
    }
}
