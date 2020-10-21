using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImportCsvData.Converter;
using Newtonsoft.Json;
using Sedimentology.DataLayer;

namespace ImportCsvData
{
    public class ImportManager
    {
        public void Import(CommandLineArgs args)
        {
            if (args.OverviewPath != null)
            {
                ImportOverview(args.OverviewPath);
            }

            if (args.PetrographyPath != null)
            {
                ImportWithConverter<Petrography, PetrographyConverter>("PetrographyHeaderNames.json", args.PetrographyPath);
            }

            if (args.GrainSizePath != null)
            {
                ImportWithConverter<GrainSize, GrainSizeConverter>("GrainSizeHeaderNames.json", args.GrainSizePath);
            }

            if (args.XrdMineralogyPath != null)
            {
                ImportWithConverter<XrdMineralogy, XRDConverter>("XrdHeaderNames.json", args.XrdMineralogyPath);
            }

            if (args.XrfMainElementsPath != null)
            {
                ImportWithConverter<XrfMainElement, XrfMainConverter>("XrfMainHeaderNames.json", args.XrfMainElementsPath);
            }

            if (args.XrfMinorElementsPath != null)
            {
                ImportWithConverter<XrfMinorElement, XrfMinorConverter>("XrfMinorHeaderNames.json", args.XrfMinorElementsPath);
            }
        }
        
        private void ImportOverview(string filePath)
        {
            string [] headerNames = Load<String>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HeaderNames", "SampleOverviewHeaderNames.json")).ToArray();
            
            var importer = new OverviewImporter();
            importer.ImportOverview(headerNames, filePath);
            
            Console.WriteLine("Data successfully imported!");
        }

        private void ImportWithConverter<TSedimentologicalData, TMapConverter>(string headerFileName, string filePath)
        where TSedimentologicalData : class
        where TMapConverter : IMapConverter<TSedimentologicalData>, new()
        {
            string[] headerNames = Load<String>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HeaderNames", headerFileName)).ToArray();
            
            var converter = new TMapConverter();
            var importer = new SedimentologicalDataImporter<TSedimentologicalData>(filePath, headerNames, converter);
            
            importer.Import();
            Console.WriteLine("Data successfully imported!");
        }
        
        private static IEnumerable<String> Load<String>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            IEnumerable<String> stringEnumerable = JsonConvert.DeserializeObject<IEnumerable<String>>(json);
            return stringEnumerable;
        }
    }
}