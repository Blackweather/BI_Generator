using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter.Models {
    class Food {
        // excel data model for sheet 2 for food orders
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }
    }
}
