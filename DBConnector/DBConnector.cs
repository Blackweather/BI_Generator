using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnector {
    // handles all DB operations
    public class DBConnector {
        public DBConnector(int dataCount, string timePeriod) {
            _dbConnection = new DBConnection();
            _generator = new Generator();
        }

        public void Generate() {

        }

        private Generator _generator;
        private DBConnection _dbConnection;
    }
}
