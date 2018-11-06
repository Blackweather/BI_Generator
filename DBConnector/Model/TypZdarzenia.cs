using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector.Model
{
    public class TypZdarzenia
    {   
        public int IdTypuZdarzenia { get; set; }
        public string Opis { get; set; }

        public string ToString(char bulkIndicator)
        {
            return String.Join(bulkIndicator.ToString(), new string[] { IdTypuZdarzenia.ToString(), Opis });
        }
    }
}
