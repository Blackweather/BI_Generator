using DBConnector.Model;
using System;
using System.Collections.Generic;
using System.IO;


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


        //%
        private double probabilityOfZgon = 10;

        public DatabaseGenerator(string rootDirectory)
        {
            _rootDirectory = rootDirectory;
            try
            {
                GenerateStanowisko();
                GenerateGatunek();
                GenerateTypZdarzenia();
                GenerateWeterynarz();
                GeneratePracownik();
                GenerateZwierze();

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















        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(GENERATOR.Next(range));
        }
    }
}
