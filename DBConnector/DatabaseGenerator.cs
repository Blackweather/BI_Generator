using DBConnector.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DBConnector
{
    public class DatabaseGenerator {

        private Random _generator = new Random();
        private readonly char _csvIndicator = ';';
        private readonly char _bulkIndicator = ';';
        private readonly NextId _idsDictionary = new NextId();
        private string _rootDirectory;
        private int _dataCount;
        private DateTime _t0Period = new DateTime(2008, 1, 1);
        private DateTime _t1Period = new DateTime(2018, 11, 1);
        private DateTime _t2Period = DateTime.Now;

        private IList<Stanowisko> StanowiskoTable = new List<Stanowisko>();
        private IList<Gatunek> GatunekTable = new List<Gatunek>();
        private IList<Weterynarz> WeterynarzTable = new List<Weterynarz>();
        private IList<TypZdarzenia> TypZdarzeniaTable = new List<TypZdarzenia>();
        private IList<Pracownik> PracownikTable = new List<Pracownik>();
        private IList<Zwierze> ZwierzeTable = new List<Zwierze>();
        private IList<Wizyta> WizytaTable = new List<Wizyta>();
        private IList<Zdarzenie> ZdarzenieTable = new List<Zdarzenie>();
        private IList<ZdarzeniePracownik> ZdarzeniePracownikTable = new List<ZdarzeniePracownik>();

        //%
        private double probabilityOfZgon = 10;

        public DatabaseGenerator(string rootDirectory, int dataCount)
        {
            _rootDirectory = rootDirectory;
            _dataCount = dataCount;
        }

        public void Start()
        {
            try
            {
                Directory.CreateDirectory(_rootDirectory + "\\Output");
                GenerateStanowisko();
                GenerateGatunek();
                GenerateTypZdarzenia();
                GenerateWeterynarz();
                GeneratePracownik();
                GenerateZwierze();
                GenerateWizyta();
                GenerateZdarzenie();
                GenerateZdarzeniePracownik();

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void GenerateStanowisko()
        {
            string currentTable = "Stanowisko";
            var reader = new StreamReader(_rootDirectory + "\\Input\\" + currentTable + ".csv");
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
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
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
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
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
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
                        IdStanowiska = _generator.Next(StanowiskoTable.Count) + 1
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
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
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
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
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
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
            for (int i = 0; i < _dataCount/10; i++)
            {
                var id = _idsDictionary.GetNextId(currentTable);
                if (id != null)
                {
                    var randomizedGatunek = GatunekTable[_generator.Next(GatunekTable.Count)];
                    var newObject = new Zwierze
                    {
                        IdZwierzecia = id.Value,
                        DataZgonu = _generator.Next(100) < probabilityOfZgon ? GetRandomDate() : (DateTime?)null,
                        IdGatunku = randomizedGatunek.IdGatunku,
                        Opis = "Jest to zwierzę o gatunku " + randomizedGatunek.Opis + "."
                    };

                    ZwierzeTable.Add(newObject);
                    writer.WriteLine(newObject.ToString(_bulkIndicator));

                }

            }
            writer.Close();
        }

        private void GenerateWizyta()
        {
            string currentTable = "Wizyta";
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);

            var startDate = _t0Period;
            var hour = new TimeSpan(8, 0, 0);
            var currentDate = startDate.Date + hour;
            //wizyty cykliczne
            while (currentDate <= DateTime.Now)
            {
                foreach (var zwierze in ZwierzeTable)
                {
                    if (currentDate >= zwierze.DataZgonu)
                    {
                        continue;
                    }

                    var newObject = new Wizyta
                    {
                        Czas = currentDate,
                        IdWeterynarza = WeterynarzTable[_generator.Next(WeterynarzTable.Count)].IdWeterynarza,
                        IdZwierzecia = zwierze.IdZwierzecia,
                        Koszt = _generator.Next(500) + 100,
                        Opis = "Wizyta kontrolna, cykliczna."
                    };
                    currentDate = currentDate.AddMinutes(10);
                    WizytaTable.Add(newObject);
                }

                currentDate = currentDate.AddDays(10);
            }


            //wizyty nagle
            foreach(var zwierze in ZwierzeTable)
            {
                for (int i = 0; i < 2; i++)
                {
                    var randomDateTime = GetRandomDate();
                    if (zwierze.DataZgonu != null && randomDateTime >= zwierze.DataZgonu.Value)
                    {
                        randomDateTime = zwierze.DataZgonu.Value.AddDays(-1) + new TimeSpan(9, 0, 0);
                    }
                    var newRecord = new Wizyta
                    {
                        IdWeterynarza = _generator.Next(WeterynarzTable.Count) + 1,
                        IdZwierzecia = zwierze.IdZwierzecia,
                        Czas = randomDateTime,
                        Koszt = _generator.Next(800) + 100,
                        Opis = "Wizyta nagła! Szczególnie dbać o zwierzę w następnych dniach!"
                    };

                    WizytaTable.Add(newRecord);
                }
            }
            WizytaTable = WizytaTable.OrderBy(x => x.Czas).ToList();
            foreach(var wizyta in WizytaTable)
            {
                wizyta.IdWizyty = _idsDictionary.GetNextId(currentTable).Value;
                writer.WriteLine(wizyta.ToString(_bulkIndicator));
            }
            writer.Close();

        }

        private void GenerateZdarzenie()
        {
            var currentDate = _t0Period;
            while (currentDate <= _t1Period)
            {
                foreach(var zwierze in ZwierzeTable)
                {
                    var randomHours = _generator.Next(8) + 8;
                    var randomMinutes = _generator.Next(60);
                    var sprzatanieId = TypZdarzeniaTable.FirstOrDefault(x => x.Opis == "Sprzątanie").IdTypuZdarzenia;
                    var newRecord = new Zdarzenie
                    {
                        IdTypuZdarzenia = sprzatanieId,
                        Czas = currentDate + new TimeSpan(randomHours, randomMinutes, 0),
                        IdZwierzecia = zwierze.IdZwierzecia
                    };

                    ZdarzenieTable.Add(newRecord);

                }

                currentDate = currentDate.AddDays(3);
               
            }

            currentDate = _t0Period;
            while (currentDate <= _t1Period)
            {
                foreach (var zwierze in ZwierzeTable)
                {
                    var randomHours = _generator.Next(8) + 8;
                    var randomMinutes = _generator.Next(60);
                    var karmienieId = TypZdarzeniaTable.FirstOrDefault(x => x.Opis == "Karmienie").IdTypuZdarzenia;
                    var newRecord = new Zdarzenie
                    {
                        IdTypuZdarzenia = karmienieId,
                        Czas = currentDate + new TimeSpan(randomHours, randomMinutes, 0),
                        IdZwierzecia = zwierze.IdZwierzecia
                    };

                    ZdarzenieTable.Add(newRecord);

                }

                currentDate = currentDate.AddDays(1);

            }

            currentDate = _t0Period;
            while (currentDate <= _t1Period)
            {
                foreach (var zwierze in ZwierzeTable)
                {
                    var randomHours = _generator.Next(8) + 8;
                    var randomMinutes = _generator.Next(60);
                    var kontrolaId = TypZdarzeniaTable.FirstOrDefault(x => x.Opis == "Kontrola").IdTypuZdarzenia;
                    var newRecord = new Zdarzenie
                    {
                        IdTypuZdarzenia = kontrolaId,
                        Czas = currentDate + new TimeSpan(randomHours, randomMinutes, 0),
                        IdZwierzecia = zwierze.IdZwierzecia
                    };

                    ZdarzenieTable.Add(newRecord);

                }

                currentDate = currentDate.AddDays(4);
            }

            ZdarzenieTable = ZdarzenieTable.OrderBy(x => x.Czas).ToList();
            var currentTable = "Zdarzenie";
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
            foreach (var zdarzenie in ZdarzenieTable)
            {
                zdarzenie.IdZdarzenia = _idsDictionary.GetNextId(currentTable).Value;
                writer.WriteLine(zdarzenie.ToString(_bulkIndicator));
            }

            writer.Close();
        }

        private void GenerateZdarzeniePracownik()
        {
            var sprzatanieId = TypZdarzeniaTable.First(x => x.Opis == "Sprzątanie").IdTypuZdarzenia;
            var karmienieId = TypZdarzeniaTable.First(x => x.Opis == "Karmienie").IdTypuZdarzenia;
            var kontrolaId = TypZdarzeniaTable.First(x => x.Opis == "Kontrola").IdTypuZdarzenia;

            var sprzatanieList = ZdarzenieTable.Where(x => x.IdTypuZdarzenia == sprzatanieId);
          
            foreach(var sprzatanie in sprzatanieList)
            {
                var busy = new List<int>();
                for (int i = 0; i < 2; i++)
                {
                    int randomizedPracownikId = PracownikTable[_generator.Next(PracownikTable.Count)].IdPracownika;
                    while (busy.Contains(randomizedPracownikId))
                    {
                        randomizedPracownikId = PracownikTable[_generator.Next(PracownikTable.Count)].IdPracownika;
                    };
                    var newRecord = new ZdarzeniePracownik
                    {
                        IdPracownika = randomizedPracownikId,
                        IdZdarzenia = sprzatanie.IdZdarzenia
                    };

                    busy.Add(randomizedPracownikId);

                    ZdarzeniePracownikTable.Add(newRecord);
                }
                
            }

            var karmienieList = ZdarzenieTable.Where(x => x.IdTypuZdarzenia == karmienieId);
            foreach(var karmienie in karmienieList)
            {
                var randomizedPracownikId = PracownikTable[_generator.Next(PracownikTable.Count)].IdPracownika;
                var newRecord = new ZdarzeniePracownik
                {
                    IdPracownika = randomizedPracownikId,
                    IdZdarzenia = karmienie.IdZdarzenia
                };

                ZdarzeniePracownikTable.Add(newRecord);

            }

            var kontrolaList = ZdarzenieTable.Where(x => x.IdTypuZdarzenia == kontrolaId);
            foreach (var kontrola in kontrolaList)
            {
                var randomizedPracownikId = PracownikTable[_generator.Next(PracownikTable.Count)].IdPracownika;
                var newRecord = new ZdarzeniePracownik
                {
                    IdPracownika = randomizedPracownikId,
                    IdZdarzenia = kontrola.IdZdarzenia
                };

                ZdarzeniePracownikTable.Add(newRecord);

            }

            var currentTable = "ZdarzeniePracownik";
            var outputFilePath = (_rootDirectory + "\\Output\\" + currentTable + ".bulk");
            File.Create(outputFilePath).Close();
            var writer = new StreamWriter(File.Open(outputFilePath, FileMode.Open), System.Text.Encoding.Unicode);
            foreach (var zdarzeniePracownik in ZdarzeniePracownikTable)
            {
                writer.WriteLine(zdarzeniePracownik.ToString(_bulkIndicator));
            }

            writer.Close();
        }


        private DateTime GetRandomDate(DateTime start, DateTime end)
        {
            if (end < start)
            {
                var tmp = start;
                start = end;
                end = start;
            }
            int range = (end - start).Days;
            return start.AddDays(_generator.Next(range));
        }
        private DateTime GetRandomDate()
        {
            return GetRandomDate(_t0Period, _t1Period);
        }

    }
}
