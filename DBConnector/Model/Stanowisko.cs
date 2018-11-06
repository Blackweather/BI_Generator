using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class Stanowisko
    {
        public int IdStanowiska { get; set; }
        public string Opis { get; set; }

        public String ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), new string[] { IdStanowiska.ToString(), Opis });
        }
    }
}
