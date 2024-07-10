using System.Data.Entity;

using $xxxMODULExxx$$xxxNAMESPACExxx$.Domain;

namespace $xxxMODULExxx$$xxxNAMESPACExxx$.Persistence.Data
{
    public interface I$xxxMODULExxx$DbContext
    { 
        int SaveChanges();

        DbSet<$xxxTYPExxx$> $xxxTYPExxx$sSet { get; set; }
    }
}
