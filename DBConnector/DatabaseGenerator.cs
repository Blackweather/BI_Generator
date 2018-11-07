using DBConnector.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DBConnector
{
    public class DatabaseGenerator {

        private Random GENERATOR = new Random();
        private readonly char _csvIndicator = ';';
        private readonly char _bulkIndicator = ';';
        private readonly NextId _idsDictionary = new NextId();
        private string _rootDirectory;
        public IList<Stanowisko> StanowiskoTable = new List<Stanowisko>();
        public IList<Gatunek> GatunekTable = new List<Gatunek>();
        public IList<Weterynarz> WeterynarzTable = new List<Weterynarz>();
        public IList<TypZdarzenia> TypZdarzeniaTable = new List<TypZdarzenia>();
        public IList<Pracownik> PracownikTable = new List<Pracownik>();
        public IList<Zwierze> ZwierzeTable = new List<Zwierze>();
        public IList<Wizyta> WizytaTable = new List<Wizyta>();

        //%
        private double probabilityOfZgon = 10;

        public DatabaseGenerator(string rootDirectory)
        {
            _rootDirectory = rootDirectory;
            try
            {
                Directory.CreateDirectory(rootDirectory + "\\Output");
                GenerateStanowisko();
                GenerateGatunek();
                GenerateTypZdarzenia();
                GenerateWeterynarz();
                GeneratePracownik();
                GenerateZwierze();
                GenerateWizyta();

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        private void GenerateStanowisko()
        {
            //expected: {ROOT}\Source\{TableName}.csv
            string currentTable = "Stanowisko";
            var reader = new StreamReader(_rootDirectory + "\\Input\\" + currentTable + ".csv");
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(outputFilePath) { AutoFlush = true };
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var newObject = new Stanowisko
                    {
                        IdStanowiska = id.Value,
                        Opis = line
                    };

                    StanowiskoTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));

                }

            }
            reader.Close();
            writer.Close();
        }

        private void GenerateGatunek()
        {
            string currentTable = "Gatunek";
            var reader = new StreamReader(_rootDirectory + "\\Input\\" + currentTable + ".csv");
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(outputFilePath) { AutoFlush = true };
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var columns = line.Split(_csvIndicator);
                    var newObject = new Gatunek
                    {
                        IdGatunku = id.Value,
                        Opis = line
                    };

                    GatunekTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));
                }

            }
            reader.Close();
            writer.Close();
        }

        private void GeneratePracownik()
        {
            string currentTable = "Pracownik";
            var reader = new StreamReader(_rootDirectory + "\\Input\\" + currentTable + ".csv");
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(outputFilePath) { AutoFlush = true };
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var columns = line.Split(_csvIndicator);
                    var newObject = new Pracownik
                    {
                        IdPracownika = id.Value,
                        Imie = columns[0],
                        Nazwisko = columns[1],
                        DataZatrudnienia = GetRandomDate(),
                        IdStanowiska = GENERATOR.Next(StanowiskoTable.Count) + 1
                    };

                    PracownikTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));

                }

            }
            reader.Close();
            writer.Close();
        }

        private void GenerateWeterynarz()
        {
            string currentTable = "Weterynarz";
            var reader = new StreamReader(_rootDirectory + "\\Input\\" + currentTable + ".csv");
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(outputFilePath) { AutoFlush = true };
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var columns = line.Split(_csvIndicator);
                    var newObject = new Weterynarz
                    {
                        IdWeterynarza = id.Value,
                        Imie = columns[0],
                        Nazwisko = columns[1],
                        NumerTelefonu = columns[2]
                    };

                    WeterynarzTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));

                }

            }
            reader.Close();
            writer.Close();
        }

        private void GenerateTypZdarzenia()
        {
            string currentTable = "TypZdarzenia";
            var reader = new StreamReader(_rootDirectory + "\\Input\\" + currentTable + ".csv");
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(outputFilePath) { AutoFlush = true };
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var newObject = new TypZdarzenia
                    {
                        IdTypuZdarzenia = id.Value,
                        Opis = line
                    };

                    TypZdarzeniaTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));

                }

            }
            reader.Close();
            writer.Close();
        }

        private void GenerateZwierze()
        {
            string currentTable = "Zwierze";
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(outputFilePath) { AutoFlush = true };
            for (int i = 0; i<100;i++)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var randomizedGatunek = GatunekTable[GENERATOR.Next(GatunekTable.Count)];
                    var newObject = new Zwierze
                    {
                        IdZwierzecia = id.Value,
                        DataZgonu = GENERATOR.Next(100) < probabilityOfZgon ? GetRandomDate() : (DateTime?)null,
                        IdGatunku = randomizedGatunek.IdGatunku,
                        Opis = "Jest to zwierzę o gatunku " + randomizedGatunek.Opis + "."
                    };

                    ZwierzeTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));

                }

            }
            writer.Close();
        }

        /// <summary>
        /// kurła
        /// </summary>
        private void GenerateWizyta()
        {
            //string currentTable = "Wizyta";
            //var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            //File.Create(outputFilePath).Close();
            //var writer = new StreamWriter(outputFilePath) { AutoFlush = true };

            //var startDate = ZwierzeTable.Min(x => x.DataZgonu).Value;
            //startDate = startDate.AddDays(-100);
            //var hour = new TimeSpan(8, 0, 0);
            //var currentDate = startDate.Date + hour;
            ////wizyty cykliczne
            //while (currentDate <= DateTime.Now)
            //{
            //    foreach(var zwierze in ZwierzeTable)
            //    {
            //        if (currentDate >= zwierze.DataZgonu)
            //        {
            //            continue;
            //        }

            //        var newObject = new Wizyta
            //        {
            //            Czas = currentDate,
            //            IdWeterynarza = WeterynarzTable[GENERATOR.Next(WeterynarzTable.Count)].IdWeterynarza,
            //            IdWizyty = _idsDictionary.GetNextId("Wizyta").Value,
            //            IdZwierzecia = zwierze.IdZwierzecia,
            //            Koszt = GENERATOR.Next(500) + 100,
            //            Opis = "Wizyta kontrolna, cykliczna."
            //        };
            //        currentDate = currentDate.AddMinutes(20);
            //        WizytaTable.Add(newObject);
            //    }

            //    currentDate = currentDate.AddDays(10);
            //}

            


            //for (int i = 0; i < 100; i++)
            //{
            //    var id = _idsDictionary.GetNextId(currentTable);
            //    if (id != null)
            //    {
            //        var randomizedGatunek = GatunekTable[GENERATOR.Next(GatunekTable.Count)];
            //        var newObject = new Zwierze
            //        {
            //            IdZwierzecia = id.Value,
            //            DataZgonu = GENERATOR.Next(100) < probabilityOfZgon ? GetRandomDate() : (DateTime?)null,
            //            IdGatunku = randomizedGatunek.IdGatunku,
            //            Opis = "Jest to zwierzę o gatunku " + randomizedGatunek.Opis + "."
            //        };

            //        ZwierzeTable.Add(newObject);
            //        writer.WriteLine(newObject.ToString(_bulkIndicator));

            //    }

            //}
            //writer.Close();
        }

        private void GenerateZdarzenie()
        {
            //TODO: implement
        }

        private void GenerateZdarzeniePracownik()
        {
            //TODO: implement
        }



        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(GENERATOR.Next(range));
        }
    }
}
