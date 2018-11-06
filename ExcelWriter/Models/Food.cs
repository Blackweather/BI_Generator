using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter.Models {
    class Food {
        // excel data model for sheet 2 for food orders
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
