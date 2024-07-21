using Microsoft.EntityFrameworkCore;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Application
{
    public interface IDatabaseService
    {
        DbSet<$xxxTYPExxx$> $xxxTYPExxx$sSet { get; set; }

        void Save();
    }
}
