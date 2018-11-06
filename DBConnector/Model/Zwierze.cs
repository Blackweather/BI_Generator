using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class Zwierze
    {
        public int IdZwierzecia { get; set; }
        public string Opis { get; set; }
        public int IdGatunku { get; set; }
        public DateTime? DataZgonu { get; set; }

        public String ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), new string[] { IdZwierzecia.ToString(), Opis, IdGatunku.ToString(), DataZgonu == null ? "NULL" : DataZgonu.Value.ToShortDateString() });
        }
    }
}
