using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRart.Data.Art
{
    public class ArtContext : DbContext
    {
        public ArtContext() 
            : base("DefaultConnection")
        {
            //Lazy loading will attempt to recreate the entire object with each request. Expensive for REST API so disable.
            this.Configuration.LazyLoadingEnabled = false;
            //can cause problems with serialization
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ArtContext, Migrations.ArtMigrationConfiguration>()
                );
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Upload> Uploads { get; set; }
    }
}
