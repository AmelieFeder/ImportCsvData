﻿using System;

 namespace Sedimentology.DataLayer
{
    public class Petrography
    {
        public Guid Id { get; set; }
        public string Mineral { get; set; }
        public decimal Amount { get; set; }
        public virtual SampleOverview Sample { get; set; }
    }
} 