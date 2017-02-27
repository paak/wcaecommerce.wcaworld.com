using ecom.Models;
using ecom.Models.MSDB;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        // Main tables
        public DbSet<EcomCert> EcomCerts { get; set; }
        public DbSet<EcomCert_Status> EcomCert_Status { get; set; }

        // Company Details
        public DbSet<EcomCert_CompDetail> EcomCert_CompDetail { get; set; }
        public DbSet<EcomCert_Product_Handled> EcomCert_Product_Handled { get; set; }

        //Services
        public DbSet<EcomCert_Service> EcomCert_Service { get; set; }
        public DbSet<EcomCert_Service_Provide> EcomCert_Service_Provide { get; set; }
        public DbSet<EcomCert_Service_CrossBorder> EcomCert_Service_CrossBorder { get; set; }
        public DbSet<EcomCert_Service_Ground> EcomCert_Service_Ground { get; set; }
        public DbSet<EcomCert_Service_TransportFleet> EcomCert_Service_TransportFleet { get; set; }
        public DbSet<EcomCert_Service_PayOnDelivery> EcomCert_Service_PayOnDelivery { get; set; }
        public DbSet<EcomCert_Service_InternalBound> EcomCert_Service_InternalBound { get; set; }
        public DbSet<EcomCert_Service_GeoCoverage> EcomCert_Service_GeoCoverage { get; set; }

        // IT System
        public DbSet<EcomCert_IT> EcomCert_IT { get; set; }

        // MSDB
        public DbSet<ViewMember> Members { get; set; }
        public DbSet<SalesRep> SalesRep { get; set; }
        public DbSet<ViewContact> ViewContacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}