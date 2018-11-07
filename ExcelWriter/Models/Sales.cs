using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter.Models {
    class Sales {
        // excel data model for sheet 1 for ticket sales
        public DateTime Data { get; set; }
        public int Bilety { get; set; }
        public int BiletyDzieci { get; set; }
        public int BiletyDorosli { get; set; }
    }
}
