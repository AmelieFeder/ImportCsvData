using System.Collections.Generic;
using System.Globalization;
using Sedimentology.DataLayer;

namespace ImportCsvData.Converter
{
    public class PetrographyConverter : IMapConverter<Petrography>
    {
        public Petrography Convert(KeyValuePair<string, string> map, SampleOverview sampleOverview)
        {
            Petrography petrography = new Petrography();
            petrography.Sample = sampleOverview;
            petrography.Mineral = map.Key;
            string amount = string.IsNullOrEmpty(map.Value) ? "0.0" : map.Value;
            petrography.Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);

            return petrography;
        }
    } 
}
