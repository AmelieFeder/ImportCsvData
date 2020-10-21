using System;

namespace Sedimentology.DataLayer
{
    public class SampleOverview
    {
        public Guid Id { get; set; }
        public string SampleName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Facies { get; set; }
        public string Section { get; set; }
    }
} 