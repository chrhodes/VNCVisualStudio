
using System.Data.Entity;

using $customAPPLICATION$.Domain;

namespace $safeprojectname$
{
    public interface I$customAPPLICATION$DbContext
    { 
        int SaveChanges();

        DbSet<$customTYPE$> $customTYPE$Set { get; set; }
    }
}
