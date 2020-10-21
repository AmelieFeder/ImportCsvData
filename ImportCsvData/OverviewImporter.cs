using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sedimentology.DataLayer;
using StatistikSpielereien;

namespace ImportCsvData
{
    public class OverviewImporter
    {
        public void ImportOverview(string[] headerNames, string filePath )
        {
            CsvToDictionaryLoader loader = new CsvToDictionaryLoader(headerNames);
            string csvFile = File.ReadAllText(@filePath);
            List<Dictionary<string, string>> overviews = loader.LoadToDictionary(csvFile);
            
            using (var context = new SossusvleiSedimentologyContext())
            {
                string idHeader = overviews.First().Keys.First();
                
                foreach (var sample in overviews)
                {
                    SampleOverview databaseEntry = new SampleOverview();
                    databaseEntry.SampleName = sample["SampleName"];
                    databaseEntry.Latitude = sample["Latitude"].Substring(0, sample["Latitude"].Length - 1);
                    databaseEntry.Longitude = sample["Longitude"].Substring(0, sample["Longitude"].Length - 1);
                    databaseEntry.Section = sample["Section"];
                    databaseEntry.Facies = sample["Facies"];

                    context.SampleOverview.Add(databaseEntry);
                    
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        e.HandleSaveChangesSqlException(idHeader);
                    } 
                }
            }
        }
    }
}
