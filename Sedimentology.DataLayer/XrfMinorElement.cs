﻿using System;

 namespace Sedimentology.DataLayer
{
    public class XrfMinorElement
    {
        public Guid Id { get; set; }
        public string MinorElement { get; set; }
        public decimal Amount { get; set; }
        public virtual SampleOverview Sample { get; set; }
    }
    
} 