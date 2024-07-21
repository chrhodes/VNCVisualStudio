using Microsoft.EntityFrameworkCore;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Application
{
    public interface ILookupService<TEntity> where TEntity : class
    {
        DbSet<TEntity> Items { get; set; }

        void Save();
    }
}
