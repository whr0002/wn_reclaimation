using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WN_Reclaimation.Models
{
    public class Reclaimation_Context : DbContext
    {
        public Reclaimation_Context() : base("Reclaimation_Context") { }

        public DbSet<DesktopReview> DestopReviews { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}