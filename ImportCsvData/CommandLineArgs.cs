namespace ImportCsvData
{
    public class CommandLineArgs
    {
        public string OverviewPath { get; set; }
        public string GrainSizePath { get; set; }
        public string XrdMineralogyPath { get; set; }
        public string PetrographyPath { get; set; }
        public string XrfMainElementsPath { get; set; }
        public string XrfMinorElementsPath { get; set; }

        public bool NoPathsSet()
        {
            if (string.IsNullOrEmpty(OverviewPath) && 
                string.IsNullOrEmpty(GrainSizePath) && 
                string.IsNullOrEmpty(XrdMineralogyPath) && 
                string.IsNullOrEmpty(PetrographyPath) && 
                string.IsNullOrEmpty(XrfMainElementsPath) && 
                string.IsNullOrEmpty(XrfMinorElementsPath))
            {
                return true;
            }

            return false;
        }
    }
    
}