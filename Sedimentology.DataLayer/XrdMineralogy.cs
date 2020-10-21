using System;

namespace Sedimentology.DataLayer
{
    public class XrdMineralogy
    {
        public Guid Id { get; set; }
        public virtual SampleOverview Sample { get; set; }
        public string Mineral { get; set; }
        public decimal Amount { get; set; }
        
    }
} 