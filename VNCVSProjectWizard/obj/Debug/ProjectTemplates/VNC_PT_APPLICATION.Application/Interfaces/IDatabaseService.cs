using System.Data.Entity;

using Common.Domain;

using $customAPPLICATION$.Domain;

namespace $safeprojectname$.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<$customTYPE$> $customTYPE$ { get; set; }

        void Save();
    }
}
