using System.Collections.Generic;
using System.Globalization;
using Sedimentology.DataLayer;

namespace ImportCsvData.Converter
{
    public class XRDConverter : IMapConverter<XrdMineralogy>
    {
        public XrdMineralogy Convert(KeyValuePair<string, string> map, SampleOverview sampleOverview)
        {
            XrdMineralogy xrdMineralogy = new XrdMineralogy();
            xrdMineralogy.Sample = sampleOverview;
            xrdMineralogy.Mineral = map.Key;
            string amount = string.IsNullOrEmpty(map.Value) ? "0.0" : map.Value;
            xrdMineralogy.Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);

            return xrdMineralogy;
        }
    }
}