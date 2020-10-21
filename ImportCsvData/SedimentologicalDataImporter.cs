using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using Sedimentology.DataLayer;
using StatistikSpielereien;
namespace ImportCsvData
{
    public class SedimentologicalDataImporter<TSedimentologicalData>
    where TSedimentologicalData : class
    {
        private readonly string _filePath;
        private readonly string[] _headerNames;
        private readonly IMapConverter<TSedimentologicalData> _mapConverter;

        public SedimentologicalDataImporter(string filePath, string[] headerNames, IMapConverter<TSedimentologicalData> mapConverter)
        {
            _filePath = filePath;
            _headerNames = headerNames;
            _mapConverter = mapConverter;
        }

        public void Import()
        {
            CsvToDictionaryLoader loader = new CsvToDictionaryLoader(_headerNames);
            string csvFile = File.ReadAllText(_filePath);
            List<Dictionary<string, string>> maps = loader.LoadToDictionary(csvFile);

            using (var context = new SossusvleiSedimentologyContext())
            {
                string idHeader = maps.First().Keys.First();
                
                foreach (var map in maps)
                {
                    string sampleName = map[idHeader];
                    SampleOverview overview = context.SampleOverview.First(s => s.SampleName == sampleName);
                    
                    if (overview is null)
                    {
                        Console.WriteLine($"Missing overview for sample '{sampleName}'. Skipping data import.");
                        
                        continue;
                    }
                    
                    var filteredMap = map.Where(m => m.Key != idHeader);

                    foreach (var item in filteredMap)
                    {
                        TSedimentologicalData data = _mapConverter.Convert(item, overview);
                        context.Set<TSedimentologicalData>().Add(data);

                        try
                        {
                            context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                           e.HandleSaveChangesSqlException(map[idHeader]);
                        }
                    }
                }
            }
        }
    }
}