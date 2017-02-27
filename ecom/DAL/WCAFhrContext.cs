using ecom.Models.WCAFhr;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECM.DAL
{
    public class WCAFhrContext : DbContext
    {
        public WCAFhrContext()
            : base("WCAFhrContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}