﻿using System;

 namespace Sedimentology.DataLayer
{
    public class XrfMainElement
    {
        public Guid Id { get; set; }
        public string MajorElement { get; set; }
        public decimal Amount { get; set; }
        public virtual SampleOverview Sample { get; set; }
    }
    
}