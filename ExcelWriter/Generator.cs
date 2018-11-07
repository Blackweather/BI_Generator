using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWriter {
    // generator for excel data
    class Generator {
        public Generator(int dataCount, string timePeriod) {
            _t2Period = DateTime.Now;
            _t1Period = new DateTime(2013, 12, 05);
            _t0Period = new DateTime(2008, 01, 01);
            foodData = new List<Models.Food>();
            salesData = new List<Models.Sales>();

            _dataCount = dataCount;
            _timePeriod = timePeriod;
        }

        public void Start() {
            if (_timePeriod.ToLower() == "t1") {
                Generate(_t0Period, _t1Period);
            }
            else {
                Generate(_t1Period, _t2Period);
            }
        }

        private void Generate(DateTime startDate, DateTime endDate) {
            int range = (endDate - startDate).Days;
            Random gen = new Random();
            for (int i = 0; i < _dataCount; i++) {
                foodData.Add(RandomFood(i, startDate, range, gen));
                salesData.Add(RandomSales(startDate, range, gen));
            }

            // sort both models by date
            foodData = foodData.OrderBy(x => x.Data).ToList();
            salesData = salesData.OrderBy(x => x.Data).ToList();
        }

        private Models.Food RandomFood(int id, DateTime startDate, int range, Random gen) {
            Models.Food food = new Models.Food();

            food.Id = id;
            food.Opis = RandomOpis(gen);
            food.Data = startDate.AddDays(gen.Next(range));
            food.Cena = gen.NextDouble() * 1400 + 100; // 100 - 1500
            food.Cena = Math.Round(food.Cena, 2);

            return food;
        }

        private Models.Sales RandomSales(DateTime startDate, int range, Random gen) {
            Models.Sales sales = new Models.Sales();

            sales.Data = startDate.AddDays(gen.Next(range));
            sales.Bilety = gen.Next(20, 3000); // 20 - 3000
            sales.BiletyDzieci = gen.Next(sales.Bilety / 2, (sales.Bilety * 10) / 15); // 50% - 66%
            sales.BiletyDorosli = sales.Bilety - sales.BiletyDzieci;
            return sales;
        }

        private string RandomOpis(Random r) {
            string[] lines = File.ReadAllLines(_inputOpisPath);
            int randomLineNumber = r.Next(0, lines.Length - 1);
            return lines[randomLineNumber];
        }

        public List<Models.Food> foodData { get; set; }
        public List<Models.Sales> salesData { get; set; }

        private DateTime _t2Period;
        private DateTime _t1Period;
        private DateTime _t0Period;

        private int _dataCount;
        private string _timePeriod;

        private const string _inputOpisPath = @"..\..\..\ExcelWriter\Input\Opis.txt";

    }
}
