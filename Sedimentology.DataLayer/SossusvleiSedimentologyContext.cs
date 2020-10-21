using System;
using Microsoft.EntityFrameworkCore;
using Sedimentology.DataLayer;


namespace Sedimentology.DataLayer
{
    public class SossusvleiSedimentologyContext : DbContext
    {
        private readonly string _databaseString =
            "Server=localhost;Database=Sossusvlei_Sedimentology;User Id=sa;Password=SuperSecretPassword123!";

        public SossusvleiSedimentologyContext()
        {

        }

        public SossusvleiSedimentologyContext(string databaseString)
        {
            _databaseString = databaseString;
        }

        public DbSet<Petrography> Petrography { get; set; }
        public DbSet<SampleOverview> SampleOverview { get; set; }
        public DbSet<XrdMineralogy> XrdMineralogy { get; set; }
        public DbSet<XrfMainElement> XrfMainElement { get; set; }
        public DbSet<XrfMinorElement> XrfMinorElement { get; set; }
        public DbSet<GrainSize> GrainSize { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_databaseString);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}