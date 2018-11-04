using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_Generator {
    class Program {
        public static void PrintHelp(bool isFullHelp) {
            if (isFullHelp) {
                Console.WriteLine("Generator used for generating fake data for Business Intelligence system for ZOO");
                Console.WriteLine("Made by: Karol Szczepański, Bartosz Madej\n");
            }
            else {
                Console.WriteLine("Wrong parameters specified!\n");
            }
            Console.WriteLine("Usage: BIGenerator.exe {data_model} {data_count} {time_period}\n");
            Console.WriteLine("Acceptable parameters:");
            Console.WriteLine("data_model:");
            Console.WriteLine("\t-db/--database - generate data for database");
            Console.WriteLine("\t-xls/--excel - generate data for EXCEL sheet");
            Console.WriteLine("data_count:");
            Console.WriteLine("\tany number - specifies number of data generated for specified model");
            Console.WriteLine("time_period:");
            Console.WriteLine("\tT1/T2 - specifies the time period for generating the data");
        }

        static int Main(string[] args) {
            
            // TODO: args parsing
            // -h - show help
            // first parameter - database or excel
            // second parameter - data count
            // third parameter - T1/T2
            Console.Clear();

            if (args.Length == 0) {
                PrintHelp(isFullHelp: false);
                return -1;
            }

            if (args.Length > 0 && args[0] == "-h") {
                PrintHelp(isFullHelp: true);
                return 0;
            }
            else if (args.Length > 3) {
                PrintHelp(isFullHelp: false);
                return -1;
            }
            else {
                // TODO: check args
            }

            if (args[0] == "-db" || args[0] == "--database") {
                DBConnector.DBConnector dbConnector = new DBConnector.DBConnector();
                // TODO: generate data for RDB
            }
            else if (args[0] == "-xls" || args[0] == "--excel") {
                ExcelWriter.ExcelWriter excelWriter = new ExcelWriter.ExcelWriter();
                // TODO: generate data for EXCEL sheet
            }

            return 0;
        }
    }
}
