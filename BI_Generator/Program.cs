using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBConnector;

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
            Console.WriteLine("\tT1/T2 - specifies the time period for generating the data (T2 not supported for database)");
        }

        public static bool CheckArgs(string[] args) {
            if (args.Length == 0) {
                PrintHelp(isFullHelp: false);
                return false;
            }

            if (args.Length > 0 && args[0] == "-h") {
                PrintHelp(isFullHelp: true);
                return false;
            }
            else if (args.Length != 3) {
                PrintHelp(isFullHelp: false);
                return false;
            }
            else {
                string[] allowedDataTypes = { "-db", "--database", "-xls", "--excel" };
                if (!allowedDataTypes.Contains(args[0])) {
                    Console.WriteLine("Data type argument is not valid!");
                    PrintHelp(isFullHelp: false);
                    return false;
                }

                if (!Regex.IsMatch(args[1], @"^\d+$")) {
                    Console.WriteLine("Second argument must be a number!");
                    PrintHelp(isFullHelp: false);
                    return false;
                }

                if (args[2].ToLower() != "t1" && args[2].ToLower() != "t2") {
                    Console.WriteLine("Time period argument is not valid!");
                    PrintHelp(isFullHelp: false);
                    return false;
                }

                if (args[2].ToLower() == "t2" && (args[0] == "-db" || args[0] == "--database")) {
                    Console.WriteLine("T2 not supported for database!");
                    PrintHelp(isFullHelp: false);
                    return false;
                }
            }
            return true;
        }

        static int Main(string[] args) {

            // arguments:
            // -h - show help
            // first parameter - database or excel
            // second parameter - data count
            // third parameter - T1/T2
            Console.Clear();

            if (!CheckArgs(args)) {
                return -1;
            }

            if (args[0] == "-db" || args[0] == "--database") {
                //for testing
                var a = new DatabaseGenerator(@".");
            }
            else if (args[0] == "-xls" || args[0] == "--excel") {
                ExcelWriter.ExcelWriter excelWriter = new ExcelWriter.ExcelWriter(int.Parse(args[1]), args[2]);
                excelWriter.Generate();
            }

            return 0;
        }
    }
}
