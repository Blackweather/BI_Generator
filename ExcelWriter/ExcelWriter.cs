using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter {
    // handles only writing to excel
    public class ExcelWriter {
        public ExcelWriter(int dataCount, string timePeriod) {
            _generator = new Generator();
        }

        public void Generate() {

        }

        Generator _generator;
    }
}
