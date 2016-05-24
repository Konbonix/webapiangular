using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;
using VRart.Models;
using VRart.Dal;

namespace VRart.Migrations
{


    internal sealed class ArtMigrationConfiguration : DbMigrationsConfiguration<ArtContext>
    {
        public ArtMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
#if DEBUG
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
#endif
        }

        protected override void Seed(ArtContext context)
        {
            base.Seed(context);
#if DEBUG
            //if (context.Albums.Count() == 0)
            //{
            //    var album = new Album()
            //    {
            //        Title = "Tilt brush city",
            //        Description = "check out this cool small city",
            //        Created = DateTime.Now,
            //        Uploads = new List<Upload>() {
            //                new Upload()
            //                {
            //                    Title = "Small City Gif",
            //                    Created = DateTime.Now,
            //                }
            //            }
            //    };
            //    context.Albums.Add(album);

            //    var anotherAlbum = new Album()
            //    {
            //        Title = "Testing",
            //        Description = "My Description",
            //        Created = DateTime.Now
            //    };
            //    context.Albums.Add(anotherAlbum);

            //    var thridAlbum = new Album()
            //    {
            //        Title = "Line Art",
            //        Description = "Created this line artwork",
            //        Created = DateTime.Now,
            //        Uploads = new List<Upload>() {
            //                new Upload()
            //                {
            //                    Title = "Line Art Gif",
            //                    Created = DateTime.Now,
            //                }
            //            }
            //    };
            //    context.Albums.Add(thridAlbum);

            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        var msg = ex.Message;
            //    }

            //}

#endif
        }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
    }
}

