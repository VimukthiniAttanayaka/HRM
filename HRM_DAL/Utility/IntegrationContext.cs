using DSSS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSS.Data
{
    public class IntegrationContext : DbContext
    {
        public IntegrationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //public DbSet<ApiVersion> ApiVersion { get; set; }
        //public DbSet<TrackingStatus> TrackingStatus { get; set; }
        //public DbSet<PickupOrder> PickupOrder { get; set; }
        //public DbSet<DSSS.Models.PostPickupOrder> PostPickupOrder { get; set; }
    }
}
