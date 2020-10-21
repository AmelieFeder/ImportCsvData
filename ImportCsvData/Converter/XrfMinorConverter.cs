using System.Collections.Generic;
using System.Globalization;
using Sedimentology.DataLayer;

namespace ImportCsvData.Converter
{
    public class XrfMinorConverter : IMapConverter<XrfMinorElement>
    {
        public XrfMinorElement Convert(KeyValuePair<string, string> map, SampleOverview sampleOverview)
        {
            XrfMinorElement xrfMinorElement = new XrfMinorElement();
            xrfMinorElement.Sample = sampleOverview;
            xrfMinorElement.MinorElement = map.Key;
            string amount = string.IsNullOrEmpty(map.Value) ? "0.0" : map.Value;
            xrfMinorElement.Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);

            return xrfMinorElement;
        }
    }
}