using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter {
    // handles only writing to excel
    public class ExcelWriter {
        public ExcelWriter(int dataCount, string timePeriod) {
            _generator = new Generator(dataCount, timePeriod);

            _timePeriod = timePeriod;
        }

        public void Generate() {
            _generator.Start();

            if (!Directory.Exists(@".\Generated")) {
                Directory.CreateDirectory(@".\Generated");
            }

            if (_timePeriod.ToLower() == "t1") {
                // new csv
                WriteToCsv(_t1FoodCsvPath, FileType.FOOD);
                WriteToCsv(_t1SalesCsvPath, FileType.SALES);
            }
            else {
                // append to csv
                File.Copy(_t1FoodCsvPath, _t2FoodCsvPath);
                File.Copy(_t1SalesCsvPath, _t2SalesCsvPath);
                WriteToCsv(_t2FoodCsvPath, FileType.FOOD);
                WriteToCsv(_t2SalesCsvPath, FileType.SALES);
            }
        }

        private void WriteToCsv(string path, FileType type, bool append = false) {
            using (StreamWriter sw = new StreamWriter(path, append)) {
                if (!append) {
                    sw.WriteLine("sep=;");
                }
                if (type == FileType.FOOD) {
                    if (!append) {
                        sw.WriteLine("Id;Data;Cena;Opis");
                    }
                    foreach (Models.Food food in _generator.foodData) {
                        sw.WriteLine($"{food.Id};{food.Data};{food.Cena};{food.Opis}");
                    }
                }
                else if (type == FileType.SALES) {
                    if (!append) {
                        sw.WriteLine("Data;Bilety;BiletyDzieci;BiletyDorosli");
                    }
                    foreach (Models.Sales sale in _generator.salesData) {
                        sw.WriteLine($"{sale.Data};{sale.Bilety};{sale.BiletyDzieci};{sale.BiletyDorosli}");
                    }
                }
                sw.Close();
            }
        }

        private Generator _generator;
        private string _timePeriod;

        private const string _t1FoodCsvPath = @".\Generated\t1_food.csv";
        private const string _t1SalesCsvPath = @".\Generated\t1_sales.csv";
        private const string _t2FoodCsvPath = @".\Generated\t2_food.csv";
        private const string _t2SalesCsvPath = @".\Generated\t2_sales.csv";

        private enum FileType {
            FOOD,
            SALES
        }
    }
}
