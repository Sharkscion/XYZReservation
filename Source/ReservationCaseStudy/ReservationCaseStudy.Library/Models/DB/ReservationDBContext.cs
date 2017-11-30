
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ReservationCaseStudy.Library
{ 

    public class ReservationDBContext : DbContext
    {
        public ReservationDBContext() : base("ReservationDBConn")
        {

        }

        public DbSet<Station> Stations { get; set; }

        //Note: prevents the code to generate pluralized tables
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        
    }
}
