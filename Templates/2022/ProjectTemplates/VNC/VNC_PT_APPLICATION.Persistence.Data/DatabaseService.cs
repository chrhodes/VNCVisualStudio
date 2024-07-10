using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using $customAPPLICATION$.Domain;

namespace $safeprojectname$
{
    public class DatabaseService : DbContext, I$customAPPLICATION$DbContext
    {
        public DbSet<$customTYPE$> $customTYPE$Set { get; set; }

        public DatabaseService() : base("$customAPPLICATION$DB")
        {
            //Database.SetInitializer(new DatabaseInitializer());
            Database.SetInitializer<$customAPPLICATION$DbContext>(
                new DropCreateDatabaseIfModelChanges<$customAPPLICATION$DbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                // TODO(crhodes)
                // This gives us too many types including the embedded ServiceType and PoolConditionReport
                // Need some way of filtering them out, otherwise have to put pointless IsDirty field in them.

                modelBuilder.Types()
                    .Configure(c => c.Ignore("IsDirty"));

            }
            catch (InvalidOperationException ex)
            {
                // Ignore
            }

            base.OnModelCreating(modelBuilder);

            // Do not pluralize table names

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
