using System;
using System.Collections.Generic;
using System.Linq;

namespace ImportCsvData
{
    public class CsvToDictionaryLoader
    {
        private readonly string _delimiter;
        private readonly string[] _headerMap;

        public CsvToDictionaryLoader(string[] headerMap, string delimiter = ";")
        {
            _headerMap = headerMap;
            _delimiter = delimiter;
        }

        public List<Dictionary<string, string>> LoadToDictionary(string csvFile)
        {
            var lines = csvFile.TrimEnd().Split(Environment.NewLine).Skip(1);
            
            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

            foreach (string line in lines)
            {
                var properties = line.Split(_delimiter);
                
                Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();

                for (int i = 0; i < properties.Length; i++)
                {
                    string propertyName = _headerMap[i];
                    
                    propertyDictionary.Add(propertyName, properties[i]);
                }
                
                rows.Add(propertyDictionary);
            }

            return rows;
        }
    }
}