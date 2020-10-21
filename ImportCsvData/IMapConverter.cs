using System.Collections.Generic;
using Sedimentology.DataLayer;

namespace ImportCsvData
{
    public interface IMapConverter<TSedimentologicalData>
    where TSedimentologicalData : class
    {
        public TSedimentologicalData Convert(KeyValuePair<string,string> map, SampleOverview sampleOverview);
    }
}