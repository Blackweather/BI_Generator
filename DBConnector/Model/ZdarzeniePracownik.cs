using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class ZdarzeniePracownik
    {
        //PK = (IdPracownika, IdZdarzenia)
        //FK
        public int IdPracownika { get; set; }
        //FK
        public int IdZdarzenia { get; set; }

        public string ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), IdPracownika.ToString(), IdZdarzenia.ToString());
        }
    }
}
