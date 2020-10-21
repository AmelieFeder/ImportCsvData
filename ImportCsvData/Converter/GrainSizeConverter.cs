using System.Collections.Generic;
using System.Globalization;
using Sedimentology.DataLayer;

namespace ImportCsvData.Converter
{
    public class GrainSizeConverter : IMapConverter<GrainSize>
    {
       public GrainSize Convert(KeyValuePair<string, string> map, SampleOverview sampleOverview)
        {
            GrainSize grainSize = new GrainSize();
            grainSize.Sample = sampleOverview;
            grainSize.Size = decimal.Parse(map.Key);
            string amount = string.IsNullOrEmpty(map.Value) ? "0.0" : map.Value;
            grainSize.WeightPercent = decimal.Parse(amount, CultureInfo.InvariantCulture);

            return grainSize;
        }
    }
}