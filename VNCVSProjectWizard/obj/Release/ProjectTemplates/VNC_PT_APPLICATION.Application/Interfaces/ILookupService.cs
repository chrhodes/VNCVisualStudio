using System.Data.Entity;

namespace $safeprojectname$.Interfaces
{
    public interface ILookupService<TEntity> where TEntity : class
    {
        IDbSet<TEntity> Items { get; set; }

        void Save();
    }
}
