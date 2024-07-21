using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Persistence.Database
{
    public class $xxxAPPLICATIONxxx$DbContext : DbContext, I$xxxAPPLICATIONxxx$DbContext
    {
        // TODO(crhodes)
        // Add additional DbSet<TYPE> as needed.

        public DbSet<$xxxTYPExxx$> $xxxTYPExxx$sSet { get; set; }
        public DbSet<$xxxTYPExxx$PhoneNumber> $xxxTYPExxx$PhoneNumbersSet { get; set; }

        public DbSet<$xxxITEMxxx$> $xxxITEMxxx$sSet { get; set; }
        
        //public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

        // NOTE(crhodes)
        // I think all this goes away in favor of migrations from PWC
        public PAEF1CoreDbContext()
        {
            // NOTE(crhodes)
            // Package Manager Console does not like logging.  All attempts to work around have failed.
            // Explore using net tools.  For now, remove logging.
            // Int64 startTicks = 0;
            // if (Common.VNCCoreLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);
            
            // NOTE(crhodes)
            // This is good for demos.  Just create on the fly

            //Database.EnsureCreated();
            //Database.EnsureDeleted();

            // TODO(crhodes)
            // Need to determine how EF Core handles this.  We used to do #2
            // System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<PAEF1CoreDbContext, Configuration>());

            // There are four database initialization strategies

            // 1. CreateDatabaseIfNotExists (default)

            // System.Data.Entity.Database.SetInitializer<PAEF1CoreDbContext>(new CreateDatabaseIfNotExists<PAEF1CoreDbContext>());

            // 2. DropCreateDatabaseIfModelChanges

            // System.Data.Entity.Database.SetInitializer<PAEF1CoreDbContext>(new DropCreateDatabaseIfModelChanges<PAEF1CoreDbContext>());

            //System.Data.Entity.Database.SetInitializer<PAEF1CoreDbContext>(
            //    new DropCreateDatabaseIfModelChanges<PAEF1CoreDbContext>());

            // 3. DropCreateDatabaseAlways

            // System.Data.Entity.Database.SetInitializer<PAEF1CoreDbContext>(new DropCreateDatabaseAlways<PAEF1CoreDbContext>());

            // 4. Custom DB Initializer

            // System.Data.Entity.Database.SetInitializer<PAEF1CoreDbContext>(new PAEF1CoreDbContextDatabaseInitializer());

            // Release builds and Dependency Injection use lambda's.  Use special handling.
            
            // if (Common.VNCCoreLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // NOTE(crhodes)
            // Package Manager Console does not like logging.  All attempts to work around have failed.
            // Explore using net tools.  For now, remove logging.
            // Int64 startTicks = 0;
            // if (Common.VNCCoreLogging.PersistenceLow) startTicks = Log.PERSISTENCE_LOW("Enter", Common.LOG_CATEGORY);
            
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PAEF1Core_DB"].ConnectionString);
            //optionsBuilder.UseSqlServer("Data Source=.\\SQL2019; Initial Catalog=PAEF1Core; Integrated Security=True ; Encrypt=false");
            
            // if (Common.VNCCoreLogging.PersistenceLow) Log.PERSISTENCE_LOW("Exit", Common.LOG_CATEGORY, startTicks);            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE(crhodes)
            // Package Manager Console does not like logging.  All attempts to work around have failed.
            // Explore using net tools.  For now, remove logging.
            // Int64 startTicks = 0;
            // if (Common.VNCCoreLogging.PersistenceLow) startTicks = Log.PERSISTENCE_LOW("Enter", Common.LOG_CATEGORY);
            
            // NOTE(crhodes)
            // Used to be able to do this in EF6
            
            // modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));
            
            // NOTE(crhodes)
            // Can use [NotMapped] on Domain Class Property
            //[NotMapped]
            //public Boolean? IsDirty { get; set; }
            
            // or do individual Types here 

            modelBuilder.Entity<Cat>().Ignore(c => c.IsDirty);
            modelBuilder.Entity<Mouse>().Ignore(c => c.IsDirty);
            modelBuilder.Entity<CatEmailAddress>().Ignore(c => c.IsDirty);
            modelBuilder.Entity<CatPhoneNumber>().Ignore(c => c.IsDirty);
            
            // HACK(crhodes)
            // Still looking for ways

            //var entityTypes = modelBuilder.Model.GetEntityTypes().Select(t => t.ClrType).ToList();

            //var entityTypes2 = modelBuilder.Model.GetEntityTypes();
            //var foo = modelBuilder.Entity<Cat>();

            //foreach (var eType in entityTypes)
            //{

            //    //modelBuilder.Entity<eType>().Ignore(c => c.IsDirty);
            //}

            //foreach (var eType in entityTypes2)
            //{
            //     //modelBuilder.Entity<eType>().Ignore(c => c.IsDirty);
            //}

            // NOTE(crhodes)
            // Maybe this should be in <migrationname>.cs

            //SeedDatabase(modelBuilder);
            
            // if (Common.VNCCoreLogging.PersistenceLow)Log.PERSISTENCE_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // NOTE(crhodes)
            // Package Manager Console does not like logging.  All attempts to work around have failed.
            // Explore using net tools.  For now, remove logging.
            // Int64 startTicks = 0;
            // if (Common.VNCCoreLogging.PersistenceLow) startTicks = Log.PERSISTENCE_LOW("Enter", Common.LOG_CATEGORY);
            
            // NOTE(crhodes)
            // Add Convention
            //configurationBuilder.Conventions.Add(_ => new MyCustomConvention());

            // Remove Convention

            //configurationBuilder.Conventions.Remove(typeof(MyCustomConvention));
            // NOTE(crhodes)
            // Bulk conversions require a class

            //configurationBuilder.Properties<Color>().HaveConversion(typeof(ColorToString));

            //public class ColorToStringConverter : ValueConverter<Color, string>
            //{
            //    public ColorToStringConverter() : base(ColorString, ColorStruct) { }

            //    private static Expression<Func<Color, string>> ColorString = v => new String(v.Name);
            //    private static Expression<Func<string, Color>> ColorStruct = v => Color.FromName(v);

            //}
            
            // if (Common.VNCCoreLogging.PersistenceLow)Log.PERSISTENCE_LOW("Exit", Common.LOG_CATEGORY, startTicks);            
        }
        
        // NOTE(crhodes)
        // This does not keep it out of Migration :(
        // public class MyCustomConvention : IModelFinalizingConvention
        // {
            // public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
            // {
                // foreach (var property in modelBuilder.Metadata.GetEntityTypes()
                             // .SelectMany(
                                 // entityType => entityType.GetDeclaredProperties()
                                     // .Where(
                                         // property => property.Name == "IsDirty")))
                // {
                    // property.SetIsStored(false);
                // }
            // }
        // }
        
        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(new Cat { Id = 1, FieldString = "Archer" });

            var catList = new Cat[]
            {
                new Cat { Id=2, FieldString="Molly"},
                new Cat { Id=3, FieldString="Rafa"},
                new Cat { Id=4, FieldString="Rodger"}
            };

            modelBuilder.Entity<Mouse>().HasData(catList);

            //            new Domain.Cat
            //            {
            //                Id = 1,
            //                FieldString = "Cat1",
            //                FieldInt = 1,
            //                FieldSingle = 1.1f,
            //                FieldDouble = 11.11,
            //                FieldDate = new DateTime(2001, 1, 1),
            //                DateCreated = DateTime.Now
            //            },
            //            new Domain.Cat
            //            {
            //                Id = 2,
            //                FieldString = "Cat2",
            //                FieldInt = 2,
            //                FieldSingle = 2.2f,
            //                FieldDouble = 22.22,
            //                FieldDate = new DateTime(2002, 2, 2),
            //                DateCreated = DateTime.Now
            //            },
            //            new Domain.Cat
            //            {
            //                Id = 3,
            //                FieldString = "Cat3",
            //                FieldInt = 3,
            //                FieldSingle = 3.3f,
            //                FieldDouble = 33.33,
            //                FieldDate = new DateTime(2003, 3, 3),
            //                DateCreated = DateTime.Now
            //            }
        }
        
        public override int SaveChanges()
        {
            Int64 startTicks = 0;
            if (Common.VNCCoreLogging.Persistence) startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            try
            {
                // Override SaveChanges so EF will enforce use of IModificationHistory changes.

                var hist = this.ChangeTracker.Entries();

                // foreach (var item in hist)
                // {
                    // var isImod = item is IModificationHistory;
                    // int i = 0;
                // }

                foreach (var history in this.ChangeTracker.Entries()
                          .Where(e => e.Entity is IModificationHistory
                            && (e.State == EntityState.Added || e.State == EntityState.Modified))
                           .Select(e => e.Entity as IModificationHistory)
                  )
                {
                    history.DateModified = DateTime.Now;

                    // Use DateCreated DateTime.MinValue as new flag

                    var dt = DateTime.MinValue;
                    var dt2 = SqlDateTime.MinValue;
                    var hdc = history.DateCreated;

                    //if (history.DateCreated == DateTime.MinValue)
                    //{
                    //    history.DateCreated = DateTime.Now;
                    //}

                    if (history.DateCreated == null)
                    {
                        history.DateCreated = DateTime.Now;
                    }
                }

                // Save changes to database.

                int result = base.SaveChanges();

                // Reset the IsDirty flag on any entities implementing INotificationHistory

                foreach (var history in this.ChangeTracker.Entries()
                          .Where(e => e.Entity is IModificationHistory)
                          .Select(e => e.Entity as IModificationHistory))
                {
                    history.IsDirty = false;
                }

                if (Common.VNCCoreLogging.Persistence) Log.PERSISTENCE($"($xxxAPPLICATIONxxx$DbContext) Exit ({result})", Common.LOG_CATEGORY, startTicks);

                return result;
            }
            // NOTE(crhodes)
            // This does not exist but can roll your own. See
            // 
            //catch (DbEntityValidationException ex)
            //{
            //    // Display some details on errors

            //    var sb = new StringBuilder();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }

            //    throw new DbEntityValidationException(
            //        "Entity Validation Failed - errors follow:\n" +
            //        sb.ToString(), ex
            //        ); // Add the original exception as the innerException
            //}
            catch (DbUpdateConcurrencyException ex)
            {
                var databaseValues = ex.Entries.Single().GetDatabaseValues();

                //if (databaseValues == null)
                //{
                //    MessageDialogService.ShowInfoDialog(
                //        "The entity has been deleted by another user.  Cannot continue.");
                //    PublishAfterDetailDeletedEvent(Id);
                //    return;
                //}

                //var result = MessageDialogService.ShowOkCancelDialog(
                //    "The entity has been changed by someone else." +
                //    " Click OK to save your changes anyway; Click Cancel" +
                //    " to reload the entity from the database.", "Question");

                //if (result == MessageDialogResult.OK)   // Client Wins
                //{
                //    // Update the original values with database-values
                //    var entry = ex.Entries.Single();
                //    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                //    await saveFunc();
                //}
                //else  // Database Wins
                //{
                //    // Reload entity from database
                //    await ex.Entries.Single().ReloadAsync();
                //    await LoadAsync(Id);
                //}
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                throw (ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                throw (ex);
            }

        }

        //public override async Task<int> SaveChangesAsync()
        //public override async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
        //public override async Task<int> SaveChangesAsync(Boolean acceptAllChancesOnSuccess, System.Threading.CancellationToken cancellationToken = default)
        public override async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            Int64 startTicks = 0;
            if (Common.VNCCoreLogging.Persistence) startTicks = Log.PERSISTENCE("($xxxAPPLICATIONxxx$DbContext) Enter", Common.LOG_CATEGORY);

            int result = -1;

            try
            {
                // Override SaveChanges so EF will enforce use of IModificationHistory changes.

                var hist = this.ChangeTracker.Entries();

                // foreach (var item in hist)
                // {
                    // var isImod = item is IModificationHistory;
                    // int i = 0;
                // }

                foreach (var history in this.ChangeTracker.Entries()
                  .Where(e => e.Entity is IModificationHistory
                    && (e.State == EntityState.Added || e.State == EntityState.Modified))
                   .Select(e => e.Entity as IModificationHistory)
                  )
                {
                    history.DateModified = DateTime.Now;

                    // Use DateCreated DateTime.MinValue as new flag

                    var dt = DateTime.MinValue;
                    var dt2 = SqlDateTime.MinValue;
                    var hdc = history.DateCreated;

                    //if (history.DateCreated == DateTime.MinValue)
                    //{
                    //    history.DateCreated = DateTime.Now;
                    //}

                    if (history.DateCreated == null)
                    {
                        history.DateCreated = DateTime.Now;
                    }
                }

                // Save changes to database.

                result = await base.SaveChangesAsync();

                // Reset the IsDirty flag on any entities implementing INotificationHistory

                foreach (var history in this.ChangeTracker.Entries()
                                              .Where(e => e.Entity is IModificationHistory)
                                              .Select(e => e.Entity as IModificationHistory))
                {
                    history.IsDirty = false;
                }

                if (Common.VNCCoreLogging.Persistence) Log.PERSISTENCE($"($xxxAPPLICATIONxxx$DbContext) Exit ({result})", Common.LOG_CATEGORY, startTicks);

                return result;
            }
            // NOTE(crhodes)
            // This does not exist but can roll your own. See
            // 
            //catch (DbEntityValidationException ex)
            //{
            //    // Display some details on errors

            //    var sb = new StringBuilder();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }

            //    throw new DbEntityValidationException(
            //        "Entity Validation Failed - errors follow:\n" +
            //        sb.ToString(), ex
            //        ); // Add the original exception as the innerException
            //}
            catch (DbUpdateConcurrencyException ex)
            {
                //TODO(crhodes) Maybe this should be in ViewModelBase
                // so can more sensibly use MessageDialogService
                var databaseValues = ex.Entries.Single().GetDatabaseValues();

                //if (databaseValues == null)
                //{
                //    MessageDialogService.ShowInfoDialog(
                //        "The entity has been deleted by another user.  Cannot continue.");
                //    PublishAfterDetailDeletedEvent(Id);
                //    return;
                //}

                //var result = MessageDialogService.ShowOkCancelDialog(
                //    "The entity has been changed by someone else." +
                //    " Click OK to save your changes anyway; Click Cancel" +
                //    " to reload the entity from the database.", "Question");

                //if (result == MessageDialogResult.OK)   // Client Wins
                //{
                //    // Update the original values with database-values
                //    var entry = ex.Entries.Single();
                //    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                //    await saveFunc();
                //}
                //else  // Database Wins
                //{
                //    // Reload entity from database
                //    await ex.Entries.Single().ReloadAsync();
                //    await LoadAsync(Id);
                //}

                throw (ex);
            }
            catch (DbUpdateException ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                throw (ex);
            }
            catch (OperationCanceledException ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                throw (ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                throw (ex);
            }
        }
    }
}
