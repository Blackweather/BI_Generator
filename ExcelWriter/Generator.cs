using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter {
    // generator for excel data
    class Generator {
        public Generator(int dataCount, string timePeriod) {
            

            _dataCount = dataCount;
            _timePeriod = timePeriod;
        }

        public void Generate() {
            if (_timePeriod.ToLower() == "t1") {
                GenerateT1();
            }
            else {
                GenerateT2();
            }
        }

        private void GenerateT1() {

        }

        private void GenerateT2() {

        }

        public List<Models.Food> foodData { get; set; }
        public List<Models.Sales> salesData { get; set; }

        private int _dataCount;
        private string _timePeriod;

    }
}
