using System.Data.Entity;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Persistence.Database
{
    public interface I$xxxAPPLICATIONxxx$DbContext
    { 
        int SaveChanges();

        DbSet<$xxxTYPExxx$> $xxxTYPExxx$sSet { get; set; }
    }
}
