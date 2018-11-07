using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class Zdarzenie
    {
        public int IdZdarzenia { get; set; }
        //FK
        public int IdTypuZdarzenia { get; set; }
        //FK
        public int IdZwierzecia { get; set; }
        public DateTime Czas { get; set; }

        public string ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), IdZdarzenia.ToString(), IdTypuZdarzenia.ToString(), IdZwierzecia.ToString(), Czas.ToString());
        }
    }
}
