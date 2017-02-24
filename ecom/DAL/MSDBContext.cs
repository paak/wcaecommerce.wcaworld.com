using ecom.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace ECM.DAL
{
    public class MSDBContext : DbContext
    {
        public MSDBContext()
            : base("MSDBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        /* Master data */
        public DbSet<Network> Networks { get; set; }

        /* Ecom Master data */
        public DbSet<EcomCert_AvgPackageWeight> EcomCert_AvgPackageWeights { get; set; }
        public DbSet<EcomCert_Product> EcomCert_Products { get; set; }

        public DbSet<EcomCert_Service_Master> EcomCert_Service_Master { get; set; }
        public DbSet<EcomCert_CrossBorder> EcomCert_CrossBorders { get; set; }
        public DbSet<EcomCert_GroundService> EcomCert_GroundServices { get; set; }
        public DbSet<EcomCert_TransportFleet> EcomCert_TransportFleets { get; set; }
        public DbSet<EcomCert_GeoCoverage> EcomCert_GeoCoverages { get; set; }
        public DbSet<EcomCert_PaymentType> EcomCert_PaymentTypes { get; set; }
        public DbSet<EcomCert_InternalBound> EcomCert_InternalBounds { get; set; }


        //public DbSet<Country> Countries { get; set; }
        //public DbSet<CityState> States { get; set; }
        //public DbSet<License> Licenses { get; set; }

        public DbSet<ViewMember> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}