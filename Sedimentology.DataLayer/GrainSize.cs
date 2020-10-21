using System;

namespace Sedimentology.DataLayer
{
    public class GrainSize
    {
        public Guid Id { get; set; }
        public decimal Size { get; set; }
        public decimal WeightPercent { get; set; }
        public virtual SampleOverview Sample { get; set; }
    }
}