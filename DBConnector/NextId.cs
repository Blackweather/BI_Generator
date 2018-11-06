using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector
{
    public class NextId
    {
        private IDictionary<string, int> _idsDictionary = new Dictionary<string, int>()
        {
            {"Stanowisko", 1 },
            {"Gatunek", 1 },
            {"Weterynarz", 1 },
            {"TypZdarzenia", 1 },
            {"Zwierze", 1 },
            {"Pracownik", 1},
            {"Wizyta", 1 },
            {"Zdarzenie", 1 }


        };

        public int? GetNextId(string tableName)
        {
            int id;
            if (_idsDictionary.TryGetValue(tableName, out id))
            {
                _idsDictionary[tableName]++;
                return id;
            }
            return null;
        }

    }
}
