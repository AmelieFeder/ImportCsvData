using System.Collections.Generic;
using System.Globalization;
using Sedimentology.DataLayer;

namespace ImportCsvData.Converter
{
    public class XrfMainConverter : IMapConverter<XrfMainElement>
    {
        public XrfMainElement Convert(KeyValuePair<string, string> map, SampleOverview sampleOverview)
        {
            XrfMainElement xrfMainElement = new XrfMainElement();
            xrfMainElement.Sample = sampleOverview;
            xrfMainElement.MajorElement = map.Key;
            string amount = string.IsNullOrEmpty(map.Value) ? "0.0" : map.Value;
            xrfMainElement.Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);

            return xrfMainElement;
        }
    }
}